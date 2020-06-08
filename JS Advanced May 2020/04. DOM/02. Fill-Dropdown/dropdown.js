function addItem() {
    // get references
    const textInput = document.querySelector("#newItemText"); 
    const valueInput = document.querySelector("#newItemValue"); 
    let text = textInput.value;
    let value = valueInput.value;

    const option = document.createElement("option");

    //configure 
    option.textContent = text;
    option.value = value;

    document.querySelector("#menu").appendChild(option);

    // make the fields empty 
    textInput.value = "";
    valueInput.value = "";
}