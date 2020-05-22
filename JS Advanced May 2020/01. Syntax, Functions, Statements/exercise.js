// 1. Fruit - how much money you need to buy a fruit
function moneyNeeded(fruit, weight, cost){
    let weightInKg = weight/1000;
    let totalAmount = cost * weightInKg;
    let result = "I need $" 
    + totalAmount.toFixed(2)
    + " to buy " 
    + weightInKg.toFixed(2) 
    + " kilograms " 
    + fruit
    + ".";

    console.log(result);
}

moneyNeeded("orange", 2500, 1.80);
moneyNeeded("apple", 1563, 2.35);

// 2. Greatest Common Divisor 
function gcd(x, y) {
    x = Math.abs(x);
    y = Math.abs(y);

    while(y) {
      var t = y;
      y = x % y;
      x = t;
    }

    return x;
  }
  
  console.log(gcd(12, 13));
  console.log(gcd(9, 3));

  // 3. Same Numbers
  function validateSameNumbers(num){
    const array = [];
    let result = Boolean;

    while (num > 0) {
        array.push(num % 10);
        num = Math.floor(num / 10);
    }

    let sum = 0;
    array.forEach(element => {
        sum += element;
    });

    for (let i = 0; i < array.length - 1; i++) {
        if (array[i] === array[i + 1]) {
            continue;
        }
        else{
            result = false;
        }
        
    }

    if (result === false) {
        console.log("false")
    }
    else{
        console.log("true");
    }

    console.log(sum)
  }

  validateSameNumbers(2222222);
  validateSameNumbers(1234);

  // 4. Time to Walk
function timeToWalk(steps, strideLength, speed){

    let speedInMetersPerSecond = Number(speed) / 3.6;
    let distance = Number(steps) * Number(strideLength);
    let stridesPerSecond = speedInMetersPerSecond / Number(strideLength);
    let timeInSeconds = distance / speedInMetersPerSecond;

    let restTime = Math.floor(distance / 500);
    timeInSeconds += restTime  * 60;

    let hours = Math.floor(timeInSeconds / 3600);
    timeInSeconds %= 3600;
    let minutes = Math.floor(timeInSeconds / 60);
    timeInSeconds %= 60;
    timeInSeconds = Math.round(timeInSeconds);


    var hoursResult = hours < 10 ? "0" + hours : hours;
    var minutesResult = minutes < 10 ? "0"+ minutes : minutes;
    var secondsResult = timeInSeconds < 10 ? "0"+ timeInSeconds : timeInSeconds;

    var result = hoursResult 
    + ":" 
    + minutesResult
    + ":"
    + timeInSeconds;

    console.log(result);
}

timeToWalk(4000, 0.6, 5);
timeToWalk(2564, 0.7, 5.5);

// 8. * Calorie Object
function getObjectsWithCalories(array){
    let result = [];
    

    for (let i = 0; i < array.length; i++) {
        const element = array[i];
        let obj = {};

            if (i % 2 == 0) {
                obj.product = element;
                result.push(obj);
            }
    }

    let stringResult = [];
    for (let i = 0; i < result.length; i++) {

        let obj = result[i];
        let element = array[i * 2 + 1];
        obj.calories = Number(element);
        
        stringResult.push(`${obj.product + ": " + obj.calories}`);
    }

    console.log(`{ ${stringResult.join(", ")} }`);
}

getObjectsWithCalories(['Yoghurt', 48, 'Rise', 138, 'Apple', 52]);

// 5. Road Radar
function validateSpeed(input) {
    let speed = input[0];
    let area = input[1];

    switch (area) {
        case "motorway": 
        if (speed <= 130) {
            break;
        }
        else if (speed <= 130 + 20) {
            console.log("speeding");
        }
        else if (speed <= 130 + 40) {
            console.log("excessive speeding");
        } else {
            console.log("reckless driving");
        }
        break;

        case "interstate": 
        if (speed <= 90) {
            break;
        }
        else if (speed <= 90 + 20) {
            console.log("speeding");
        } else if (speed <= 90 + 40){
            console.log("excessive speeding");
        }
        else{
            console.log("reckless driving");
        }
        break;
    
        case "city": 
        if (speed <= 50) {
            break;
        }
        else if (speed <= 50 + 20) {
            console.log("speeding");
        } else if (speed <= 50 + 40){
            console.log("excessive speeding");
        }
        else{
            console.log("reckless driving");
        }
        break;

        case "residential": 
        if (speed <= 20) {
            break;
        }
        else if (speed <= 20 + 20) {
            console.log("speeding");
        } else if (speed <= 20 + 40){
            console.log("excessive speeding");
        }
        else{
            console.log("reckless driving");
        }
        break;

        default:
            break;
    }
}

validateSpeed([40, "city"]);
validateSpeed([21, "residential"]);
validateSpeed([120, "interstate"]);
validateSpeed([200, "motorway"]);

// 6. Cooking by Numbers
function cookByNumbers(input) {
    let num = parseInt(input[0]);

    for (let i = 1; i < input.length; i++) {
        const action = input[i];

        switch (action) {
            case "chop":
                num /= 2;
                console.log(num);
                break;

            case "dice":
                num = Math.sqrt(num)
                console.log(num);
                break;

            case "spice":
                num += 1
                console.log(num);
                break;

            case "bake":
                num *= 3;
                console.log(num);
                break;

            case "fillet":
                num -= num * 0.2;
                console.log(num);
                break;

            default:
                break;
        }
    }
}

cookByNumbers(['32', 'chop', 'chop', 'chop', 'chop', 'chop']);
cookByNumbers(["9", "dice", "spice", "chop", "bake", "fillet"]);

// 7. Validity Checker
function checker(coordinates) {
    let x1 = coordinates[0];
    let y1 = coordinates[1];
    let x2 = coordinates[2];
    let y2 = coordinates[3];

    let distance1 = Math.sqrt(x1**2 + y1**2);
    let distance2 = Math.sqrt(x2**2 + y2**2);
    let distance3 = Math.sqrt(Math.abs(x1 - x2) 
        * Math.abs(x1 - x2)
        + Math.abs(y1 - y2)
        * Math.abs(y1 - y2));

    if (Number.isInteger(distance1)) {
        console.log(`{${x1}, ${y1}} to {0, 0} is valid`);
    } else {
        console.log(`{${x1}, ${y1}} to {0, 0} is invalid`);
    }

    if (Number.isInteger(distance2)) {
        console.log(`{${x2}, ${y2}} to {0, 0} is valid`);
    } else {
        console.log(`{${x2}, ${y2}} to {0, 0} is invalid`);
    }

    if (Number.isInteger(distance3)) {
        console.log(`{${x1}, ${y1}} to {${x2}, ${y2}} is valid`);
    } else {
        console.log(`{${x1}, ${y1}} to {${x2}, ${y2}} is invalid`);
    }
}

checker ([3, 0, 0, 4])
checker ([2, 1, 1, 1])

// 9. * Coffee Machine

