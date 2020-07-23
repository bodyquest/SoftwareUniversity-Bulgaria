import controllers from "../controllers/index.js";


$(() => {
    const app = Sammy ("#main", function() {
        this.use("Handlebars", "hbs");

        this.userData = {
            loggedIn: false,
            hasNoTeam: true
        };
        
        // home
        this.get("/", controllers.home.get.home);
        this.get("#/home", controllers.home.get.home);
        this.get("index.html", controllers.home.get.home);

        this.get("#/about", controllers.about.get.about);
        
        // user
        this.get("#/login", controllers.user.get.login);
        this.get("#/register", controllers.user.get.register);
        this.get("#/logout", controllers.user.get.logout);

        this.post("#/login", controllers.user.post.login);
        this.post("#/register", controllers.user.post.register);
        //this.post("#/register", (ctx) => {controllers.user.post.register.call(ctx);});

        // catalog
        this.get("#/catalog", controllers.catalog.get.catalog);
        this.get("#/catalog/:id", controllers.catalog.get.details);
        this.get("#/create", controllers.catalog.get.create);
        this.get("#/edit/:id", controllers.catalog.get.edit);

        this.post("#/create", controllers.catalog.post.create);
        this.post("#/edit/:id", controllers.catalog.post.edit);
        

    });

    app.run("#/home");
});