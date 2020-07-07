const expect = require("chai").expect;
const assert = require("chai").assert;
const mathEnforcer = require("./tests.js");

describe("Main functionality", () => {
    describe("addFive tests", function () {
        it("returns undefined if parameter not a number", function() {
            let result = mathEnforcer("gimme five!")
            assert.equal(result, undefined, "The function did not return the correct result!")
        });
    
        it("returns undefined with a negative number parameter", function() {
            let result = mathEnforcer(-42)
            assert.equal(result, undefined, "The function did not return the correct result!")
        });
    
        it("returns correct result with a positive number parameter", function(){
            let actual = mathEnforcer.addFive(37);
            assert.equal(actual, 42, "The function did not return the correct result!");
        });
    
        it("returns correct result with floating-point number parameter", function(){
            expect(mathEnforcer.addFive(37.1)).to.be.closeTo(42.1, 0.1);
        });
    });

    describe("subtractTen tests", function(){
        it("should return undefined with a non-number parameter", function(){
            let actual = mathEnforcer.subtractTen("subtract me :)");
            assert.equal(actual, undefined, "The function did not return correct result!");
        });
        it("returns correct result with a negative number parameter", function(){
            let actual = mathEnforcer.subtractTen(0);
            assert.equal(actual, -10, "The function did not return correct result!");
        });
        it("returns correct result with a positive number parameter", function(){
            let actual = mathEnforcer.subtractTen(9);
            assert.equal(actual, -1, "The function did not return correct result!");
        });
        it("returns correct result with floating-point number parameter", function(){
            expect(mathEnforcer.subtractTen(52.1)).to.be.closeTo(42.1, 0.1);
        });
    });

    describe("sum", function(){
        it("should return undefined with a non-number parameter", function(){
            let result = mathEnforcer.sum("add me :)", 2);
            assert.equal(result, undefined, "The function did not return correct result!");
        });
        it("should return correct result with a non-number parameter", function(){
            let result = mathEnforcer.sum(2, "hello");
            assert.equal(result, undefined, "The function did not return correct result!");
        });
        it("should return correct result with a non-number parameter", function(){
            let result = mathEnforcer.sum("hi", "hello");
            assert.equal(result, undefined, "The function did not return correct result!");
        });

        it("returns correct result with two negative numbers as parameters", function(){
            let result = mathEnforcer.sum(-1, -1);
            assert.equal(result, -2, "The function did not return correct result!");
        });
        it("returns correct result with two positive numbers as parameters", function(){
            let result = mathEnforcer.sum(41, 1);
            assert.equal(result, 42, "The function did not return correct result!");
        });
        it("returns correct result with positive and negative numbers as parameters", function(){
            let result = mathEnforcer.sum(44, -2);
            assert.equal(result, 42, "The function did not return correct result!");
        });
        it("returns correct result with floating-point numbers parameter", function(){
            expect(mathEnforcer.sum(20.9, 21.2)).to.be.closeTo(42.1, 0.1);
        });  
        it("returns correct result with floating-point number and positive number as parameters", function(){
            expect(mathEnforcer.sum(1.1, 1)).to.be.closeTo(2.1, 0.1);
        }); 
        it("returns correct result with floating-point number and negative number as parameters", function(){
            expect(mathEnforcer.sum(1.1, -1)).to.be.closeTo(0.1, 0.1);
        });     
    });
});