import * as api from "./data.js";

window.addEventListener("load", () => {

    const list = document.querySelector("#phonebook");
    const inputPerson = document.querySelector("#person");
    const inputPhone = document.querySelector("#phone");


    document.querySelector("#btnLoad").addEventListener("click", renderPhonebook);
    document.querySelector("#btnCreate").addEventListener("click", createContact);
    
    async function renderPhonebook() {
        const data = await api.getData();

        list.innerHTML = "";

        Object.entries(data).forEach(([id, entry]) => createElement(id, entry));
    }

    function createElement(id, entry) {
        const button = createHTML("button", "Delete");

        const element = createHTML("li", [
            createHTML("span", `${entry.person}: ${entry.phone}`),
            button
        ]);

        button.addEventListener("click", async() => {
            try {

                button.textContent = "Please wait...";
                button.disabled = true;

                await api.deleteEntry(id);
                element.remove();
            } catch (error) {

                button.textContent = "Delete";
                button.disabled = false;

                alert(error.message);
                console.error(error);
            }
        })
        list.appendChild(element);
    }

    async function createContact() {
        const person = inputPerson.value;
        const phone = inputPhone.value;

        const entry = {
            person,
            phone
        }

        const result = await api.createEntry(entry);
        const id = Object.keys(result)[0];

        createElement(id, result[id]);
    }

    function createHTML(type, content, attributes){
        const result = document.createElement(type);
    
        if (attributes !== undefined) {
            Object.assign(result, attributes);
        }
    
        if (Array.isArray(content)) {
            content.forEach(append);
        }else{
            append(content);
        }
    
        function append(node) {
            if (typeof node === "string" || typeof node === "number") {
                node = document.createTextNode(node);
            }
    
            result.appendChild(node);
        }
    
        return result;
    }
});
