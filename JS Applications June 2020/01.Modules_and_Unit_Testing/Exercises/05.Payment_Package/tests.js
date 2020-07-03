const expect = require("chai").expect;
const PaymentPackage = require("./PaymentPackage");
const validName = "Delivery Package";
const validValue = 100;

describe("Instances and architecture", function() {

    it("works with valid parameters", function () {
        expect(() => new PaymentPackage(validName, validValue)).to.not.throw();
    });

    it("is correctly set up", function () {
        const instance = new PaymentPackage(validName, validValue);
        expect(instance.name).to.equal(validName);
        expect(instance.value).to.equal(validValue);
        expect(instance.VAT).to.equal(20);
        expect(instance.active).to.equal(true);
    });

    it("dows not work with invalid parameters", function () {
        expect(() => new PaymentPackage("", validValue)).to.throw();
        expect(() => new PaymentPackage(5, validValue)).to.throw();
        expect(() => new PaymentPackage(undefined, validValue)).to.throw();expect(() => new PaymentPackage({}, validValue)).to.throw();
    });

    it("dows not work with invalid parameters", function () {
        expect(() => new PaymentPackage(validName, {})).to.throw();
        expect(() => new PaymentPackage(validName, "")).to.throw();expect(() => new PaymentPackage(validName, -1)).to.throw();
    });

    it("has all properties", () => {

        const instance = new PaymentPackage(validName, validValue);

        expect(instance).to.have.property("name");
        expect(instance).to.have.property("value");
        expect(instance).to.have.property("VAT");
        expect(instance).to.have.property("active");
    });
});

describe("validate Accessors", () => {

    let instance = null;
    beforeEach(() => {
        instance = new PaymentPackage(validName, validValue);
    });    

    it("accepts and sets a valid name", function () {

        //set
        expect(() => instance.name = "NewName").to.not.throw();

        //get
        instance.name = "NewName"
        expect(instance.name).to.equal("NewName");
    });
    it("rejects invalid name", function () {
        expect(() => instance.name = "").to.throw();
        expect(() => instance.name = {}).to.throw();
        expect(() => instance.name = undefined).to.throw();
    });

    it("accepts and sets a valid value", function () {

        //set
        expect(() => instance.value = 100).to.not.throw();

        //get
        instance.value = 100;
        expect(instance.value).to.equal(100);
    });
    it("rejects invalid value", function () {
        expect(() => instance.value = "").to.throw();
        expect(() => instance.value = {}).to.throw();
        expect(() => instance.value = undefined).to.throw();
    });

    it("accepts and sets a valid VAT", function () {

        //set
        expect(() => instance.VAT = 19).to.not.throw();

        //get
        instance.VAT = 19;
        expect(instance.VAT).to.equal(19);
    });
    it("rejects invalid VAT", function () {
        expect(() => instance.VAT = "").to.throw();
        expect(() => instance.VAT = {}).to.throw();
        expect(() => instance.VAT = undefined).to.throw();
    });

    it("accepts and sets a valid active", function () {

        //set
        expect(() => instance.active = true).to.not.throw();

        //get
        instance.active = true;
        expect(instance.active).to.equal(true);
    });
    it("rejects invalid active", function () {
        expect(() => instance.active = "").to.throw();
        expect(() => instance.active = {}).to.throw();
        expect(() => instance.active = undefined).to.throw();
    });
});

describe("validate toString()", function () {

    let instance = null;
    beforeEach(() => {
        instance = new PaymentPackage(validName, validValue);
    });

    it("contains name", () => {
        expect(instance.toString()).to.contain(validName);
    });

    it("contains value", () => {
        expect(instance.toString()).to.contain(validValue.toString());
    });

    it("contains VAT", () => {
        expect(instance.toString()).to.contain(instance.VAT + "%");
    });

    it("displays inactive label", () => {
        instance.active = false;
        expect(instance.toString()).to.contain("inactive");
    });

    it(("updates info through setters"), () => {
        instance.name = "YetNewName";
        instance.value = 110;
        instance.VAT = 15;
        instance.active = false;

        const output = instance.toString();

        expect(output).to.contain("YetNewName");
        expect(output).to.contain("110");
        expect(output).to.contain("15%");
    });
});