import createHTML from "./dom.js";
import * as data from "./data.js";

const symbols = {
    "Sunny" : "☀",
    "Partly sunny": "⛅",
    "Overcast": "☁",
    "Rain": "☂",
    "Degrees": "°"
};

window.addEventListener("load", () => {

    const input =  document.querySelector("#location");
    const mainDiv =  document.querySelector("#forecast");
    const todayDiv =  document.querySelector("#current");
    const upcomingDiv =  document.querySelector("#upcoming");

    document.querySelector("#submit").addEventListener("click", getForecast);

    async function getForecast() {

        const locationName = input.value;
        
        let code = "";
        try {
            code = await data.getCodeAsync(locationName);
        } catch (error) {
            input.value = "Error";
            return;
        }

        const todayData = data.getTodayAsync(code);
        const upcomingData = data.getUpcomingAsync(code);
        
        const [today, upcoming] = [
            await todayData,
            await upcomingData
        ];
        
        console.log(today);


        const symbolSpan = createHTML("span", "", {className: "condition symbol"});
        symbolSpan.innerHTML = symbols[today.forecast.condition];

        const tempSpan = createHTML("span", "", {className: "forecast-data"});
        tempSpan.innerHTML = `${today.forecast.low}${symbols.Degrees} / ${today.forecast.high}${symbols.Degrees}`;

        todayDiv.appendChild(createHTML("div", [
            symbolSpan,
            createHTML("span", [
                createHTML("span", today.name, {className: "forecast-data"}),
                tempSpan,
                createHTML("span", today.forecast.condition, {className: "forecast-data"}),
            ], {className: "condition"})
        ], {
            className: "forecast"
        }));

        const forecastInfo = createHTML("div", upcoming.forecast
            .map(renderUpcoming), { className: "forecast-info" });

        upcomingDiv.appendChild(forecastInfo);

        mainDiv.style.display = "block";
    }

    function renderUpcoming(forecast){
 
        const symbolSpan = createHTML("span", "", {className: "symbol"});
        symbolSpan.innerHTML = symbols[forecast.condition];

        const tempSpan = createHTML("span", "", { className: "forecast-data"});
        tempSpan.innerHTML = `${forecast.low}${symbols.Degrees} / ${forecast.high}${symbols.Degrees}`;

        const result = createHTML("span", [
            symbolSpan,
            tempSpan,
            createHTML("span", forecast.condition, { className: "forecast-data"}),
        ], {
            className: "upcoming"
        });

        return result;
    }
});

