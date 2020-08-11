const notifications = {
    info: document.getElementById('infoBox'),
    error: document.getElementById("errorBox"),
    loading: document.getElementById("loadingBox")
};

let requests = 0;

function hideNotification(notification) {
    //notification.firstElementChild.textContent = '';
    notification.style.display = 'none';
}

export default {

    showError(message) {
        notifications.error.firstElementChild.textContent = message;
        notifications.error.style.display = 'block';
        notifications.error.addEventListener('click', (e) => {
            hideNotification(e.target);
        });
    
        setTimeout(() => hideNotification(notifications.error), 3000);
    },

    showInfo(message) {
        
        console.log(notifications.info);
        
        notifications.info.firstElementChild.textContent = message;
        notifications.info.style.display = 'block';
        notifications.info.addEventListener('click', (e) => {
            hideNotification(e.target);
        });
    
        setTimeout(() => hideNotification(notifications.info), 3000);
    },

    beginRequest() {
        requests++;
        notifications.loading.style.display = 'block';
        // notifications.loading.addEventListener('click', (e) => {
        //     hideNotification(e.target);
        // });
    },

    endRequest() {
        requests--;
        if (requests === 0) {
            notifications.loading.style.display = 'none';
        }
    }
};