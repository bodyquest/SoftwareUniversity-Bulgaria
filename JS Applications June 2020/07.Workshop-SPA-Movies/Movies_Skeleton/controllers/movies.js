import notifications from '../js/notifications.js';

export default {
    get: {
        async catalog(context){
            context.partials = {
                header: await this.load("../templates/common/header.hbs"),
                footer: await this.load("../templates/common/footer.hbs")
            };

            this.partial("../templates/movie/catalog.hbs");
        },
        async create(context){
            context.partials = {
                header: await this.load("../templates/common/header.hbs"),
                footer: await this.load("../templates/common/footer.hbs")
            };

            this.partial("../templates/movie/create.hbs");
        },
        async edit(context){
            context.partials = {
                header: await this.load("../templates/common/header.hbs"),
                footer: await this.load("../templates/common/footer.hbs")
            };

            this.partial("../templates/movie/edit.hbs");
        },
        async details(context){
            context.partials = {
                header: await this.load("../templates/common/header.hbs"),
                footer: await this.load("../templates/common/footer.hbs")
            };

            this.partial("../templates/movie/details.hbs");
        },
        async delete(context){
            context.partials = {
                header: await this.load("../templates/common/header.hbs"),
                footer: await this.load("../templates/common/footer.hbs")
            };

            this.partial("../templates/movie/delete.hbs");
        },
    },

    post: {
        async create(context){
            const { title, description, imageUrl, genres, tickets } = context.params;
            const movie = {
                title,
                description,
                imageUrl,
                genres,
                tickets
            };

            if (Object.values(movie).some(v => v.length == 0)) {
                notifications.showError ("All fields are required!");
                return;
            }

         

        },
        async edit(context){
            
        }
    }
};