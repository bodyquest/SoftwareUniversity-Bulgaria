// 1. Heroes
function solve(){
    
    // declare factory functions
    function fighter(name){
        const instance = {
            name,
            health: 100,
            stamina: 100,
            fight
        }

        function fight(){
            instance.stamina --;
            console.log(`${instance.name} slashes at the foe!`);
        }

        return instance;
    }

    function mage(name){
        const instance = {
            name,
            health: 100,
            mana: 100,
            cast
        }

        function cast(spell){
            instance.mana --; 
            console.log(`${instance.name} cast ${spell}`);
        }

        return instance;
    }

    // return object wit factory functions as methods
    return {
        mage: mage,
        fighter: fighter
    };
}

let create = solve();
const scorcher = create.mage("Scorcher");
scorcher.cast("fireball")
scorcher.cast("thunder")
scorcher.cast("light")

const scorcher2 = create.fighter("Scorcher 2");
scorcher2.fight()

console.log(scorcher2.stamina);
console.log(scorcher.mana);

//********************************************//

function solve2(){
    // define prototypes
    const fighterProto = {
        fight
    }

    function fight(){
        this.stamina --;
        console.log(`${this.name} slashes at the foe!`);
    }

    // declare factory functions
    function fighter(name){
        const instance = Object.create(fighterProto);

        Object.assign(instance, {
            name,
            health: 100,
            stamina: 100
        })

        return instance;
    }

    const mageProto = {
        cast
    }

    function cast(spell){
        this.mana --; 
        console.log(`${this.name} cast ${spell}`);
    }

    function mage(name){
        const instance = Object.create(mageProto);
        Object.assign(instance, {
            name,
            health: 100,
            mana: 100
        })

        return instance;
    }

    // return object wit factory functions as methods
    return {
        mage: mage,
        fighter: fighter
    };
}

let createPrim = solve2();
const scorcherPrim = createPrim.mage("Scorcher");
scorcherPrim.cast("fireball")
scorcherPrim.cast("thunder")
scorcherPrim.cast("light")

const scorcherSec = createPrim.fighter("Scorcher 2");
scorcherSec.fight()

console.log(scorcherSec.stamina);
console.log(scorcherPrim.mana);

//*******************************************//

function solveWithConstructorFn() {
    function CreateFighter(name) {
        this.name = name;
        this.health = 100;
        this.stamina = 100;

        this.fight = function () {
            this.stamina -= 1;
            return `${this.name} slashes at the foe!`;
        }
    }
 
    function CreateMage(name) {
        this.name = name;
        this.health = 100;
        this.mana = 100;

        this.cast = function (spell) {
            this.mana -= 1;
            return `${this.name} cast ${spell}`;
        }
    }
 
    return {
        mage: function (name) {
            return new CreateMage(name);
        },
        fighter: function (name) {
            return new CreateFighter(name);
        }
    }
}


// 02. Construction Crew

// function constructionCrew(worker){
//     [weight, experience, levelOfHydrated, dizziness] = worker;

//     function hydrate(){
//         if (dizziness === undefined) {
//             return;
//         }
//         if (dizziness === true) {
//             levelOfHydrated = 0.1 * experience * weight;
//         }

//         return dizziness;
//     }

//     return{
//         weight: weight,
//         experience: experience,
//         levelOfHydrated: levelOfHydrated,
//         dizziness: hydrate
//     }
// }


// 03. Car Factory
function carFactory(descriptor){

    // define templates for engines
    const engines = [
        { power: 90, volume: 1800 },
        { power: 120, volume: 2400 },
        { power: 200, volume: 3500 }
    ]

    const carriages = [
        { type: 'hatchback', color: "" },
        { type: 'coupe', color: "" }
    ];

    // create car with model, color, carriage
    const car = {
        model: descriptor.model,
        carriage: {
            type: descriptor.carriage,
            color: descriptor.color
        },
    };

    // find the engine depending on min power
    // walk the array with templates to find the engine
    for (let engine of engines) {
        if (descriptor.power <= engine.power) {
            car.engine = Object.assign(engine);
            break;
        }
    }

    // find the size of the tires
    car.wheels = new Array(4)
        .fill(descriptor.wheelsize % 2 == 0 ? descriptor.wheelsize-1 : descriptor.wheelsize);
 
    return car;
}

const car = carFactory({ model: 'VW Golf II',
power: 90,
color: 'blue',
carriage: 'hatchback',
wheelsize: 14 });

const car2 = carFactory({ model: 'Opel Vectra',
power: 110,
color: 'grey',
carriage: 'coupe',
wheelsize: 17 }
);

console.log(car);
console.log(car2);

// 04. Extensible Object
function solve4(){
    //make object with prototype 
    const proto = {};

    const instance = Object.create(proto);

    instance.extend = function(template){
        // walk the template and check each property
        for (let prop in template) {
            // if it s a function, we copy it on the proto, otherwise to the instance
            if (typeof template[prop] === "function") {
                proto[prop] = template[prop];
            }else{
                instance[prop] = template[prop];
            }
        }
    };
    
    // return reference
    return instance;
}

const myInstance = solve4();

myInstance.extend({
    extensionMethod: function () {/* Do something */},
    extensionProperty: 'someString'
});

console.log(myInstance);
console.log(Object.getPrototypeOf(myInstance));

// 05. String Extension
(function solve() {
    String.prototype.ensureStart = function(str){
        if (!this.startsWith(str)){
            return str + this;
        }

        return this.toString();
    }

    String.prototype.ensureEnd = function(str){
        if (!this.endsWith(str)){
            return this + str;
        }

        return this.toString();
    }

    String.prototype.isEmpty = function(){
        if (this.length === 0){
            return true;
        }

        return false;
    }

    String.prototype.truncate = function(num){
        if (num <= 3){
            return ".".repeat(num);
        }
        if (num >= this.length) {
            return this.toString();
        }

        let spaceIndex = this.substring(0, num -1).lastIndexOf(" ");
        if (spaceIndex >= 0) {
            return this.substring(0, spaceIndex) + "...";
        }
        else{
            return this.substring(0, num - 3) + "...";
        }
    }

    String.format = function (str, ...params){
        params.forEach((el, i) => {
            str = str.replace(`{${i}}`, el)
        });

        return str;
    }

})();

// 06. Sorted List
class List {
    constructor(){
        this._list = [];
        this.size = 0;
    }

    add(element){
        this._list.push(element);
        this._list.sort(List.sort);
        this.size++;
        return this;
    }

    remove(index){
        this._validate(index);
        this._list.splice(index, 1);
        this.size--;
        return this;
    }

    get(index){
        this._validate(index);
        return this._list[index];
    }

    _validate(index){
        if (index < 0 || index >= this._list.length) {
            throw new Error("Index is out of bounds");
        }
    }

    static sort(a, b){
        return a-b;
    }
}

function List() {
    const list = [];

    const instance = {
        size: 0,
        add,
        remove,
        get
    }

    function add(element){
        list.push(element);
        list.sort(comparator);
        instance.size++;
        return instance;
    }

    function remove(index){
        _validate(index);
        _list.splice(index, 1);
        instance.size--;
        return instance;
    }

    function get(index){
        _validate(index);
        return list[index];
    }

    function _validate(index){
        if (index < 0 || index >= list.length) {
            throw new Error("Index is out of bounds");
        }
    }

    function comparator(a, b){
        return a-b;
    }

    return instance;
}

let list = new List();
list.add(5).add(6).add(3).add(10);
console.log(list._list);