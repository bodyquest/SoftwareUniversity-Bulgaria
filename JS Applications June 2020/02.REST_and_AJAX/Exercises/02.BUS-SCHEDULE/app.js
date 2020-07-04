function solve() {

    elements = {
        stopInfo() { return document.querySelector(".info")},
        arrive() { return document.querySelector("#arrive"); },
        depart() { return document.querySelector("#depart"); }
    }

    const baseUrl = `http://judgetests.firebaseio.com/schedule/`;
    let busStop = "depot";
    let busStopName = "";

    function depart() {

        fetch(baseUrl + `${busStop}.json`)
        .then((response) => response.json())
        .then((result) => showBusInfo(result))
        .catch(throwError());

    }

    function arrive() {

        fetch(baseUrl + `${busStop}.json`)
            .then(resources => resources.json())
            .then(data => {
                elements.stopInfo().textContent = `Arriving at ${data.name}`;
                busStop = data.next;
            })
            .catch(throwError());
        
            switchBusState();
    }

    function showBusInfo(data) {

        busStop = data.next;
        busStopName = data.name;
        elements.stopInfo().textContent = `Next stop ${busStopName}`;

        switchBusState();
    } 

    function switchBusState(){

        const {disabled: isDisabled} = elements.arrive();
        if (isDisabled) {
            elements.arrive().disabled = false;
            elements.depart().disabled = true;
        }
        else{
            elements.arrive().disabled = true;
            elements.depart().disabled = false;
        }
    }

    function throwError() {
        return () => {
            elements.stopInfo.textContent = "Error";
            elements.arrive().disabled = true;
            elements.depart().disabled = true;
        };
    }

    return {
        depart,
        arrive
    };
}

let result = solve();