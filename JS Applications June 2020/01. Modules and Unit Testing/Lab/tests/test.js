const assert = require("chai").assert;

describe("Array", function(){
    describe("method indexOf", function(){
        it("if not found, should return -1", function(){
            let arr = [1, 2, 3, 4];
            let result = arr.indexOf(9);

            assert.equal(result, -1);
        });
    });
});