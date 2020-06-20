function solve (){

    function add(a, b){
        const result = [];

        result.push(a[0] + b[0]);
        result.push(a[1] + b[1]);
        return result;
    }

    function multiply(a, s){
        const result = [];
        result.push(a[0] * s);
        result.push(a[1] * s);
        return result;
    }

    function length(a){
        let result = 0;
        let x = a[0];
        let y = a[1];

        result = Math.sqrt(x**2 + y**2);
        return result;
    }

    function dot(a, b){
        let result = 0;

        result = (a[0] * b[0]) + (a[1] * b[1]);
        return result;
    }

    function cross(a, b){
        return a[0] * b[1] - a[1] * b[0];
    }

    return {
        add,
        multiply,
        length,
        dot,
        cross
    }
}

const vectorMath = solve();
console.log(vectorMath.add([1, 1], [1, 0]));
console.log(vectorMath.multiply([2, 1], 2));
console.log(vectorMath.length([3, -4]));
console.log(vectorMath.dot([1, 0], [0, -1]));
console.log(vectorMath.cross([2, 1], [2, 3]));