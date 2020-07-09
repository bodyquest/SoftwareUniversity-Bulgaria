function attachEvents(){

    const elements = {
        person() { return document.querySelector("#person"); },
        phone() { return document.querySelector("#phone"); },
        createContact() { return document.querySelector("#btnCreate"); },
        loadContacts() { return document.querySelector("#btnLoad"); },
        phoneBook() { return document.querySelector("#phonebook"); }
    }

    const baseUrl = "https://phonebook-nakov.firebaseio.com/phonebook.json";
    const deleteUrl = "https://phonebook-nakov.firebaseio.com/phonebook";

    elements.createContact().addEventListener("click", () => {
        const { value: person} = elements.person();
        const { value: phone} = elements.phone();

        fetch(baseUrl, {
            method: "POST",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify({person, phone})
        })
            .then(() => {
                elements.person().value = "";
                elements.phone().value = "";
                elements.phoneBook().textContent = "";
            });
    });

    elements.loadContacts().addEventListener("click", loadPhoneBook)

    function loadPhoneBook() {

        fetch(baseUrl)
            .then((response) => response.json())
            .then(data => {
                elements.phoneBook().textContent = "";

                Object.entries(data).forEach(([elementId, phoneBook]) => {
                    const {person, phone} = phoneBook;
                    const li = document.createElement("li");
                    const deleteBtn = document.createElement("button");

                    li.textContent = `${person}: ${phone}`;
                    deleteBtn.textContent = "Delete";
                    deleteBtn.id = elementId;
                    deleteBtn.addEventListener("click", deletePhone);

                    li.appendChild(deleteBtn);
                    elements.phoneBook().appendChild(li);
                });
            })
            .catch(() => console.log("Error"));
    }

    function deletePhone(){
        const id = this.getAttribute("id");

        fetch(deleteUrl + `/${id}.json`, {
            method: "DELETE"
        })
            .then(() => {
                elements.phoneBook().textContent = "";
                loadPhoneBook();
            })
            .catch(() => console.log("Error"));
    }
}
