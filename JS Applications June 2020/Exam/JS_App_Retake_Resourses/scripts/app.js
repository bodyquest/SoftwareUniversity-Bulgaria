import controllers from "../scripts/controllers/index.js";

window.addEventListener("load", () => {

    const app = Sammy("#main", function () {
        this.use("Handlebars", "hbs");

        this.userData = {
            email: sessionStorage.getItem("email") || "",
            userId: sessionStorage.getItem("userId") || ""
        };

        // home routes
        this.get("/", controllers.home);
        this.get("#/", controllers.home);
        this.get("#/home", controllers.home);

        // user routes
        this.get("#/login", controllers.users.get.login);
        this.post("#/login", context => {controllers.users.post.login.call(context); });

        this.get("#/register", controllers.users.get.register);
        this.post("#/register", context => {controllers.users.post.register.call(context); });

        this.get("#/logout", controllers.users.get.logout);

        // shoes routes
        this.get("#/create", controllers.shoes.get.create);
        this.post("#/create", context => {controllers.shoes.post.create.call(context); });

        this.get("#/edit/:shoeId", controllers.shoes.get.edit);
        this.post("#/edit/:shoeId", context => {controllers.shoes.post.edit.call(context); });

        this.get("#/details/:shoeId", controllers.shoes.get.details);
        //this.get("#/buy/:shoeId", controllers.shoes.get.buy);

        this.get("#/delete/:shoeId", controllers.shoes.get.delete);

        this.get("", function() {
            this.swap("<h1>404 Page Not Found!</h1>");
        });
    });

    app.run();
});