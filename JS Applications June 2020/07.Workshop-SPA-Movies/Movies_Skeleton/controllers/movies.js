import {createMovie, updateMovie, getMovies, buyTicket as apiBuyTicket, getMoviesByOwner, getMovieById, deleteMovie} from "../js/data.js";
import notifications from '../js/notifications.js';

export default {
    get: {
        async catalog(context){
            context.partials = {
                header: await this.load("../templates/common/header.hbs"),
                footer: await this.load("../templates/common/footer.hbs"),
                movie: await this.load("../templates/movie/movie.hbs")
            };

            const movies = await getMovies();
            context.app.userData.movies = movies;

            const info = Object.assign({origin: encodeURIComponent("#/movies")}, context.app.userData);

            this.partial("../templates/movie/catalog.hbs", info);
        },
        async myMovies(context){
            context.partials = {
                header: await this.load("../templates/common/header.hbs"),
                footer: await this.load("../templates/common/footer.hbs"),
                movie: await this.load("../templates/movie/movie.hbs"),
                ownMovie: await this.load("../templates/movie/ownMovie.hbs")
            };

            const movies = await getMoviesByOwner();
            
            context.app.userData.movies = movies;
            const info = Object.assign({myMovies: true, origin: encodeURIComponent("#/mymovies")}, context.app.userData)

            this.partial("../templates/movie/catalog.hbs", info);
        },
        async create(context){
            context.partials = {
                header: await this.load("../templates/common/header.hbs"),
                footer: await this.load("../templates/common/footer.hbs")
            };

            this.partial("../templates/movie/create.hbs", context.app.userData);
        },
        async edit(context){
            const {id} = context.params;

            context.partials = {
                header: await this.load("../templates/common/header.hbs"),
                footer: await this.load("../templates/common/footer.hbs")
            };

            let movie = context.app.userData.movies.find(m => m.objectId == id);

            if (movie === undefined) {
                movie = await getMovieById(id);
            }

            const info = Object.assign({movie}, context.app.userData);

            this.partial("../templates/movie/edit.hbs", info);
        },
        async details(context){
            context.partials = {
                header: await this.load("../templates/common/header.hbs"),
                footer: await this.load("../templates/common/footer.hbs")
            };

            const movieId = context.params.id;
            let movie = context.app.userData.movies.find(m => m.objectId == movieId);

            if (movie === undefined) {
                movie = await getMovieById(movieId);
            }

            const info = Object.assign({movie, origin: encodeURIComponent("#/details/" + movieId)}, context.app.userData);

            this.partial("../templates/movie/details.hbs", info);
        },
        async delete(context){
            if(confirm("Are you sure you want to delete the movie?") == false){
                this.redirect("#/mymovies");
            };
            const movieId = context.params.id;

            let movie = context.app.userData.movies.find(m => m.objectId == movieId);
            
            if (movie === undefined) {
                movie = await getMovieById(movieId);
            }

            try {
                const result = await deleteMovie(movieId);
                    
                if (result.hasOwnProperty("errorData")) {

                    const error = new Error();
                    Object.assign(error, result);
                    throw error;
                }
                
                notifications.showInfo(`Successfully deleted movie ${movie.title}!`);
                this.redirect("#/mymovies");
                
            } catch (e) {
                notifications.showError(e.message);
            }
        },
        async buyTicket(context){
            const movieId = context.params.id;

            let movie = context.app.userData.movies.find(m => m.objectId == movieId);
            
            if (movie === undefined) {
                movie = await getMovieById(movieId);
            }

            if (movie.tickets === 0) {
                notifications.showError("Tickets sold out. Cannot buy a ticket!");
                return;
            }
            try {
                const result = await apiBuyTicket(movie);
                    
                if (result.hasOwnProperty("errorData")) {

                    const error = new Error();
                    Object.assign(error, result);
                    throw error;
                }
                
                notifications.showInfo(`Successfully bought a ticket for ${movie.title}!`);
                this.redirect(context.params.origin);
                
            } catch (e) {
                notifications.showError(e.message);
            }
        }
    },

    post: {
        async create(){
            const { title, description, imageUrl, genres, tickets } = this.params;

            try {
                if (title.length === 0) {
                    notifications.showError("Title is required");
                    return;
                }

                const movie = {
                    title: title,
                    description: description,
                    image: imageUrl,
                    genres: genres,
                    tickets: Number(tickets)
                }
                
                const result = await createMovie(movie);
                    
                if (result.hasOwnProperty("errorData")) {

                    const error = new Error();
                    Object.assign(error, result);
                    throw error;
                }
                
                notifications.showInfo('Movie created!');
                this.redirect("#/details/" + result.objectId);
                
            } catch (e) {
                notifications.showError(e.message)
            }

        },
        async edit(){
            const movieId = this.params.id;
            const { title, description, imageUrl, genres, tickets } = this.params;

            try {
                if (title.length === 0) {
                    throw new Error('Title is required');
                }
        
                const movie = {
                    title: title,
                    description: description,
                    image: imageUrl,
                    genres: genres,
                    tickets: Number(tickets)
                }

                const result = await updateMovie(movieId, movie);

                if (result.hasOwnProperty('errorData')) {
                    const error = new Error();
                    Object.assign(error, result);
                    throw error;
                }

                for (let i = 0; i < this.app.userData.movies.length; i++) {
                    if (this.app.userData.movies[i].objectId == movieId) {
                        this.app.userData.movies.splice(i, 1);
                    }
                }

                notifications.showInfo("Movie edited");
                this.redirect("#/details/" + result.objectId)

            } catch (e) {
                notifications.showError(e.message);
            }
            
        }
    }
};