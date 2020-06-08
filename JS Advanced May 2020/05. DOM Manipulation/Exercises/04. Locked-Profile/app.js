// to finish

function lockedProfile() {

    // select all buttons in NodeList
    const $buttons = document.querySelectorAll("div#container main#main div.profile");
    
    // make array form the NodeList of buttons
    [...$buttons].forEach((button) => {
        
        // hook event handler to each button
        button.addEventListener("click", (event) => {
            const divSibling = event.currentTarget.parentNode.children[9];

            const selector = divSibling.id.split("HiddenFields")[1];
            const $lockInput = document
                .querySelector(`input[name="${selector + 'Locked'}"]`);
            
            if (!$lockInput.checked && button.textContent == "Show more") {
                divSibling.style.display = "block";
                button.textContent = "Hide it";
            }
            else{
                divSibling.style.display = "none";
                button.textContent = "Show more";
            }
        })
    })
}