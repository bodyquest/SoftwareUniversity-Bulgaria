let sum = require('./../JS/js');
let assert = require("chai").assert;
let expect = require("chai").expect;

describe("sum() behavior", () => {
    it("check the return result", () => {
        let result = sum (5, 37);

        assert.equal(result, 42, "The result should be 42");
    });

    it("check the return result", () => {
        let result = sum (5, 10);

        expect(result).to.equal(15, "The result should be 15");
    });

    it("check the arguments types", () => {
        let result = sum (5, 10);

        assert.typeOf(result, "Number", "The result should be number");
    });
});
