function solve() {

    let pad = document.getElementsByClassName("keys")[0];
    const output = document.querySelector("#expressionOutput");
    let result = document.getElementById("resultOutput");
    const clear = document.querySelector(".clear");

    let operators = ["+", "-", "*", "/"];

    clear.addEventListener("click", () => {
        output.innerHTML = "";
        result.innerHTML = "";
    });

    pad.addEventListener("click", ({target: { value } }) => {
        if (!value) {
            return;
        }

        if (value === "=") {
            let params = output.innerHTML.split(" ").filter(x => x !== "");
            if (params[2] !== undefined) {
                result.innerHTML = operations[params[1]](params[0], params[2]);

                return;
            }

            result.innerHTML = "NaN";
            return;
        }

        if (operators.includes(value)) {
            output.innerHTML = output.innerHTML + ` ${value} `;
            return;
        }

        output.innerHTML = output.innerHTML + value;
    });

    const operations = {
        "+": (first, second) => Number(first) + Number(second),
        "-": (first, second) => Number(first) - Number(second),
        "*": (first, second) => Number(first) * Number(second),
        "/": (first, second) => Number(first) / Number(second),
        "=": () => true,
    }
}