
//התקנה של ה- service worker 
self.addEventListener('install', (event) => {
    event.waitUntil(
        caches.open('my-app-cache').then((cache) => {
            return cache.addAll([
                '/',
                '/homepage/{UserId:int}',
                '/Chat/{UserId:int}',
                '/settings/{UserId:int}',
                '/haifa/trivia/{UserId:int}',
                '/haifa/studyunit/{UserId:int}'
            ]).catch (error => {
                console.error('Failed to cache: ', error);
            });
            }).catch(error => {
                console.error('Failed to open cache: ', error);
        })
    );
});


// טיפול בבקשות רשת
self.addEventListener('fetch', (event) => {
    event.respondWith((async () => {
        const cache = await caches.open(CACHE_NAME);

        const cacheResponse = await cache.match(event.request);
        if (cacheResponse !== undefined) {
            // רענון המטמון עם נתונים מהשרת
            fetch(event.request).then(response => {
                cache.put(event.request, response.clone());
            });
            return cacheResponse;
        } else {
            // גישה לרשת אם אין במטמון
            return fetch(event.request).then(response => {
                // שמירת התגובה במטמון לשימוש עתידי
                cache.put(event.request, response.clone());
                return response;
            });
        }
    })());
});


// האזנה לאירוע 'push' המתקבל מהשרת
self.addEventListener('push', (event) => {
    // פירוק הנתונים שמתקבלים מהפוש, בהנחה שהם בפורמט JSON
    const notificationData = JSON.parse(event.data.text());

    // יצירת אובייקט אפשרויות עבור ההתראה
    const options = {
        body: notificationData.message,  // הודעת ההתראה
        icon: notificationData.icon,    // אייקון ההתראה
        data: notificationData.data     // נתונים נוספים להתראה (כגון URL לפתיחה בלחיצה)
    };

    // הצגת ההתראה באמצעות showNotification עם הכותרת והאפשרויות שהגדרנו
    event.waitUntil(
        self.registration.showNotification(notificationData.title, options)
    );
});

// האזנה לאירוע 'notificationclick' שמתרחש כאשר המשתמש לוחץ על ההתראה
self.addEventListener('notificationclick', (event) => {
    // סגירת ההתראה
    event.notification.close();

    // פתיחת חלון חדש עם ה-URL שנמצא בנתוני ההתראה
    event.waitUntil(
        clients.openWindow(event.notification.data.url)
    );
});
