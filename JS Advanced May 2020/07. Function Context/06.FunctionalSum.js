function add(a){
    function sum(b) {
        a += b;
        return sum;
    }

    sum.toString = () => a;

    return sum;
}

console.log(add(1)(6)(-3).toString());

function addPrim(x){
    if (!add.hasOwnProperty("value")) {
        add.value = 0;
    }

    add.value += x;
    add.toString = () => add.value;

    return add;
}
