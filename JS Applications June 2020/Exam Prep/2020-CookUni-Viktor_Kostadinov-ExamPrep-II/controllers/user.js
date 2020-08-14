import notifications from "../js/notifications.js";

export default{
    get: {
        login(context){
            context.loadPartials({
                header: "../templates/common/header.hbs",
                footer: "../templates/common/footer.hbs",
                loginForm: "../templates/login/loginForm.hbs"
            })
            .then(function() {
                this.partial("../templates/login/loginPage.hbs");
            });
        },
        register(context){

        },
        logout(context){

        },

    },

    post: {
        login(context){

        },
        register(context){

        }
    }
}