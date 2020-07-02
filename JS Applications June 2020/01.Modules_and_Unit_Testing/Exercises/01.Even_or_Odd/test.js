const expect = require("chai").expect;
const assert = require("chai").assert;
const isOddOrEven = require("./app.js");


describe("Main functionality", () => {
    it("returns undefined with number parameter", function() {
        let result = isOddOrEven(13)
        assert.equal(result, undefined, "Function did not return the correct result!")
    });

    it("returns undefined with boolean parameter", function() {
        let result = isOddOrEven(false)
        assert.equal(result, undefined, "Function did not return the correct result!")
    });

    it("returns undefined with object parameter", function() {
        expect(isOddOrEven({name: "George"})).to.equal(undefined, "Function did not return the correct result!")
    });

    it("returns correct with an even length", function() {
        assert.equal(isOddOrEven("Mara"), "even", "Function did not return the correct result!")
    });

    it("returns correct with an odd length", function() {
        assert.equal(isOddOrEven("Pesholin"), "odd", "Function did not return the correct result!")
    });
});
