function attachEvents() {
    
    const elements = {
        author() { return document.querySelector("#author"); },
        content() { return document.querySelector("#content"); },
        sendBtn() { return document.querySelector("#submit"); },
        refreshBtn() { return document.querySelector("#refresh"); },
        chatWindow() { return document.querySelector("#messages"); }
    }

    const baseUrl = "http://localhost:3000/messenger";

    elements.sendBtn().addEventListener("click", sendMessage);
    elements.refreshBtn().addEventListener("click", refreshMessages);

    function sendMessage(){

        const { value: author} = elements.author();
        const { value: content} = elements.content();

        fetch(baseUrl, {
            method: "POST",
            body: JSON.stringify({author, content})
    
        })
            .then(() => {
                elements.author().value = "";
                elements.content().value = "";
            });
    }

    function refreshMessages() {

        fetch(baseUrl)
        .then((response) => response.json())
        .then(data => {
            elements.chatWindow().textContent = "";

            Object.entries(data).forEach(([elementId, message]) => {
                const {author, content} = message;
                elements.chatWindow().textContent += `${author}: ${content}\n`;
            });
        })
        .catch(() => console.log("Error"));
    }
}

attachEvents();