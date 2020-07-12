import createHTML from "./dom.js";
import * as api from "./data.js";

function attachEvents() {

    // get main DOM elements;
    const elements = {
        loadBtn() { return document.querySelector("button.load"); },
        addBtn() { return document.querySelector("button.add"); },

        catches() { return document.querySelector("#catches"); },
        addCatch() { return document.querySelector("#addForm >"); }
    }

    // get input elements
    const input = {
        angler: document.querySelector("#addForm > input.angler"),
        weight: document.querySelector("#addForm > input.weight"),
        species: document.querySelector("#addForm > input.species"),
        location: document.querySelector("#addForm > input.location"),
        bait: document.querySelector("#addForm > input.bait"),
        captureTime: document.querySelector("#addForm > input.captureTime"),
    }

    // add handlers
    elements.loadBtn().addEventListener("click", loadCatches);
    elements.addBtn().addEventListener("click", addCatch);

    async function loadCatches(){
        try {
            elements.loadBtn().textContent = "Loading...";
            const catches = await api.listCatches();

            elements.loadBtn().textContent = "Load";
            Object.entries(catches)
                .forEach(([key, fish]) => {

                    const editBtn = createHTML("button", "Edit");
                    editBtn.addEventListener("click", updateCatch);

                    const deleteBtn = createHTML("button", "Delete");
                    deleteBtn.addEventListener("click", deleteCatch);

                    let div = document.createElement("div");
                    div.className ="catch";
                    div.setAttribute("data-id", `${key}`);

                    let props = ["angler", "weight", "species", "location", "bait", "captureTime"];

                    props.forEach(prop => {
                        let label = document.createElement("label");
                        let input = document.createElement("input");

                        label.textContent = `${prop.charAt(0).toUpperCase() + prop.slice(1)}`;
                        div.appendChild(label);

                        input.className = prop;
                        input.type = prop === "weight" || prop === "captureTime" 
                            ? "number" 
                            : "text";
                        input.value = fish[prop];

                        div.appendChild(input);
                        div.appendChild(document.createElement("hr"));
                    });

                    div.appendChild(editBtn);
                    div.appendChild(deleteBtn);
                    
                    elements.catches().appendChild(div);
                });
        }
        catch (error) {
            handleError(error);
        }
    }

    async function addCatch(){

        if (validateInput(input) === false) {
            alert("All fields are required");
            return;
        }

        const fish = {
            angler: input.angler.value,
            species: input.species.value,
            weight: input.weight.value,
            bait: input.bait.value,
            location: input.location.value,
            captureTime: input.captureTime.value,
        }
        try {
            await api.createCatch(fish);
            Object.entries(input).forEach(([k, v]) => v.value = "");
            elements.catches().textContent = "";
            loadCatches();
        } catch (error) {
            handleError(error);
        }
    }

    async function updateCatch(e){
        const parent = e.target.parentNode;
        const id = parent.getAttribute("data-id");
        let childList = parent.getElementsByTagName("input");
        const [angler, weight, species, location, bait, captureTime] = childList;

        const edited = {
            angler: angler.value,
            species: species.value,
            weight: weight.value,
            bait: bait.value,
            location: location.value,
            captureTime: captureTime.value,
        }

        try {
            await api.updateCatch(id, edited);
            elements.catches().textContent = "";
            loadCatches();
        } catch (error) {
            handleError(error);
        }
    }

    async function deleteCatch(e){
        const parent = e.target.parentNode;
        const id = parent.getAttribute("data-id");
        try {
            await api.deleteCatch(id);
            elements.catches().textContent = "";
            loadCatches();
        } catch (error) {
            handleError(error);
        }
    }

    function validateInput() {
        let valid = true;

        Object.entries(input).forEach(([k, v]) => {
            if (v.value.length === 0) {
                v.className = "inputError";
                valid = false;
            }else{
                v.classList.remove("inputError");
            }
        });

        return valid;
    }

    function handleError(error){
        alert(error);

        elements.catches().style.display = "block";
        const h2 = createHTML("h2", `${error.type}: ${error.message}`, {className: "error-cast" });
        elements.catches().appendChild(h2);

        console.log(error);
    }
}

attachEvents();