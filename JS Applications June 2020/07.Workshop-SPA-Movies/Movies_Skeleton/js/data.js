import notifications from '../js/notifications.js';

function host(endpoint){
    return `https://api.backendless.com/B9541244-CF36-4523-FF68-CFDE66DBAD00/281080A1-C724-4A8A-93B7-F23110E208DC/${endpoint}`
}

const endpoints = {
    register: "users/register",
    login: "users/login",
    logout: "users/logout",
    movies: "data/movies",
    movie: "data/movies/",
    movies_by_owner: "data/movies?where=ownerId%3D"
}

/// *** user functions *** ///
export async function registerPost (username, password) {
    notifications.beginRequest();

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

    notifications.endRequest();

    return result;
}

export async function loginPost (username, password) {
    notifications.beginRequest();
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

    notifications.endRequest();

    return result;
}

export async function logout () {
    notifications.beginRequest();

    const token = localStorage.getItem("userToken");

    localStorage.removeItem("userToken");
    const result = fetch(host(endpoints.logout), {
        headers: {
            "user-token": token
        }
    });

    notifications.endRequest();

    return result;
}

/// *** movie functions *** ///
// get all movies
export async function getMovies(search){
    notifications.beginRequest();

    const token = localStorage.getItem("userToken");
    let result;

    if (!search) {
        result = (await fetch(host(endpoints.movies), {
            headers: {
                "user-token": token,
            }
        })).json();
    }
    else{
        result = (await fetch(host(endpoints.movies + `?where=${escape(`genres LIKE '%${search}%'`)}`), {
            headers: {
                'user-token': token
            }
        })).json();
    }

    notifications.endRequest();

    return result;
}

// get movie details
export async function getMovieById(id){
    notifications.beginRequest();

    const token = localStorage.getItem("userToken");

    const result = (await fetch(host(endpoints.movie + id), {
        method: "GET",
        headers: {
            "user-token": token,
        }
    })).json();

    notifications.endRequest();

    return result;
}

// create movie
export async function createMovie(movie){
    notifications.beginRequest();

    const token = localStorage.getItem("userToken");

    const result = (await fetch(host(endpoints.movies), {
        method: "POST",
        headers: {
            "Content-Type": "application/json",
            "user-token": token,
        },
        body: JSON.stringify(movie)
    })).json();

    notifications.endRequest();

    return result;
}

// edit movie
export async function updateMovie(id, updatedProperties){
    notifications.beginRequest();

    const token = localStorage.getItem("userToken");

    const result = (await fetch(host(endpoints.movie + id), {
        method: "PUT",
        headers: {
            "Content-Type": "application/json",
            "user-token": token,
        },
        body: JSON.stringify(updatedProperties)
    })).json();

    notifications.endRequest();

    return result;
}

// delete movie
export async function deleteMovie(id){
    notifications.beginRequest();

    const token = localStorage.getItem("userToken");

    const result = (await fetch(host(endpoints.movie + id), {
        method: "DELETE",
        headers: {
            "Content-Type": "application/json",
            "user-token": token,
        }
    })).json();

    notifications.endRequest();

    return result;
}

// get movies by userId
export async function getMoviesByOwner(){
    notifications.beginRequest();

    const token = localStorage.getItem("userToken");
    const ownerId = localStorage.getItem("userId");

    const movies = await (await fetch(host(endpoints.movies_by_owner + `%27${ownerId}%27`), {
        method: "GET",
        headers: {
            "user-token": token,
        }
    })).json();

    notifications.endRequest();

    return movies;
}

// buy ticket for movie
export async function buyTicket(movie){

    const newTicketCount = movie.tickets - 1 < 0 ? movie.tickets : movie.tickets-1;
    const movieId = movie.objectId;

    return updateMovie(movieId, {tickets: newTicketCount});
}
