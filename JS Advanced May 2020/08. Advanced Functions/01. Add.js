function solution(n) {

    return function add(x){
        return n + x;
    }
};

let test = solution(5);
console.log(test(2));
console.log(test(3));

let add7 = solution(7);
console.log(add7(2));
console.log(add7(3));