const notifications = {
    info: document.getElementById('infoBox'),
    error: document.getElementById('errorBox')
};

function hideNotification(notification) {
    notification.textContent = '';
    notification.style.display = 'none';
}

export default {

    showError(message) {
        notifications.error.textContent = message;
        notifications.error.style.display = 'block';
        notifications.error.addEventListener('click', (e) => {
            hideNotification(e.target);
        });
    
        setTimeout(() => hideNotification(notifications.error), 3000);
    },

    showInfo(message) {
        notifications.info.textContent = message;
        notifications.info.style.display = 'block';
        notifications.info.addEventListener('click', (e) => {
            hideNotification(e.target);
        });
    
        setTimeout(() => hideNotification(notifications.info), 3000);
    }
};