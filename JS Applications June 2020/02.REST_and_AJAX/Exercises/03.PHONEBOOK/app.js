function attachEvents() {
    
    const elements = {
        person() { return document.querySelector("#person"); },
        phone() { return document.querySelector("#phone"); },
        createContact() { return document.querySelector("#btnCreate"); },
        loadContacts() { return document.querySelector("#btnLoad"); },
        phoneBook() { return document.querySelector("#phonebook"); }
    }
    
    const baseUrl = "http://localhost:3000/contacts";
    const contacts = [];

    elements.createContact().addEventListener("click", () => {
        const { value: person} = elements.person();
        const { value: phone} = elements.phone();

        fetch(baseUrl, {
            method: "POST",
            body: JSON.stringify({person, phone})
    
        })
            .then((response) => response.json())
            .then((result) => {
                contacts.push(result);
                elements.person().value = "";
                elements.phone().value = "";
            });

    });

    elements.loadContacts().addEventListener("click", () => {
        elements.phoneBook().textContent = "";
        contacts.forEach((contact) => {
            let li = document.createElement("li");

            const key = Object.keys(contact)[0];
            li.textContent = `${contact[key].person} - ${contact[key].phone}`;

            elements.phoneBook().appendChild(li);
        });
    });
}

attachEvents();