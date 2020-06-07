function notify(message) {
    // find the box
    const notification = document.querySelector("#notification");
    // leave a message
    notification.textContent = message;
    // visualize
    notification.style.display = "block";

    // activate timer to hide the box in 2s
    setTimeout(() => {
        notification.style.display = "none";
    }, 2000);
}