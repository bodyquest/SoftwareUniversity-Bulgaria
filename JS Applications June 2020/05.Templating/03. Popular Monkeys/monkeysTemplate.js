import monkeys from "./monkeys.js";

window.addEventListener("load", async () => {
    const section = document.querySelector("section");

    //init templates
    const list = await (await fetch("./monkeyList.hbs")).text();
    const listTemplate = Handlebars.compile(list);
    Handlebars.registerPartial("monkey", await(await fetch("./monkey.hbs")).text());

    // render HTML
    const html = listTemplate({ monkeys });
    section.innerHTML = html;

    const monkeysElement = document.querySelector(".monkeys");
    monkeysElement.addEventListener("click", onClick)

    function onClick(e){
        if (e.target.tagName !== "BUTTON") {
            return;
        }
        
        const div = e.target.parentNode.querySelector("p");
        //div.removeAttribute("style");

        if (div.style && div.style.display == "none") {
            div.removeAttribute("style");
        }else{
            div.style.display = "none";
        }
    }
});