function toggle() {

    // find reference
    const div = document.querySelector("#extra");
    const btn = document.getElementsByClassName("button")[0];

    // find property and change it
    if (div.style.display === "block") {
        btn.textContent = "More";
        div.style.display = "none";
    }else{
        btn.textContent = "Less";
        div.style.display = "block";
    }
}