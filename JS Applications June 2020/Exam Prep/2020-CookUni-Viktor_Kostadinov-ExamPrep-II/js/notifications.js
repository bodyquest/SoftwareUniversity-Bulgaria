const elements = {
    info: document.querySelector("#successBox"),
    error: document.querySelector("#errorBox"),
    loading: document.querySelector("#loadingBox"),
};

elements.info.addEventListener("click", hideInfo);
elements.error.addEventListener("click", hideError);

export function showInfo(message) {
    elements.info.children[0].textContent = message;
    elements.info.style.display = "block";
    setTimeout(hideInfo, 3000);
}

export function showError(message) {
    elements.error.children[0].textContent = message;
    elements.error.style.display = "block";
}

let requests = 0;

export function beginRequest() {
    requests++;
    elements.loading.style.display = "block";
}

// TODO