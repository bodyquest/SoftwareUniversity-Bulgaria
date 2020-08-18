//EXAM APP
const appID = "C34551B7-0AB7-EC8F-FF67-B15973859600";
const restAPI = "43D34BEB-D92B-4809-B344-C4BFF604D1C6";

function host(endpoint){
    return `https://api.backendless.com/${appID}/${restAPI}/${endpoint}`
}

const endpoints = {
    login: "users/login",
    register: "users/register",
    logout: "users/logout",

    shoes: "data/shoes",
    shoe_by_id: 'data/shoes/',
} 

/// *** user functions *** ///
export async function registerPost (email, password) {

    const result = (await fetch(host(endpoints.register), {
        method: "POST",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify({
            email,
            password
        })
    })).json();

    return result;
}

export async function loginPost (email, password) {

    const result = await (await fetch(host(endpoints.login), {
        method: "POST",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify({
            login: email,
            password
        })
    })).json();

    sessionStorage.setItem("userToken", result["user-token"]);
    sessionStorage.setItem("email", result.email);
    sessionStorage.setItem("userId", result.objectId);

    return result;
}

export async function logout () {

    const token = sessionStorage.getItem("userToken");

    const result = fetch(host(endpoints.logout), {
        headers: {
            "user-token": token
        }
    });

    sessionStorage.removeItem("userToken");
    sessionStorage.removeItem("email", result.email);
    sessionStorage.removeItem("userId", result.objectId);

    return result;
}

/// *** shoes functions *** ///
export async function getAllShoes(){
    const token = sessionStorage.getItem("userToken");

    return (await fetch(host(endpoints.shoes), {
        headers: {
            "user-token": token,
        }
    })).json()
}

export async function getShoeById(shoeId){
    const token = sessionStorage.getItem("userToken");

    const result = (await fetch(host(endpoints.shoe_by_id + shoeId), {
        method: "GET",
        headers: {
            "user-token": token,
        }
    })).json();

    return result;
}

export async function createShoe(shoe){
    const token = sessionStorage.getItem("userToken");

    const result = (await fetch(host(endpoints.shoes), {
        method: "POST",
        headers: {
            "Content-Type": "application/json",
            "user-token": token,
        },
        body: JSON.stringify(shoe)
    })).json();
    
    return result;
}

export async function editShoe(shoeId, shoe){
    const token = sessionStorage.getItem("userToken");

    const result = (await fetch(host(endpoints.shoe_by_id + shoeId), {
        method: "PUT",
        headers: {
            "Content-Type": "application/json",
            "user-token": token,
        },
        body: JSON.stringify(shoe)
    })).json();

    return result;
}

export async function deleteShoe(shoeId){
    const token = sessionStorage.getItem("userToken");

    const result = (await fetch(host(endpoints.shoe_by_id + shoeId), {
        method: "DELETE",
        headers: {
            "Content-Type": "application/json",
            "user-token": token,
        }
    })).json();

    return result;
}

export async function buyShoe(shoeId){
    const token = sessionStorage.getItem("userToken");
    const userId = sessionStorage.getItem("userId");

    const shoe = await getShoeById(shoeId);
    if (shoe.ownerId !== userId && !shoe.buyers) {
        shoe.buyers = JSON.stringify([userId]);
    }
    else if (shoe.ownerId !== userId && !shoe.buyers.includes(userId)) {
        shoe.buyersCount += 1;
        shoe.buyers.push(userId);
    }

    const result = (await fetch(host(endpoints.shoe_by_id + shoeId), {
        method: "PUT",
        headers: {
            "Content-Type": "application/json",
            "user-token": token,
        },
        body: JSON.stringify(shoe)
    })).json();

    return result;
}

export async function userBought(shoeId, userId) {
    const shoe = await getShoeById(shoeId);
    if (shoe.buyers){
        return shoe.buyers.includes(userId);
    }
    return false;
}
