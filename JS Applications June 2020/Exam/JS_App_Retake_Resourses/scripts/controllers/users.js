import {registerPost as apiRegister} from "../data.js";
import {loginPost as apiLogin} from "../data.js";
import {logout as apiLogout} from "../data.js";

export default {
    get: {
        login(context){
            context.loadPartials({
                header: "/templates/common/header.hbs",
                footer: "/templates/common/footer.hbs"
            })
            .then(function() {
                this.partial("/templates/login/loginPage.hbs", context.app.userData);
            });
        },
        register(context){

            context.loadPartials({
                header: "../templates/common/header.hbs",
                footer: "../templates/common/footer.hbs"
            })
            .then(function () {
                this.partial("../templates/register/registerPage.hbs", context.app.userData);
            });
        },
        async logout(){
            try {
                const result = await apiLogout();
                if (result.hasOwnProperty("errorData")) {

                    const error = new Error();
                    Object.assign(error, result);
                    throw error;
                }

                sessionStorage.removeItem("email");
                sessionStorage.removeItem("userToken");
                sessionStorage.removeItem("userId");

                this.app.userData.email = "";
                this.app.userData.userId = "";

                //notifications.showInfo('Successful logout!');
                this.redirect("#/home");

            } catch (e) {
                //notifications.showError(e.message);
            }
        }
    },

    post: {
        async login(){
            const {email, password} = this.params;

            try {
                const result = await apiLogin(email, password);
                    
                if (result.hasOwnProperty("errorData")) {

                    const error = new Error();
                    Object.assign(error, result);
                    throw error;
                }

                this.app.userData.email = result.email;
                this.app.userData.userId = result.objectId;

                //notifications.showInfo(`Logged in as ${result.email}!`);
                this.redirect("#/home");

            } catch (e) {
                //notifications.showError(e.message);
            }
        },
        async register(){
            const {email, password} = this.params;
            const repeatPassword = this.params["rePassword"];
            
            if (email.length === 0) {
                return;
            }

            if (password.length < 6) {
                return;
            }

            if (password === repeatPassword) {

                try {
                    const result = await apiRegister(email, password);
                    
                    if (result.hasOwnProperty("errorData")) {

                        const error = new Error();
                        Object.assign(error, result);
                        throw error;
                    }
                    
                    this.redirect("#/home");
                } catch (e) {
                    console.log("something went wrong");
                }
            }
            else{
                return;
            }
        }
    }
};