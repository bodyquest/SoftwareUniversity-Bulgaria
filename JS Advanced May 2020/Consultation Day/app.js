app();
// demo of how to sort li elements by content for example
function app(){
    const list = document.querySelector("ol");
    const items = [...list.querySelectorAll("li")];

    items.sort((a, b) => a.textContent.localeCompare(b.textContent));

    items.forEach(i => list.appendChild(i))
    
}