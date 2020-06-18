// to finish

function lockedProfile() {

    // add event handlers
    document.querySelector("main"). addEventListener("click", onClick);

    function onClick(e) {
        // check if button si clicked
        if (e.target.nodeName === "BUTTON") {
            // fin the parent of the button
            const parent = e.target.parentNode;

            // find the lock and if is locked, return;
            const lock = parent.querySelector("input[type='radio'][value='lock']");
            if (lock.checked) {
                return;
            }

            // find the hidden field
            const hiddenFields = [...parent.querySelectorAll("div")]
                .filter(d => d.id.includes("HiddenFields"))[0];

            if (hiddenFields.style.display !== "block") {
                // if is hidden, show "Hide it"
                hiddenFields.style.display = "block";
                e.target.textContent = "Hide it";
            } else{
                // else hide it and show "Show more"
                hiddenFields.style.display = "none";
                e.target.textContent = "Show mode";
            }
        }
    }
}