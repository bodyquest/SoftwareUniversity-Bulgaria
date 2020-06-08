function subtract() {
    let first = Number(document.getElementById("firstNumber").value);
    let second = Number(document.getElementById("secondNumber").value);

    return document.getElementById("result").textContent = 
    first - second;
}

function subtract2() {
    let elements = {
        first: document.getElementById("firstNumber").value,
        second: document.getElementById("secondNumber").value,
        result: document.querySelector("#result")
    }
    

    elements.result.textContent = (Number(elements.first.value) - Number(elements.second.value)).toString();
}