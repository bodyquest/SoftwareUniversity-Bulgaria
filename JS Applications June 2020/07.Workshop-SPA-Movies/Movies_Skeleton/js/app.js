import {} from "./data.js";

window.addEventListener("load", () => {
    const app = Sammy("#container", function() {

        this.get("/", home);
        this.get("index.html", home);
        this.get("#/home", home);


    });

    app.run();

    function home() {
        this.partials = {
            header: await this.load("../templates/common/header.hbs"),
            footer: await this.load("../templates/common/footer.hbs")
        }
        await this.load("../templates/home/homePage.hbs")
        this.swap("<h1>Sammy is working</h1>")
    }
})