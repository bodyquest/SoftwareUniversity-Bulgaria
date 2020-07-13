export default {
    get: {
        home(context) {

            context.loadPartials({
                header: "../views/shared/header.hbs",
                footer: "../views/shared/footer.hbs"
            }).then(function () {
                this.partial("../views/home/home.hbs");
            });
        }
    }
}; 