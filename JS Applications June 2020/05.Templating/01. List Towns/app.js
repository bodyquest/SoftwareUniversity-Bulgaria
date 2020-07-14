window.addEventListener("load", () => {

    const rootEl = document.querySelector("#root");
    const input = document.querySelector("#towns");
    // compile the template -> function
    document.querySelector("#btnLoadTowns").addEventListener("click", renderTowns);

    // load template -. text
    const templateString = document.querySelector("#main-template").innerHTML;
    
    Handlebars.registerPartial("town", document.getElementById("town-template").innerHTML);
    const templateFn = Handlebars.compile(templateString);

    function renderTowns(e){
        e.preventDefault();

        const towns = input.value.split(", ");
        
        // execute the template with the data - > HTML text
        const generatedHtml = templateFn({ towns });

        // load the HTML into the DOM
        rootEl.innerHTML = generatedHtml;
    }
});
