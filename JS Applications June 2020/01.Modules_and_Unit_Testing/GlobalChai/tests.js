let sum = require("./functionality");
const assert = require("chai").assert;

describe("test result", () => {
    it("should return 3", () => {
        assert.equal(sum(1, 2), 3, "Not equal")
    });
});