import controllers from "../controllers/index.js";

const app = Sammy("#container", function () {
    this.use("Handlebars", "hbs");

    const loadingBox = document.getElementById("loadingBox");
    const infoBox = document.getElementById("infoBox");
    const errorBox = document.getElementById("errorBox");

    function toggleLoader() {
        if (loadingBox.style.display === "none") {
            loadingBox.style.display === "inline";
            return;
        }
        loadingBox.style.display === "none";
    }

    // home
    this.get("#/", controllers.home.get.home);

    // user
    this.get("#/user/login", controllers.user.get.login);
    this.get("#/user/register", controllers.user.get.register);

    this.post("#/user/login", controllers.user.post.login);
    this.post("#/user/register", controllers.user.post.register);

    this.get("#/user/logout", controllers.user.get.logout);

    // this.get("#/", function () {

    // });

    // this.get("#/about", function () {

    // });

    // function getTemplate(templateUrl){
    //     const existingTemplate = templates[templateUrl];

    //     if (existingTemplate){
    //         return Promise.resolve(existingTemplate);
    //     }
    //     fetch(templateUrl)
    //         .then(res => res.text())
    //         .then();
    // }
});

(() => {
    app.run("#/");
})();