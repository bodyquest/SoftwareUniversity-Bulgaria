// 1. Heroic Inventory
function heroicInventory (input) {

    let heroData =  input.reduce((acc, heroString, i, arr) => {
        let [name, level, items] = heroString.split(" / ");
        acc.push({name, level: Number(level), items: items ? items.split(",").map(x => x.trim()) : []});

        return acc;
    }, []);

    console.log(JSON.stringify(heroData));
}

heroicInventory(
    ["Isaac / 25 / Apple, GravityGun", "Derek / 12 / BarrelVest, DestructionSword", "Hes / 1 / Desolator, Sentinel, Antara"]);

// 2. JSON's Table
function htmlTable(data) {
    let parsedData = data.map(x => JSON.parse(x));
    let createTable = content => `<table>${content}\n</table>`;
    let createRow = content => `\n\t<tr>${content}\n\t</tr>`;
    let createData = content => `\n\t\t<td>${content}</td>`;

    let result = parsedData.reduce((accRows, row) => {
        let tdForPerson = Object.values(row).reduce((tdAcc, td) => {
            return tdAcc + createData(td);
        }, "");

        return accRows + createRow(tdForPerson);
    }, "");

    console.log(createTable(result));
}

// function solveTable(input){
//     const rows = [];

//     for (const line of input) {
        
//     }

//     function createRow(person){
//         return [
//             `\t<tr>`,
//             `\t\t<td></td>`,
//             `\t</tr>`,
//         ];
//     }
// }

htmlTable(['{"name":"Pesho","position":"Promenliva","salary":100000}',
'{"name":"Teo","position":"Lecturer","salary":1000}',
'{"name":"Georgi","position":"Lecturer","salary":1000}']
);

// 3. Cappy Juice
function juiceFactory(input){
    let parsedData = {};
    let juiceBottle = {};
    
    for (let i = 0; i < input.length; i++) {
        let juice = input[i].split(" => ");

        if (parsedData[juice[0]]) {
            parsedData[juice[0]] = parsedData[juice[0]] + Number(juice[1]);
        }
        else{
            parsedData[juice[0]] = Number(juice[1]);
        }

        let bottleQty = Math.floor(parsedData[juice[0]] / 1000);
        if (bottleQty > 0) {
            juiceBottle[juice[0]] = bottleQty;
        }
    }

    let result = Object.entries(juiceBottle);
    for (let i = 0; i < result.length; i++) {

        let fruit = result[i].join(" => ");
        console.log(fruit);
    }
}

function juiceFactory2(input){
    let parsedData = input.reduce((juiceAcc, juiceKVP) => {
        let [juiceName, qty] = juiceKVP.split(" => ");

        if (juiceAcc.currentJuiceQty[juiceName]) {
            juiceAcc.currentJuiceQty[juiceName] += +(qty);
        }
        else{
            juiceAcc.currentJuiceQty[juiceName] = +(qty);
        }

        let bottleQty = Math.floor(juiceAcc.currentJuiceQty[juiceName] / 1000);
        if (bottleQty > 0 && !juiceAcc.completedJuices.includes(juiceName)) {
            juiceAcc.completedJuices.push(juiceName);
        }

        return juiceAcc;
    }, {completedJuices: [], currentJuiceQty: {} });
    
    parsedData.completedJuices.map(juice => {
        console.log(`${juice} => ${Math.floor(parsedData.currentJuiceQty[juice]/1000)}`);
    });
}

juiceFactory(
    ['Orange => 2000', 'Peach => 1432', 'Banana => 450', 'Peach => 600', 'Strawberry => 549']);

juiceFactory2(
        ['Orange => 2000', 'Peach => 1432', 'Banana => 450', 'Peach => 600', 'Strawberry => 549']);
    
juiceFactory2(
    ['Kiwi => 234',
    'Pear => 2345',
    'Watermelon => 3456',
    'Kiwi => 4567',
    'Pear => 5678',
    'Watermelon => 6789']
)

// 4. Store Catalogue
function catalogue(input) {
    let parsedData = input.reduce((acc, productKVP) => {
        let [name, price] = productKVP.split(":").map(x => x.trim());

        if (acc[name[0]]) {
            acc[name[0]] = [...acc[name[0]], productKVP];
        }
        else{
            acc[name[0]] = [productKVP];
        }

        return acc;
}, {} );

    Object.keys(parsedData).sort().map(x => {
        console.log(`${x}`);
        parsedData[x].sort().map(product => {
            console.log(` ${product.split(" : ").join(": ")}`);
        });
    });
}

catalogue(
['Apricot : 20.4',
'Fridge : 1500',
'TV : 1499',
'Deodorant : 10',
'Boiler : 300',
'Apple : 1.25',
'Anti-Bug Spray : 15',
'T-Shirt : 10']
);

// 5. Auto-Engineering Company
function carFactory(data) {

    let parsedData = data.reduce((acc, cars) => {
        let [brand, model, produced] = cars.split("|").map(x => x.trim());

        if (acc[brand]) {
            if (acc[brand][model]) {
                acc[brand][model] += +produced;
            }
            else{
                acc[brand][model] = +produced;
            }
        }
        else{
            acc[brand] = {[model]: +produced};
        }

        return acc;
}, {} );

      Object.keys(parsedData).map(x => {
          console.log(`${x}`);
          Object.keys(parsedData[x]).map(car => {
            console.log(`###${car} -> ${parsedData[x][car]}`);
          })
      })
}   

carFactory(['Audi | Q7 | 1000',
'Audi | Q6 | 100',
'BMW | X5 | 1000',
'BMW | X6 | 100',
'Citroen | C4 | 123',
'Volga | GAZ-24 | 1000000',
'Lada | Niva | 1000000',
'Lada | Jigula | 1000000',
'Citroen | C4 | 22',
'Citroen | C5 | 10']
);

// 6. System Components
function componentDB(input) {
    let parsedData = input.reduce((db, components) => {
        let [system, component, subComponent] = components.split("|").map(x => x.trim());

        if (db[system]) {
            if (db[system][component]) {
                db[system][component].push(subComponent);
            }
            else{
                db[system][component] = [subComponent]
            }
        }
        else{
            db[system] = {[component]: [subComponent]};
        }

        return db;
    }, {} );

    for (let [system, component] of Object.entries(parsedData).sort(compareSystems)) {
        console.log(system);

        for (let [componentName, subComponent] of Object.entries(component).sort(compareComponents)) {
            console.log(`|||${componentName}`);

            parsedData[system][componentName].forEach(subComponent => {
                console.log(`||||||${subComponent}`);
            });
        }

    }

    function compareSystems(a, b) {
        if (Object.keys(b[1]).length !== Object.keys(a[1]).length) {
            return Object.keys(b[1]).length - Object.keys(a[1]).length;
        }
        return a[0].localeCompare(b[0])
    }
    function compareComponents(a, b) {
           return Object.keys(b[1]).length - Object.keys(a[1]).length;       
    }
}

componentDB(
['SULS | Main Site | Home Page',
'SULS | Main Site | Login Page',
'SULS | Main Site | Register Page',
'SULS | Judge Site | Login Page',
'SULS | Judge Site | Submission Page',
'Lambda | CoreA | A23',
'SULS | Digital Site | Login Page',
'Lambda | CoreB | B24',
'Lambda | CoreA | A24',
'Lambda | CoreA | A25',
'Lambda | CoreC | C4',
'Indice | Session | Default Storage',
'Indice | Session | Default Security']
);

// 7. Usernames
function sortUsernames(input) {
    let usernames = new Set();

    for (let i = 0; i < input.length; i++) {
        const element = input[i];
        usernames.add(element);
    }

    let sortedSet = Array.from(usernames).sort((a, b) => {
        if (a.length !== b.length) {
            return a.length - b.length;
        }

        return a.localeCompare(b);
    });

    console.log(sortedSet.join("\n"));
}

sortUsernames(
['Ashton',
'Kutcher',
'Ariel',
'Lilly',
'Keyden',
'Aizen',
'Billy',
'Braston']
);

// 8. Unique Sequences
function getSequence(input) {
    let arrays = [];
    let items = input.map(i => JSON.parse(i));

    for (const array of items) {
        let sum = array.reduce((acc, b) => acc + b, 0);

        if (!arrays.some((x) => x.reduce((a, b) => a+b, 0) === sum)) {
            arrays.push(array);
        }
    }
    
    console.log(arrays
        .sort((a, b) => a.length - b.length)
        .map(array => `[${array.sort((a, b) => b-a).join(", ")}]`)
    .join("\n"));
}

getSequence(
["[-3, -2, -1, 0, 1, 2, 3, 4]",
"[10, 1, -17, 0, 2, 13]",
"[4, -3, 3, -2, 2, -1, 1, 0]"]
);

let array1 = [-3, -2, -1, 0, 1, 2, 3, 4];
let array2 = [4, -3, 3, -2, 2, -1, 1, 0];

var intersections = array1.filter(e => array2.indexOf(e) !== -1);

console.log(intersections);

let arr1 = [-3, -2, -1, 0, 1, 2, 3, 4];
let arr2 = [4, -3, 3, -2, 2, -1, 1, 0];

function getMatch(a, b) {
    var matches = [];

    for ( let i = 0; i < a.length; i++ ) {
        for ( let e = 0; e < b.length; e++ ) {
            if ( a[i] === b[e] ) matches.push( a[i] );
        }
    }
    return matches;
}

getMatch(arr1, arr2);
console.log(getMatch(arr1, arr2));
if (getMatch(arr1, arr2).length == arr1.length) {
    console.log("true");
}

// 7. Data Class


// 8. Tickets
function sortTickets(tickets, criteria){

    class Ticket {
        constructor(descriptor){
            const[destination, price, status] = descriptor.split("|");
            this.destination = destination;
            this.price = Number(price);
            this.status = status;
        }
    }
 
    function comparator(a, b) {
        try {
            return a[criteria].localeCompare(b[criteria]);
        } catch (e) {
            return a[criteria] - b[criteria];
        }
    }
    
    return tickets
        .map(t => new Ticket(t))
        .sort(comparator);
}

console.log(sortTickets(['Philadelphia|94.20|available',
'New York City|95.99|available',
'New York City|95.99|sold',
'Boston|126.20|departed'],
'destination'
));

// 9. Sorted List
class List{
    constructor(){
        this.list = [];
        this.size = 0;
    }

	add (input){
        this.list.push(Number(input));
        this.list.sort((a, b) => a - b);
        this.size++;
    }

    remove(index){
        this.validate(index);
        this.list.splice(index, 1);
        this.size--;
    }

    get(index){
        return this.list[index];
    }

    validate(index){
        if (index < 0 || index >= this.list.length) {
            throw new Error("Index is out of bounds.");
        }
    }
  }

let list = new List();
list.add(5);
list.add(6);
list.add(3);
list.add(7);
console.log(list.get(1)); 
list.remove(1);
console.log(list.get(1));
console.log(list);

