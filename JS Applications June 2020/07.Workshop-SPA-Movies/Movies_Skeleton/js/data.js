function host(endpoint){
    return `https://api.backendless.com/B9541244-CF36-4523-FF68-CFDE66DBAD00/281080A1-C724-4A8A-93B7-F23110E208DC/${endpoint}`
}

const endpoints = {
    REGISTER: "users/register",
    LOGIN: "users/login",
    LOGOUT: "users/logout",
    MOVIES: "data/movies",
    MOVIE: "data/movies/",
    MOVIES_BY_OWNER: "data/movies?where=ownerId%3D"
}

/// *** user functions *** ///
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
    const result = await (await fetch(host(endpoints.LOGIN), {
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

function logout () {
    const token = localStorage.getItem("userToken");

    return fetch(host(endpoints.LOGOUT), {
        headers: {
            "user-token": token
        }
    });
}

/// *** movie functions *** ///
// get all movies
async function getMovies(){
    const token = localStorage.getItem("userToken");

    return (await fetch(host(endpoints.MOVIES), {
        headers: {
            "user-token": token,
        }
    })).json();
}

// get movie details
async function getMovieById(id){
    const token = localStorage.getItem("userToken");

    return (await fetch(host(endpoints.MOVIE + id), {
        method: "GET",
        headers: {
            "user-token": token,
        }
    })).json();
}

// create movie
async function createMovie(movie){
    const token = localStorage.getItem("userToken");

    return (await fetch(host(endpoints.MOVIES), {
        method: "POST",
        headers: {
            "Content-Type": "application/json",
            "user-token": token,
        },
        body: JSON.stringify(movie)
    })).json();
}

// edit movie
async function updateMovie(id, updatedProperties){
    const token = localStorage.getItem("userToken");

    return (await fetch(host(endpoints.MOVIE + id), {
        method: "PUT",
        headers: {
            "Content-Type": "application/json",
            "user-token": token,
        },
        body: JSON.stringify(updatedProperties)
    })).json();
}

// delete movie
async function deleteMovie(id){
    const token = localStorage.getItem("userToken");

    return (await fetch(host(endpoints.MOVIE + id), {
        method: "DELETE",
        headers: {
            "Content-Type": "application/json",
            "user-token": token,
        }
    })).json();
}

// get movies by userId
async function getMoviesByOwner(ownerId){
    const token = localStorage.getItem("userToken");

    const movies = await (await fetch(host(endpoints.MOVIES_BY_OWNER + `%27${ownerId}%27`), {
        method: "GET",
        headers: {
            "user-token": token,
        }
    })).json();

    return movies;
}

// buy ticket for movie
async function buyTicket(){
    
}
