import controllers from "../controllers/index.js";

window.addEventListener("load", () => {
    
    const app = Sammy("#container", function() {
        this.use("Handlebars", "hbs");

        this.userData = {
            username: localStorage.getItem("username") || "",
            userId: localStorage.getItem("userId") || "",
            movies: []
        };

        // home routes
        this.get("/", controllers.home);
        this.get("index.html", controllers.home);
        this.get("#/home", controllers.home);

        // user
        this.get("#/login", controllers.user.get.login);
        this.post("#/login", context => {controllers.user.post.login.call(context); });

        this.get("#/register", controllers.user.get.register);
        //this.post("#/register", controllers.user.post.register);
        this.post("#/register", ctx => {controllers.user.post.register.call(ctx); });

        this.get("#/logout", controllers.user.get.logout);

        // movies
        this.get("#/movies", controllers.movies.get.catalog);

        this.get("#/create", controllers.movies.get.create);

        this.get("#/edit/:id", controllers.movies.get.edit);
        this.post("#/edit/:id", controllers.movies.post.edit);

        this.get("#/details/:id", controllers.movies.get.details);

        this.get("#/delete/:id", controllers.movies.get.delete);

    });

    app.run();
});