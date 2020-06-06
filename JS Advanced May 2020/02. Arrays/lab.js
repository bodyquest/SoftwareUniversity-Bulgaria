// 1. Sum First Last
function sumFirstAndLast(input) {
    let first = Number(input[0]);
    let last = Number(input[input.length -1]);
    let result = first + last;
    console.log(result);
}

sumFirstAndLast(["20", "30", "40"]);
sumFirstAndLast(["5", "10"]);

// 2. even Position Element
function getEvenPositionElements(input) {
    let result = [];

    for (let i = 0; i < input.length; i++) {
        const element = input[i];
        
        if (i % 2 == 0) {
            result.push(element);
        }
    }

    console.log(result.join(" "));
}

function getEvenPositionElements2(input) {
    console.log(input
        .filter((_, i) =>
        i % 2 === 0)
        .join(" "));
}

getEvenPositionElements(["20", "30", "40"]);
getEvenPositionElements(["5", "10"]);
getEvenPositionElements2(["20", "30", "40"]);
getEvenPositionElements2(["5", "10"]);

// 3. Negative/ Positive Numbers
function sortElements(input) {
    let result = [];

    input.forEach(element => {
        element < 0 ?
        result.unshift(element) :
        result.push(element);
    });

    console.log(result.join("\n"));
}

sortElements([7, -2, 8, 9]);
sortElements([3, -2, 0, -1]);

// 4. Last K Numbers Sequence
function lastK(n, k) {
    let result = [1];

    for (let i = 0; i < n; i++) {
        let currElement = result
        .slice(k * -1)
        .reduce((a, b) => a + b);
        
        result[i] = currElement;
    }

    console.log(result.join(" "));
}

lastK(6, 3);
lastK(8, 2);


// 5. Process Odd Numbers
function oddNums (input) {
    let result = input.filter((_, i) =>
    i % 2 === 1)
    .reverse()
    .map(i => i * 2)
    .join(" ");

    console.log(result);
}

oddNums([10, 15, 20, 25]);
oddNums([3, 0, 10, 4, 7, 3]);

// 6. Smallest Two Numbers
function twoSmallest(input){
    let arr = input
        .sort((a, b) => a - b)
        .slice(0, 2)
        .join(" ");
        
    console.log(arr);
}

twoSmallest([30, 15, 50, 5]);
twoSmallest([3, 0, 10, 4, 7, 3]);

// 7. Biggest Element


// 8. Diagonal Sums
function diagonalSums(input) {
    let firstDiagonalSum = 0;
    let secondDiagonalSum = 0;
    let firstIndex = 0;
    let secondIndex = input[0].length - 1;

    input.forEach(array => {
        firstDiagonalSum += array[firstIndex++];
        secondDiagonalSum += array[secondIndex--];
    });

    console.log(firstDiagonalSum + " " + secondDiagonalSum);
}

diagonalSums([[3, 5, 7], [-1, 7, 14], [1, -8, 89]]);

// 9. Equal Neighbors



