import {getNumber} from "./module.js";
import "./app.js";

describe("Main", () => {

    it("returns 5", function () {
        expect(getNumber()).to.equal(5);
    });
});

describe("Output", () => {

    it("prints 7", function () {
        const result = document.querySelector("#output").textContent;

        expect(result).to.contains("7", "Incorrect output");
    });
});