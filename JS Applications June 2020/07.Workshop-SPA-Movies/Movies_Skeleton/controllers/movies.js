import {createMovie, updateMovie, getMovies, buyTicket as apiBuyTicket, getMoviesByOwner} from "../js/data.js";
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

            this.partial("../templates/movie/catalog.hbs", context.app.userData);
        },
        async myMovies(context){
            context.partials = {
                header: await this.load("../templates/common/header.hbs"),
                footer: await this.load("../templates/common/footer.hbs"),
                movie: await this.load("../templates/movie/movie.hbs")
            };

            const movies = await getMoviesByOwner();
            
            context.app.userData.movies = movies;

            this.partial("../templates/movie/catalog.hbs", context.app.userData);
        },
        async create(context){
            context.partials = {
                header: await this.load("../templates/common/header.hbs"),
                footer: await this.load("../templates/common/footer.hbs")
            };

            this.partial("../templates/movie/create.hbs", context.app.userData);
        },
        async edit(context){
            context.partials = {
                header: await this.load("../templates/common/header.hbs"),
                footer: await this.load("../templates/common/footer.hbs")
            };

            this.partial("../templates/movie/edit.hbs", context.app.userData);
        },
        async details(context){
            context.partials = {
                header: await this.load("../templates/common/header.hbs"),
                footer: await this.load("../templates/common/footer.hbs")
            };

            this.partial("../templates/movie/details.hbs", context.app.userData);
        },
        async delete(context){
            context.partials = {
                header: await this.load("../templates/common/header.hbs"),
                footer: await this.load("../templates/common/footer.hbs")
            };

            this.partial("../templates/movie/delete.hbs", context.app.userData);
        },
        async buyTicket(context){
            const movieId = context.params.id;
            const movie = context.app.userData.movies
                .find(m => m.objectId == movieId);
            console.log(movie);
            
            try {
                const result = await apiBuyTicket(movie);
                    
                if (result.hasOwnProperty("errorData")) {

                    const error = new Error();
                    Object.assign(error, result);
                    throw error;
                }
                
                notifications.showInfo(`Successfully bought a ticket for ${movie.title}!`);
                this.redirect("#/movies");
                
            } catch (e) {
                notifications.showError(e.message)
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

            
        }
    }
};