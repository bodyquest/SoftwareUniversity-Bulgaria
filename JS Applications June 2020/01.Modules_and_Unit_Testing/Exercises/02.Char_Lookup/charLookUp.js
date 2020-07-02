function lookupChar(string, index) {
    if (typeof(string) !== 'string' || !Number.isInteger(index)) {
        return undefined;
    }
    if (string.length <= index || index < 0) {
        return "Incorrect index";
    }

    return string.charAt(index);
}

const expect = require("chai").expect;

describe("Main functionality", () => {
    const testString = "Prasemir Butonoskov";
    describe("Invalid Parameters", () => {

        it("returns undefined for non-string first parameter", function () {
            expect(lookupChar(null, 0)).to.equal(undefined);
        });
    
        it("returns undefined for non-number second parameter", function () {
            expect(lookupChar(testString, "")).to.equal(undefined);
        });

        it("returns undefined for non-integer second parameter", function () {
            expect(lookupChar(testString, 2.71828)).to.equal(undefined);
        });
    });
    
    describe("Out of range", () => {

        it("returns 'Incorrect index' for invalid index", function () {
            expect(lookupChar(testString, -1)).to.equal("Incorrect index");
        });

        it("returns 'Incorrect index' for invalid index", function () {
            expect(lookupChar(testString, 20)).to.equal("Incorrect index");
        });
    });

    describe("Correct behaviour", () => {

        it("returns 'B'", function () {
            expect(lookupChar(testString, 9)).to.equal("B");
        });

        it("returns 'P", function () {
            expect(lookupChar(testString, 0)).to.equal("P");
        });
    });
});