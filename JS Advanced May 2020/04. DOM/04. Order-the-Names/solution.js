function solve() {
    // get the button and define eventListener
    document.querySelector("button").addEventListener("click", onClick);
    const list = {};
    
    // make the list
    const items = document.querySelectorAll("ol").querySelectorAll("li");
    [...items].forEach(e => {
        // add in dictionary alphabetically
        if (e.textContent.trim().length == 0) {
            return;
        }
        const letter = e.textContent[0].toLocalUpperCase();
        list[letter] = e.textContent;
    })

    function onClick(){
        const input = document.querySelector("input");
        const value = input.value;
        const letter = value[0].toLocalUpperCase();

        if (list.hasOwnProperty(letter) == false) {
            list[letter] = value;
        }else{
            list[letter] = list[letter] + ", " + value;
        }

        // modify DOM
        const index = letter.charCodeAt(0) - 65;
        items[index].textContent = list[letter];

        input.value = "";
    }
}

function solve2() {
    const button = document.querySelector("button");
    const list = document.querySelectorAll("li");

    button.addEventListener("click", function (e) {
        e.preventDefault();

        let value = document.querySelector("input").value;
        let firstLetter = value[0].toUpperCase();
        let index = Number(firstLetter.charCodeAt()) - 65;
        let oldValue = list[index].innerHTML;

        let name = firstLetter + value.substring(1).toLocaleLowerCase()

        if (oldValue === "") {
            list[index].innerHTML = name;
        } else {
            list[index].innerHTML += `, ${name}`;
        }
    })
}