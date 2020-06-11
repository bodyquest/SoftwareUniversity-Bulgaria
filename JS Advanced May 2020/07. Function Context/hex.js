class Hex {
    constructor(value) {
        this.value = value;
    }

    valueOf() {
        return this.value;
    }

    toString(){
        return "0x" + (this.value).toString(16).toUpperCase();
    }

    /**
     * Add to current value
     * @param {Hex} hex Hex number to add to current
     */
    plus(hex){
        const newHex = new Hex(this.value + hex);
        return newHex;
    }

    /**
     * Subtract from current value
     * @param {Hex} hex Hex number to subtract
     */
    minus(hex){
        const newHex = new Hex(this.value - hex);
        return newHex;
    }

    static parse(hexValue){
        return Number(parseInt(hexValue, 16));
    }
}

let FF = new Hex(255);
FF.valueOf() + 1 == 256;
let a = new Hex(10);
let b = new Hex(5);
console.log(a.plus(b).toString());
console.log(a.plus(b).toString() === "0xF");



