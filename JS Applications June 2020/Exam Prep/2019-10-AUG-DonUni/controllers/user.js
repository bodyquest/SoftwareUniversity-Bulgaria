import models from "../models/index.js"

export default {
    get: {
        login(context){
            context.loadPartials({
                header: "../views/shared/header.hbs",
                footer: "../views/shared/footer.hbs"
            }).then(function () {
                this.partial("../views/user/login.hbs");
            });
        },
        register(context){
            context.loadPartials({
                header: "../views/shared/header.hbs",
                footer: "../views/shared/footer.hbs"
            }).then(function () {
                this.partial("../views/user/register.hbs");
            });
        }
    },
    post: {
        login(context){
            //const {username, password} = context.params
        },
        register(context){
            const {username, password, rePassword} = context.params;

            if (password === rePassword) {
                models.user.register(username, password);
            }
        }
    }
};