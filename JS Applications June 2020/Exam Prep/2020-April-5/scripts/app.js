import controllers from "../scripts/controllers/index.js";

window.addEventListener("load", () => {

    const app = Sammy("#root", function () {
        this.use("Handlebars", "hbs");

        this.userData = {
            username: sessionStorage.getItem("username") || "",
            userId: sessionStorage.getItem("userId") || ""
        };

        // home routes
        this.get("/", controllers.home);
        this.get("#/", controllers.home);
        this.get("#/home", controllers.home);

        // user
        this.get("#/login", controllers.users.get.login);
        this.post("#/login", context => {controllers.users.post.login.call(context); });

        this.get("#/register", controllers.users.get.register);
        this.post("#/register", context => {controllers.users.post.register.call(context); });

        this.get("#/logout", controllers.users.get.logout);

        // articles routes
        this.get("#/create", );
        this.post("#/create", );

        this.get("#/edit/:articleId", );
        this.post("#/edit/:articleId", );

        this.get("#/details/:articleId", );

        this.get("#/delete/:articleId", );

    });

    app.run();
});