import createHTML from "./dom.js";
import * as api from "./data.js";

window.addEventListener("load", () =>{
    
    document.querySelector("#loadBooks")
        .addEventListener("click", displayBooks);

    const table = document.querySelector("table tbody");

    const input = {
        title: document.querySelector("#title"),
        author: document.querySelector("#author"),
        isbn: document.querySelector("#isbn")
    }

    const createBtn = document.querySelector("form > button");
    createBtn.addEventListener("click", createBook);

    async function createBook(e) {

        e.preventDefault();

        if (validateInput(input) === false) {
            alert("All fields are required");
            return;
        }

        const book = {
            title: input.title.value,
            author: input.author.value, 
            isbn: input.isbn.value,
        }

        try {
            toggleInput(false, ...Object.values(input), createBtn);

            const created = await api.createBook(book);
            table.appendChild(renderBook(created));
            Object.entries(input).forEach(([k, v]) => v.disabled = "");

        } catch (error) {
            alert(error);
            console.log(error);
        }finally{
            toggleInput(true, ...Object.values(input), createBtn);
        }
    }

    function toggleInput (active, ...list) {

        list.forEach(e => e.disabled = !active);
    }

    function validateInput() {
        let valid = true;

        Object.entries(input).forEach(([k, v]) => {
            if (v.value.length === 0) {
                v.className = "inputError";
                valid = false;
            }else{
                v.removeAttribute("class");
            }
        });

        return valid;
    }

    async function displayBooks(){

        table.innerHTML = "<tr><td colspan=`4`>Loading...</td></tr>";
        const books = await api.getBooks();
        table.innerHTML = "";

        books
            .sort((a, b) => a.author.localeCompare(b.author))
            .forEach(b => table.appendChild(renderBook(b)));

    }
    
    function renderBook(book) {
        const editBtn = createHTML("button", "Edit");
        editBtn.addEventListener("click", toggleEditor);

        const deleteBtn = createHTML("button", "Delete");
        deleteBtn.addEventListener("click", deleteBook);

        const element = 
        createHTML("tr", [
            createHTML("td", book.title),
            createHTML("td", book.author),
            createHTML("td", book.isbn),
            createHTML("td", [
                editBtn,
                deleteBtn,
            ]),
        ]);

        return element;

        function toggleEditor() {

            const confirmBtn = createHTML("button", "Save");
            const cancelBtn = createHTML("button", "Cancel");
            confirmBtn.addEventListener("click", async () => {

                if (validateInput(edit) === false) {
                    alert("All fields are required!");
                    return;
                }

                const edited = {
                    objectId: book.objectId,
                    title: edit.title.value,
                    author: edit.author.value,
                    isbn: edit.isbn.value
                }

                try {

                    toggleInput(false, ...Object.values(edit), confirmBtn, cancelBtn);
                    const result = await api.updateBook(edited);
                    table.replaceChild(renderBook(result), editor);
                } catch (error) {
                    alert(error);
                    console.log(error);
                    toggleInput(true, ...Object.values(edit), confirmBtn, cancelBtn);
                }
            });

            cancelBtn.addEventListener("click", () => {
                table.replaceChild(element, editor);
            });

            const edit = {
                title: createHTML("input", null, {type: "text", value: book.title}),
                author: createHTML("input", null, {type: "text", value: book.author}),
                isbn: createHTML("input", null, {type: "text", value: book.isbn}),
            }

            const editor = createHTML("tr", [
                createHTML("td", edit.title),
                createHTML("td", edit.author),
                createHTML("td", edit.isbn),
                createHTML("td", [
                    confirmBtn,
                    cancelBtn,
                ]),
            ]);

            table.replaceChild(editor, element);
        }

        async function deleteBook() {
            try {

                deleteBtn.disabled = true;
                deleteBtn.textContent = "Please wait...";

                await api.deleteBook(book.objectId);
                element.remove();

            } catch (error) {
                alert(error);
                console.log(error);
            }finally {
                deleteBtn.disabled = false;
                deleteBtn.textContent = "Delete";
            }
        }
    }
});
