let assert = require("chai").assert;
const Console = require("./specialConsole.js");

describe("Console main functionality", function(){

    it("returns correct result (happy path)", function(){
        let actualResult = Console.writeLine("The sum of {0} and {1} is {2}", 41, 1, 42);
        let expectedResult = "The sum of 41 and 1 is 42";
        assert.equal(actualResult, expectedResult, "The function did not return correct result!");
    });

    it("returns passed empty string", function(){
        let result = Console.writeLine("");
        assert.equal(result, "", "The function did not return correct result!");
    });
    
    it("returns passed string", function(){
        let result = Console.writeLine("hello");
        assert.equal(result, "Ko staa?", "The function did not return correct result!");
    });
    
    it("returns passed object as a string", function(){
        let obj = {fullName: "Debelin Dignibutov", occupation: "stretcher bearer"};
        let actualResult = Console.writeLine(obj);
        assert.equal(actualResult, JSON.stringify(obj), "The function did not return correct result!");
    });

    it("throws error when multiple arguments are passed, when the first is not a string", function(){
        let obj = {name: "Prasemir Butonoskov", occupation: "stretcher bearer"};
        assert.throws(() => { Console.writeLine(obj, 1, 2) }, TypeError, 'No string format given!');
    });
    it("throws error when the number of parameters does not match to the number of placeholders", function(){
        assert.throws(() => {Console.writeLine("The sum of {0} and {1} is {2}", 9, 10, 11, 12) }, RangeError, "Incorrect amount of parameters given!");
    });
    it("throws error when the placeholders have indexes not within the parameters range", function(){
        assert.throws(() => { Console.writeLine("The sum of {0} and {1} is {2}", 3) }, RangeError, "Incorrect amount of parameters given!");
    });
    it("throws error with given incorrect placeholders", function(){
        assert.throws(() => { Console.writeLine("The sum of {1}", 1) }, RangeError, "Incorrect placeholders given!");
    });
})