import controllers from "../controllers/index.js";
import { register, login, logout } from "./data.js";

window.addEventListener("load", () => {
    const app = Sammy ("#/main", function() {
        this.use("Handlebars", "hbs");

        // home
        this.get("#/home", controllers.home.get.home);

        // user
        this.get("#/login", controllers.user.get.login);
        this.post("#/login", controllers.user.post.login);

        this.get("#/register", controllers.user.get.register);
        this.post("#/register", controllers.user.post.register);

        this.get("#/logout", controllers.user.get.logout);



    });

    app.run("#/home");
});
