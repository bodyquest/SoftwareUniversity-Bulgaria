function host(endpoint){
    return `https://api.backendless.com/B9541244-CF36-4523-FF68-CFDE66DBAD00/281080A1-C724-4A8A-93B7-F23110E208DC/${endpoint}`
}

const endpoints = {
    REGISTER: "users/register",
    LOGIN: "users/login",
    LOGOUT: "users/logout"

}

async function register (username, password) {
    return (await fetch(host(endpoints.REGISTER), {
        method: "POST",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify({
            username,
            password
        })
    })).json();
}

async function login (username, password) {
    return (await fetch(host(endpoints.LOGIN), {
        method: "POST",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify({
            login: username,
            password
        })
    })).json();
}

function logout () {
    const token = localStorage.getItem("userToken");

    return fetch(host(endpoints.LOGOUT), {
        headers: {
            "user-token": token
        }
    });
}