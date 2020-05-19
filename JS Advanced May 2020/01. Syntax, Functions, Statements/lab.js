// 1. String Length
function solve(str1, str2, str3){
    let sumLength;
    let avgLength;

    let firstArg = str1.length;
    let secondArg = str2.length;
    let thirdArg = str3.length;

    sumLength = firstArg + secondArg + thirdArg;
    avgLength = Math.floor(sumLength/3);

    console.log(sumLength);
    console.log(avgLength);
}

solve("dari", "rosi", "radi");

// 2. Math Operations
function calculate(num1, num2, operator){
    const cases = {
        "+": (a, b) => a + b,
        "-": (a, b) => a - b,
        "*": (a, b) => a * b,
        "/": (a, b) => a / b,
        "%": (a, b) => a % b,
        "**": (a, b) => a ** b,
    }

    console.log(cases[operator](num1, num2));
}

calculate(2, 3, "/");

// 3. Sum of Numbers N...M
function sumAll(n, m){
    let num1 = Number(n);
    let num2 = Number(m);
    let result = 0;

    for (let i = num1; i <= num2; i++) {
        result += i;
    }

    console.log(result);
}

sumAll(1, 10);

// 4. Largest Number
function largestNum(){
    const args = Array.from(arguments);
    let maxNum = args[0];

    for (let i = 0; i < args.length; i++) {
        if (maxNum < args[i]) {
            maxNum = args[i];
        }
    }
    
    console.log("The largest number is " + maxNum + ".");
}

largestNum(1, 100, 3, 18);

// 5. Circle Area
function circleArea(arg){
    let type = typeof(arg);
    if (type === "number") {
        console.log((Math.PI * (arg**arg)).toFixed(2));
    }
    else {
        console.log
        ("We can not calculate the circle area, because we receive a " + type + ".");
    }
}

circleArea(true);

// 6. Square of Stars
function printStars(num){
    let arg = num;
    let arr = [];
    if (num !== undefined) {
        print(arg);
    }
    else {
        arg = 5;
        print(arg);
    }

    function print(arg) {
        for (let i = 0; i < Number(arg); i++) {
            for (let j = 0; j < Number(arg); j++) {

                if (j + 1 === arg) {
                    arr += "*";
                    arr += "\n";
                }
                else{
                    arr += "* ";
                }
            }
        }

        console.log(String(arr));
    }
}

printStars();

//Day of Week
function dayOfWeek(weekDay){
    switch (weekDay) {
        case "Monday":
            console.log("1");
            break;
        case "Tuesday":
            console.log("2");
            break;
        case "Wednesday":
            console.log("3");
            break;
        case "Thursday":
            console.log("4");
            break;
        case "Friday":
            console.log("5");
            break;
        case "Saturday":
            console.log("6");
            break;
        case "Sunday":
            console.log("7");
            break;
    
        default:
            console.log("error");
            break;
    }
}

dayOfWeek('Monday');
dayOfWeek('Friday');
dayOfWeek('Chushki');

// 8. Aggregate Elements
function aggregate(array){
    let sum = 0;
    let sumInverseValues = 0;
    let concat = "";

    for (let i = 0; i < array.length; i++) {
        const element = array[i];
        sum += element;
        sumInverseValues += 1/element;
        concat += element;
    }

    console.log(sum);
    console.log(sumInverseValues.toFixed(4));
    console.log(concat);
}

aggregate([1, 2, 3]);

// 9. Words Uppercase
function getUpper(text) {
    let words = text.toUpperCase()
    .split(/\W+/)
    .filter(w => w != "");

    console.log(words.join(", "));
}

getUpper('Hi, how are you?');
getUpper('hello');
