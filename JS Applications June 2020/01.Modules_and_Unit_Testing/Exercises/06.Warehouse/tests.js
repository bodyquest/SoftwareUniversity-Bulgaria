const {
    expect
} = require("chai");

const {
    beforeEach
} = require("mocha");

const Warehouse = require('./warehouse.js');

describe('Warehouse Class Tests', () => {
    let warehouse;

    beforeEach(function () {
        warehouse = new Warehouse(28);
    });

    describe('Constructor tests', () => {
        it('Test properties', () => {
            expect(warehouse.capacity).to.equal(28);
            expect(warehouse.availableProducts).to.deep.equal({
                'Food': {},
                'Drink': {}
            });
        });

        it('Test error properties', () => {
            const result = () => new Warehouse("Error");
            expect(result).to.throw(`Invalid given warehouse space`);
        });
    });

    describe("addProduct() tests", () => {
        it('Test error', () => {
            const result = () => warehouse.addProduct("Food", "Test", 123);
            expect(result).to.throw(`There is not enough space or the warehouse is already full`);
        });

        it('Functionality test', () => {
            const result = warehouse.addProduct("Food", "Test", 28);
            expect(warehouse.availableProducts.Food["Test"]).to.equal(28);
            expect(result).to.deep.equal({
                Test: 28
            });
        });
    });

    describe("orderProduct() tests", function () {
        it("Test functionality with available products", function () {
            warehouse.addProduct("Drink", "A", 2);
            warehouse.addProduct("Drink", "B", 5);
            warehouse.addProduct("Food", "Z", 1);
            warehouse.addProduct("Food", "S", 2);

            const result = JSON.stringify(warehouse.orderProducts("Drink"));

            expect(result).to.equal(`{"B":5,"A":2}`);
        });

        it("Functionality tests without available products", function () {
            const result = JSON.stringify(warehouse.orderProducts("Drink"));
            expect(result).to.equal(`{}`);
        });
    });

    describe('occupiedCapacity() tests', () => {
        it('Test zero result', () => {
            const result = warehouse.occupiedCapacity();
            expect(result).to.equal(0);
        });

        it('Test for none-zero result', () => {
            warehouse.addProduct("Food", "Z", 1);
            warehouse.addProduct("Food", "A", 3);
            warehouse.addProduct("Drink", "B", 2);
            warehouse.addProduct("Drink", "E", 8);

            const result = warehouse.occupiedCapacity();

            expect(result).to.equal(14);
        });
    });

    describe('revision() tests', () => {
        it('Test empty output', () => {
            const result = warehouse.revision();
            expect(result).to.equal("The warehouse is empty");
        });

        it('Tests for none-empty output', () => {
            warehouse.addProduct("Food", "Z", 1);
            warehouse.addProduct("Food", "A", 3);
            warehouse.addProduct("Drink", "B", 2);
            warehouse.addProduct("Drink", "E", 8);

            const result = warehouse.revision();

            expect(result).to.equal("Product type - [Food]\n- Z 1\n- A 3\nProduct type - [Drink]\n- B 2\n- E 8");
        });
    });

    describe('scrapeAProduct() tests', () => {
        it('Test error', () => {
            const result = () => warehouse.scrapeAProduct("Error", 12);
            expect(result).to.throw(`Error do not exists`);
        });

        it('Test more expected quantity functionality', () => {
            warehouse.addProduct("Food", "Z", 1);
            warehouse.addProduct("Food", "A", 3);
            warehouse.addProduct("Drink", "B", 2);
            warehouse.addProduct("Drink", "E", 8);

            const result = warehouse.scrapeAProduct("Z", 12);

            expect(result).to.deep.equal({
                Z: 0,
                A: 3
            });
        });

        it('Test expected quantity functionality', () => {
            warehouse.addProduct("Food", "Z", 1);
            warehouse.addProduct("Food", "A", 3);
            warehouse.addProduct("Drink", "B", 2);
            warehouse.addProduct("Drink", "E", 8);

            const result = warehouse.scrapeAProduct("A", 1);

            expect(result).to.deep.equal({
                Z: 1,
                A: 2
            });
        });
    });
});