function host (endpoint) {
    return `https://judgetests.firebaseio.com/${endpoint}.json`
}

const api = {
    locations: "locations",
    today: "forecast/today/",
    upcoming: "forecast/upcoming/",

}

export async function getCodeAsync(cityName) {

    const data = await (await fetch(host(api.locations))).json();

    return data.find(loc => loc.name.toLowerCase() === cityName.toLowerCase()).code;
}

export async function getTodayAsync(code) {

    const data = await (await fetch(host(api.today + code))).json();

    return data;
}

export async function getUpcomingAsync(code) {

    const data = await (await fetch(host(api.upcoming + code))).json();

    return data;
}
