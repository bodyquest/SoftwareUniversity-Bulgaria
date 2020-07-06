function attachEvents() {
    
    const elements = {
        location() { return document.querySelector("#location"); },
        sendBtn() { return document.querySelector("#submit"); },
        forecastSection() { return document.querySelector("#forecast"); },
        currentSection() { return document.querySelector("#current"); },
        upcomingSection() { return document.querySelector("#upcoming"); },
    }

    const symbols = {
        "Sunny" : "☀",
        "Partly sunny": "⛅",
        "Overcast": "☁",
        "Rain": "☂",
        "Degrees": "°"
    };

    const locations = "https://judgetests.firebaseio.com/locations.json";
    const currentWeather = `https://judgetests.firebaseio.com/forecast/today/`;
    const forecast = `https://judgetests.firebaseio.com/forecast/upcoming/`;

    elements.sendBtn().addEventListener("click", getWeather);
    const { value: location} = elements.location();

    async function getWeather() {
        let data = [];

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
                if (city.name.toLowerCase() === location.toLowerCase()) {
                    cityCode = city.code;
                    break;
                }
                else{
                    throw new Error("Invalid input data");
                }
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
            elements.forecastSection().style.display = "block";
        
            let spanOne = createHTML("span", "condition-symbol", `${symbol}`);
            let spanTwo = createHTML("span", "condition");
            let name = createHTML("span", "forecast-data", `${today.name}`);
            let temp = createHTML("span", "forecast-data", `${today.forecast.low}${symbols.Degrees} / ${today.forecast.high}${symbols.Degrees}`);
            let condition = createHTML("span", "forecast-data", `${today.forecast.condition}`);

            appendChildrenToParent([name, temp, condition], spanTwo);

            elements.currentSection().appendChild(spanOne);
            elements.currentSection().appendChild(spanTwo);

            for (let day of upcoming.forecast) {
                renderForecast(day);
            }

            function renderForecast(data) {

                const symbol = symbols[data.condition];

                let forecastInfoDiv = createHTML("div", "forecast-info")
                let spanMain = createHTML("span", "upcoming");
                let spanOne = createHTML("span", "symbol", `${symbol}`);
                let spanTwo = createHTML("span", "forecast-data", `${data.low}${symbols.Degrees} / ${data.high}${symbols.Degrees}`);
                let spanThree = createHTML("span", "forecast-data", `${data.condition}`);
                
                appendChildrenToParent([spanOne, spanTwo, spanThree], spanMain);
                forecastInfoDiv.appendChild(spanMain);
                    
                elements.upcomingSection().appendChild(forecastInfoDiv);
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