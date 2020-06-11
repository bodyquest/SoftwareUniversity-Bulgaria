function solve() {
    
    function showOptions(e) {
        const box = document.querySelector("#box");
        const menu = document.querySelector("#dropdown-ul");

        if (menu.style.display === "block") {
            menu.style.display = "none";
            box.style.backgroundColor = "black";
            box.style.color = "white";
        }else{
            menu.style.display = "block";
        }
    }

    function changeColor(e) {
        const box = document.querySelector("#box");
        const color = e.target.innerText;
        box.style.backgroundColor = color;
        box.style.color = "black";
    }

    document.querySelector("#dropdown").addEventListener("click", showOptions);
    document.querySelector("#dropdown-ul").addEventListener("click", changeColor);
}