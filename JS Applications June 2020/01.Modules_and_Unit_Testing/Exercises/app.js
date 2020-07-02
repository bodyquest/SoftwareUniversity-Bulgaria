import {people} from './data.js'
import * as myModule from './module.js';

const myVar = 3;

const result = myModule.addNumbers(myVar, myModule.getNumber());

console.log(people);

myModule.output("The result is" + result + " -> " + people.join(" : ")); 