import notifications from '../js/notifications.js';

export default {
    get: {
        login(context){
            context.loadPartials({
                header: "../templates/common/header.hbs",
                footer: "../templates/common/footer.hbs",
                login: "../templates/login/login.hbs"
            })
            .then(function() {
                this.partial("../templates/login/loginPage.hbs");
            });
        },
        register(context){

            context.loadPartials({
                header: "../templates/common/header.hbs",
                footer: "../templates/common/footer.hbs",
                register: "../templates/register/register.hbs"
            })
            .then(function () {
                this.partial("../templates/register/registerPage.hbs");
            });
        },
        logout(context){

        }
 
    },

    post: {
        login(context){
            const {username, password} = context.params;
            
        },
        register(context){
            const {username, password, repeatPassword} = context.params;

        }
    }
};