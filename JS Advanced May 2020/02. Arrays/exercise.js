// 1. Print an Array with Given Delimiter
function print (input){
    let delimiter = input[input.length-1];
    let array = input.slice(0, input.length - 1);

    console.log(array.join(delimiter));
}

print(
['One', 
'Two', 
'Three', 
'Four', 
'Five', 
'-']
);
// 2. Print Every N-th Element from an Array
function printN (input) {
    let step = (Number)(input.pop());
    let arrayOfElement = input.slice();

    let array = arrayOfElement.reduce((acc, element, i) => {
        if (i % step === 0) {
            acc.push(element);
        }

        return acc;
    }, [])

    console.log(array.join("\n"));
}

printN(
['5', 
'20', 
'31', 
'4', 
'20', 
'2']
);

// 3. Add and Remove Elements from an Arry
function mutate(input) {
    let initialValue = 1;
    const myArray = [];

    for (let i = 0; i < input.length; i++) {
        const element = input[i];
        
        if (element === "add") {
            myArray.push(initialValue);
        }
        else if (element === "remove") {
            myArray.pop();
        }

        initialValue++;
    }

    if (myArray.some(x => myArray.length > 0)) {
        myArray.forEach(item => console.log(item));
    }
    else{
        console.log("Empty");
    }
}

mutate(['add', 'add', 'add', 'add']);
mutate(['add', 'add', 'remove', 'add', 'add']);
mutate(['remove', 'remove', 'remove']);

// 4. Rotate Array
function rotate(input) {
    let count = Number(input.pop());

    for (let i = 0; i < count % input.length; i++) {
        const element = input.pop();
        input.unshift(element);
    }

    console.log(input.join(" "));
}

rotate(['1', '2', '3', '4', '2']);
rotate(['Banana', 'Orange', 'Coconut', 'Apple', '15']);

// 5. Extract Increasing Subsequence of an Array
function extract(input) {
    let result = input.filter((v, i) => v >= Math.max(null, ...input.slice(0,i)))

    console.log(result.join("\n"));
}

extract([1, 3, 8, 4, 10, 12, 3, 2, 24]);
extract([1, 2, 3, 4]);
extract([20, 3, 2, 15, 6, 1]);

// 6. Sort an Array by 2 Criteria
function sortBy2(input = []) {

    const newArr = input
        .sort()
        .sort((firstName, secondName) => 
            firstName.length - secondName.length ||
            firstName.localeCompare(secondName));

    console.log(newArr.join("\n"));
}

sortBy2(['alpha', 'beta', 'gamma']);
sortBy2(['Isacc', 'Theodor', 'Jack', 'Harrison', 'George']);
sortBy2(['test', 'Deny', 'omen', 'Default']);

// 7. Magic Matrices
function validateMagicMatrix(input = []) {

    let arr = [];

    for (let i in input) {

        const rowSum = input[i].reduce((a, b) => a + b, 0);
        const colSum = input.reduce((acc, curr) => {
            acc += curr[i];
            return acc;
        }, 0);
        if (rowSum !== colSum 
            || (arr.length > 0 
                && (rowSum !== arr[0] 
                || colSum !== arr[1]))) {
            return false;
        }
        else if(i === "0"){
            arr.push(rowSum, colSum);
        }
    }
    return true;
}

console.log(validateMagicMatrix([[4, 5, 6], [6, 5, 4], [5, 5, 5]]));
console.log(validateMagicMatrix([[11, 32, 45], [21, 0, 1],[21, 1, 1]]));
console.log(validateMagicMatrix([[1, 0, 0], [0, 0, 1], [0, 1, 0]]));


// 8. Тic-Tac-Toe
function Tictac (input) {
    
}

Tictac(["0 1", "0 0", "0 2", "2 0", "1 0", "1 1", "1 2", "2 2", "2 1", "0 0"]);

// 9. Diagonal Attack



// 10. Orbit