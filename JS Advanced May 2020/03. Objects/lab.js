// 1. Towns to JSON
function townsToJson(input = []){
    let headers = input[0].split("|").map(x => x.trim());
    let towns = input.slice(1);

    let jsonTowns = []
    for (let i = 0; i < towns.length; i++) {
        const cityInfo = towns[i].split("|")
        .map(x => x.trim()).filter(i => i != "");
        const city = {
            Town: cityInfo[0],
            Latitude: Number(Number(cityInfo[1]).toFixed(2)),
            Longitude: Number(Number(cityInfo[2]).toFixed(2))
        }

        // console.log(temp);
        jsonTowns.push(city);
    }

    console.log(JSON.stringify(jsonTowns));
}

townsToJson(['| Town | Latitude | Longitude |',
'| Sofia | 42.696552 | 23.32601 |',
'| Beijing | 39.913818 | 116.363625 |']
);

// 2. Sum by Town
function sumIncome(input = []){
    
    let towns =  input.reduce((acc, element, i, arr) => {
        //let city = Object.keys(acc)[(i + 1)/2 - 2];

        if (i % 2 !== 0) {
            let name;
            if (Object.keys(acc).length === 0) {
                name = arr[0];
            }

            name = arr[i-1];
            let income = Number(element);

            if (acc.hasOwnProperty(name)) {
                acc[name] += income;
            } else {
                acc[name] = income;
            }
        }
        
        return acc;
    }, {} );

    return JSON.stringify(towns)
}

console.log(sumIncome(['Sofia','20','Varna','3','Sofia','5','Varna','4']));
console.log(sumIncome(['Sofia','20','Varna','3','sofia','5','varna','4']));

// 3. Populations in Town
function aggregatePopulation (input = []){

    let parsedData = input.reduce((acc, element, i, arr) => {
        let cityInfo = element.split(" <-> ");
        let name = cityInfo[0];
        let population = Number(cityInfo[1]);

        if (acc.hasOwnProperty(name)) {
            acc[name] += population;
        } else {
            acc[name] = population;
        }

        return acc;
    }, {} )

    let result2 = []
    for (const key in parsedData) {
          result2.push(`${key} : ${parsedData[key]}`);
        }
        
    return result2.join("\n");
}

console.log(aggregatePopulation(['Istanbul <-> 100000',
'Honk Kong <-> 2100004',
'Jerusalem <-> 2352344',
'Mexico City <-> 23401925',
'Istanbul <-> 1000']
));

// 4. From JSON to HTML Table
function makeTable(input = []) {

    let table = [];
    let temp = JSON.parse(input);
    console.log(temp);

    let objKeys = Object.keys(temp[0]);

    table.push("<table>\n");

    table.push("\t<tr>");
    for (const key in objKeys) {
         table.push(`<td>${objKeys[key]}</td>`);
    }
    table.push("</tr>\n");
    
    for (let i = 0; i < temp.length; i++) {
        const obj = temp[i];

        table.push("\t<tr>");
        for (const key in obj) {
             table.push(`<td>${obj[key]}</td>`);
        }
        table.push("</tr>\n");
    }

    table.push("</table>\n");

    return table.join("");
}

console.log(
    makeTable(['[{"Name":"Tomatoes & Chips","Price":2.35},{"Name":"J&B Chocolate","Price":0.96}]']));

// 8. Circle LAB
class Circle{
    constructor(radius){
        this.radius = radius;
    }

    get area() {
        Math.PI * (this.radius ** 2);
    }
    get diameter(){
        return this.radius * 2;
    }
    set diameter(value){
        this.radius = value / 2;
    }
}

// 9. Point
class Point{
    constructor(x, y){
        this.x = x;
        this.y = y;
    }

    static distance(p1, p2){
        return Math.sqrt(Math.pow(p1.x - p2.x,2) + Math.pow(p1.y - p2.y, 2));
    }
}

let p1 = new Point(5, 5);
let p2 = new Point(9, 8);
console.log(Point.distance(p1, p2));

