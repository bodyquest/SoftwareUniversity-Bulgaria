function host(endpoint){
    return `https://api.backendless.com/B9541244-CF36-4523-FF68-CFDE66DBAD00/281080A1-C724-4A8A-93B7-F23110E208DC/${endpoint}`
}

const endpoints = {
    register: "users/register",
    login: "users/login",
    logout: "users/logout",
    movies: "data/movies",
    movie: "data/movies/",
    MOVIES_BY_OWNER: "data/movies?where=ownerId%3D"
}

/// *** user functions *** ///
export async function registerPost (username, password) {
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
    return fetch(host(endpoints.logout), {
        headers: {
            "user-token": token
        }
    });
}

/// *** movie functions *** ///
// get all movies
export async function getMovies(){
    const token = localStorage.getItem("userToken");

    return (await fetch(host(endpoints.movies), {
        headers: {
            "user-token": token,
        }
    })).json();
}

// get movie details
export async function getMovieById(id){
    const token = localStorage.getItem("userToken");

    return (await fetch(host(endpoints.movie + id), {
        method: "GET",
        headers: {
            "user-token": token,
        }
    })).json();
}

// create movie
export async function createMovie(movie){
    const token = localStorage.getItem("userToken");

    return (await fetch(host(endpoints.movies), {
        method: "POST",
        headers: {
            "Content-Type": "application/json",
            "user-token": token,
        },
        body: JSON.stringify(movie)
    })).json();
}

// edit movie
export async function updateMovie(id, updatedProperties){
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
export async function deleteMovie(id){
    const token = localStorage.getItem("userToken");

    return (await fetch(host(endpoints.movie + id), {
        method: "DELETE",
        headers: {
            "Content-Type": "application/json",
            "user-token": token,
        }
    })).json();
}

// get movies by userId
export async function getMoviesByOwner(ownerId){
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
export async function buyTicket(movie){

    const newTicketCount = movie.tickets - 1;
    const movieId = movie.objectId;

    return updateMovie(movieId, {tickets: newTickets});
}
