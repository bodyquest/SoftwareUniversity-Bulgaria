function getInfo() {
    const baseUrl = `http://judgetests.firebaseio.com/businfo/{stopId}.json`;
    const validIDs = ["1287", "1308", "1327", "2334"];

    const elements = {
        stopId() { return document.querySelector("#stopId"); },
        stopName() { return document.querySelector("#stopName"); },
        buses() { return document.querySelector("#buses"); }
    }

    const stopId = elements.stopId().value;
    if (!validIDs.includes(stopId)) {

        elements.stopName().textContent = "ERROR";
        return;
    }

    const url = baseUrl.replace(`{stopId}`, stopId);

    fetch(url)
        .then((response) => response.json())
        .then((result) => showInfo(result)
        );

    function showInfo(data) {

        elements.buses().textContent = "";
        elements.stopName().textContent = data.name;

        Object.keys(data.buses).forEach((bus) => {
            let li = document.createElement("li");
            li.textContent = `Bus ${bus} arrive in ${data.buses[bus]} minutes`;
            elements.buses().appendChild(li);
        });
    }
}