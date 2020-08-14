import notifications from '../js/notifications.js';

function host(endpoint){
    return `https://api.backendless.com/B9541244-CF36-4523-FF68-CFDE66DBAD00/281080A1-C724-4A8A-93B7-F23110E208DC/${endpoint}`
}

const endpoints = {
    register: "users/register",
    login: "users/login",
    logout: "users/logout"
    // movies: "data/movies",
    // movie: "data/movies/",
    // movies_by_owner: "data/movies?where=ownerId%3D"
}

/// *** user functions *** ///
export async function registerPost (username, password) {

    const result = (await fetch(host(endpoints.register), {
        method: "POST",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify({
            username,
            password
        })
    })).json();

    return result;
}

export async function loginPost (username, password) {

    const result = await (await fetch(host(endpoints.login), {
        method: "POST",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify({
            login: username,
            password
        })
    })).json();

    localStorage.setItem("userToken", result["user-token"]);
    localStorage.setItem("username", result.username);
    localStorage.setItem("userId", result.objectId);

    return result;
}

export async function logout () {

    const token = localStorage.getItem("userToken");

    localStorage.removeItem("userToken");
    const result = fetch(host(endpoints.logout), {
        headers: {
            "user-token": token
        }
    });

    return result;
}