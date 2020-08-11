function host(endpoint){
    return `https://api.backendless.com/B9541244-CF36-4523-FF68-CFDE66DBAD00/281080A1-C724-4A8A-93B7-F23110E208DC/${endpoint}`
}

const endpoints = {
    register: "users/register",
    login: "users/login",
    logout: "users/logout"
}

export default {
    async register (username, password) {
        return (await fetch(host(endpoints.register), {
            method: "POST",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify({
                username,
                password
            })
        })).json();
    },
    
    async login (username, password) {
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
    },
    
    async logout () {
        const token = localStorage.getItem("userToken");
    
        return fetch(host(endpoints.logout), {
            headers: {
                "user-token": token
            }
        });
    }
}