function getFibonator(){
    let previous = 0;
    let current = 1;

    function fibo () {
        let newNum = previous + current;
        previous = current;
        current = newNum;

        return previous;
    };

    return fibo;
}

let fib = getFibonator();

console.log(fib());
console.log(fib());
console.log(fib());
console.log(fib());
console.log(fib());
console.log(fib());
console.log(fib());
