function solve(){
    // declare the variables for the microelement
    const recipes = {
        apple : {
            carbohydrate: 1,
            flavour: 2,
            order: ["carbohydrate", "flavour"]
        },
        lemonade: {
            carbohydrate: 10,
            flavour: 20,
            order: ["carbohydrate", "flavour"]
        },
        burger: {
            carbohydrate: 5,
            fat: 7,
            flavour: 3,
            order: ["carbohydrate", "fat", "flavour"]
        },
        eggs: {
            protein: 5,
            fat: 1,
            flavour: 1,
            order: ["protein", "fat", "flavour"]
        },
        turkey: {
            protein: 10,
            fat: 10,
            flavour: 10,
            order: ["protein", "fat", "flavour"]
        }
    }

    const microElements = {
        protein: 0,
        carbohydrate: 0,
        fat: 0,
        flavour: 0
    }

    const operations = {
        restock,
        prepare,

    }
    // declare the functions -> the make operations on the variables
    function restock(element, qty){
        microElements[element] += qty;
        return "Success";
    }

    function prepare(recipe, qty){
        //copy the recipe
        const required = Object.assign({} , recipes[recipe]);

        required.order.forEach(key => {
            required[key] *= qty
        });

        for (let element of required.order) {
            if (microElements[element] < required[element]) {
                return `Error: not enough ${element} in stock`;
            }
        }

        required.order.forEach(key => {
            microElements[key] = required[key];
        });

        return "Success";
    }

    function report(){
        return `protein=${microElements.protein} carbohydrate=${microElements.carbohydrate} fat=${microElements.fat} flavour=${microElements.flavour}`
    }
    // declare the manager -> work on the input
    function manager(command){
        const tokens = command.split(" ");
        return operations[tokens[0]](tokens[1], Number(tokens[2]));
    }

    // return the reference to the manager
    return manager;
};

let manager = solve();

console.log(manager("restock flavor 50"));
console.log(manager("prepare lemonade 4"));



