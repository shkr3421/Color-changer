Here are the same answers with a bit more explanation, kept simple and clear:

1. Local Storage
This is done using localStorage because it stores data in the browser without an expiration time. Even if the browser is closed or the system is restarted, the data remains until it is manually cleared.


2. String value
localStorage stores all values only as strings. When data is saved using setItem, it is converted into a string, and it is retrieved using getItem("email").


3. localStorage.clear()
This method removes all key–value pairs stored in localStorage, making it useful when a user logs out and all saved data needs to be deleted.


4. Cache Manifest file (.appcache)
The browser uses a cache manifest file to know which files (HTML, CSS, JS, images) should be saved for offline use so that the page can load without internet.


5. First visit requires internet
The offline page does not appear on the first visit because the browser needs an active internet connection initially to download and cache the files. Without caching first, the browser has nothing to load offline.



If you want, I can also convert this into exam-ready answers or one-line answers 👍
