function solve(){
    // add click eventListener to the body
    const tbody = document.querySelector("tbody");
    const items = tbody.querySelectorAll("tr");

    tbody.addEventListener("click", parseTable);

    function parseTable(e) {
        // find the chosen element
        const row = e.target.parentNode;

        console.log(row);
        if (row.nodeName === "TR") {
            // 1. if te chosen element is in light -> darken it
            if (row.style.backgroundColor!== "") {
                row.style.backgroundColor = "";
            }
            else{
                // else darken all the rest and lighten the chosen one
                [...items].forEach(i => i.style.backgroundColor = "");
                row.style.backgroundColor = "#413f5e";
            }

        }
    }
}