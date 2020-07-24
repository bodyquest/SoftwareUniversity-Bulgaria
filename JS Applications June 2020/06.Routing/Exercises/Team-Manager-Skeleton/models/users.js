
function host(endpoint) {
    return `https://api.backendless.com/C37FA95F-0D6A-9940-FF9B-AAABADC18D00/438AA7CE-7E50-4CA0-B6E7-6EEE19783B2E/${endpoint}`;
}

const endpoints = {
    register: `users/register`,
    login: `users/login`,
    logout: `users/logout`,
    user: `data/Users`
}

export default {
    async login(username, password){

        return (await fetch(host(endpoints.login), {
            method: "POST",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify({
                login: username,
                password
            })
        })).json();
     },

    async register(username, password){
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

    async logout()
    {
        return (await fetch(host(endpoints.logout), {
            headers: {
                "user-token": `${localStorage["user-token"]}`
            }
        }));
    },

    async getUserById(){
        const userId = localStorage.getItem("userId");
        const token = localStorage.getItem("userToken");

        const uri = host(endpoints.user + `/${userId}?loadRelations=teamId`);

        let result =  await (await fetch(uri)).json();
        
        return result;
    }
};
