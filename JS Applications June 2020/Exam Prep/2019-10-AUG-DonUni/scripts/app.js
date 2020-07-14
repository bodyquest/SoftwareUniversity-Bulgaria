import controllers from "../controllers/index.js";

const app = Sammy ("#root", function() {
    this.use("Handlebars", "hbs");
    
    // home
    this.get("#/home", controllers.home.get.home);
    
    // user
    this.get("#/user/login", controllers.user.get.login);
    this.get("#/user/register", controllers.user.get.register);

    this.post("#/user/login", controllers.user.post.login);
    this.post("#/user/register", controllers.user.post.register);

    this.get("#/user/logout", controllers.user.get.logout);
    
    // causes
    this.get("#/cause/create")
;    
});

(() => {
    app.run("#/home");
})();
