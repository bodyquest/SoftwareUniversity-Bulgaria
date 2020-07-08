function attachEvents() {
    
    const elements = {
        location() { return document.querySelector("#location"); },
        sendBtn() { return document.querySelector("#submit"); },
        forecastSection() { return document.querySelector("#forecast"); },
        currentSection() { return document.querySelector("#current"); },
        upcomingSection() { return document.querySelector("#upcoming"); },
    }

    const symbols = {
        "Sunny" : "☀",  // ☀
        "Partly sunny": "⛅",  // ⛅
        "Overcast": "☁", // ☁
        "Rain": "☂", // ☂
        "Degrees": "°" //
    };

    const locations = "https://judgetests.firebaseio.com/locations.json";
    const currentWeather = `https://judgetests.firebaseio.com/forecast/today/`;
    const forecast = `https://judgetests.firebaseio.com/forecast/upcoming/`;

    elements.sendBtn().addEventListener("click", getWeather);

    async function getWeather() {
        
        let data = [];
        
        elements.currentSection().textContent = "";
        elements.upcomingSection().textContent = "";

        try {
            data =  await fetch(locations)
            .then(async (response) => response.json());
        }
        catch (error) {
            handleError(error);
        }

        try {

            let cityCode = "";
            for (const city of data) {
                if (city.name.toLowerCase() === elements.location().value.toLowerCase()) {
                    cityCode = city.code;
                    break;
                }
            }
            if (cityCode == "") {
                throw new Error("Invalid input data");
            }
            
            const [today, upcoming] = await Promise.all([
                fetch(currentWeather + `${cityCode}.json`),
                fetch(forecast + `${cityCode}.json`)
            ])
            .then(async([todayResponse, forecastResponse]) =>{
                const today = await todayResponse.json();
                const upcoming = await forecastResponse.json();
                return [today, upcoming]
            });

            const symbol = symbols[today.forecast.condition];
        
            elements.location().value = "";

            // Create DOM elements
            elements.forecastSection().style.display = "block";
            
            let div = createHTML("div", "label", "Current conditions");
            let forecastDiv = createHTML("div", "forecasts");

            let spanOne = createHTML("span");
            spanOne.classList.add("condition");
            spanOne.classList.add("symbol");
            spanOne.innerHTML = symbols[today.forecast.condition];

            let spanTwo = createHTML("span", "condition");
            let name = createHTML("span", "forecast-data", `${today.name}`);
            let temp = createHTML("span", "forecast-data", `${today.forecast.low}${symbols.Degrees} / ${today.forecast.high}${symbols.Degrees}`);
            let condition = createHTML("span", "forecast-data", `${today.forecast.condition}`);

            appendChildrenToParent([name, temp, condition], spanTwo);
            appendChildrenToParent([spanOne, spanTwo], forecastDiv);
            elements.currentSection().appendChild(div);
            elements.currentSection().appendChild(forecastDiv);

            let divLabel = createHTML("div", "label", "Three-day forecast");
            let forecastInfoDiv = createHTML("div", "forecast-info");

            for (let day of upcoming.forecast) {
                forecastInfoDiv.appendChild(renderForecast(day));
            }

            elements.upcomingSection().appendChild(divLabel);
            elements.upcomingSection().appendChild(forecastInfoDiv);

            function renderForecast(data) {

                const symbol = symbols[data.condition];
                
                let spanMain = createHTML("span", "upcoming");
                let spanOne = createHTML("span", "symbol", `${symbol}`);
                let spanTwo = createHTML("span", null, `${data.low}${symbols.Degrees} / ${data.high}${symbols.Degrees}`);
                let spanThree = createHTML("span", null, `${data.condition}`);
                
                const result = appendChildrenToParent([spanOne, spanTwo, spanThree], spanMain);
                
                return result;
            };

        }
        catch (error) {
            handleError(error);
        }
    }

    function handleError(error){
        elements.forecastSection().style.display = "block";
        const h2 = createHTML("h2", "error-cast", `${error.message}`);
        elements.forecastSection().appendChild(h2);
    }

    function createHTML(tagName, className, textContent, attributes, event){
        let element = document.createElement(tagName);
        if (className) {
            element.classList.add(className);
        }

        if (textContent) {
            element.textContent = textContent;
        }

        if (attributes) {
            attributes.forEach((a) => element.setAttribute(a.k, a.v)
            )
        }

        if (event) {
            element.addEventListener(event.name, event.func );
        }

        return element;
    }   

    function appendChildrenToParent(children, parent){
        children.forEach((c) => parent.appendChild(c));
        return parent;
    }
}


attachEvents();