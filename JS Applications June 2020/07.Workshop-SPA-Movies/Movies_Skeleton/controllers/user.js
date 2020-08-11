//import notifications from '../js/notifications.js';
import {registerPost as apiRegister} from "../js/data.js";
import {loginPost as apiLogin} from "../js/data.js";
import {logout as apiLogout} from "../js/data.js";
import models from "../services/index.js";

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
                this.partial("../templates/login/loginPage.hbs", context.app.userData);
            });
        },
        register(context){

            context.loadPartials({
                header: "../templates/common/header.hbs",
                footer: "../templates/common/footer.hbs",
                register: "../templates/register/register.hbs"
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

                localStorage.removeItem("username");
                localStorage.removeItem("userToken");
                localStorage.removeItem("userId");

                this.app.userData.username = "";
                this.app.userData.userId = "";

                notifications.showInfo('Successful logout!');
                this.redirect("#/home");

            } catch (e) {
                notifications.showError(e.message);
            }
        }
    },

    post: {
        async login(){
            const {username, password} = this.params;

            try {

                const result = await apiLogin(username, password);
                    
                if (result.hasOwnProperty("errorData")) {

                    const error = new Error();
                    Object.assign(error, result);
                    throw error;
                }

                this.app.userData.username = result.username;
                this.app.userData.userId = result.objectId;

                notifications.showInfo(`Logged in as ${result.username} !`);
                this.redirect("#/home");

            } catch (e) {
                notifications.showError(e.message);
            }
        },
        async register(){
            const {username, password, repeatPassword} = this.params;
            
            if (username.length < 3) {
                alert("Username must be at least 3 characters long!");
                // notifications.showError("Username must be at least 3 characters long!");
                return;
            }

            if (password.length < 6) {
                alert("Password must be at least 6 characters long!");
                // notifications.showError("Password must be at least 6 characters long!");
                return;
            }

            if (password === repeatPassword) {
                // models.users.register(username, password)
                // .then((response) => {
                //     if (response.hasOwnProperty("errorData")) {

                //         const error = new Error();
                //         Object.assign(error, response);
                //         throw error;
                //     }

                //     //notifications.showInfo('Successful registration!');
                //     context.redirect("#/login")
                // })
                // .catch((e) => {
                //     alert(e.message);
                //     //notifications.showError(e.message);
                // });

                try {
                    const result = await apiRegister(username, password);
                    
                    if (result.hasOwnProperty("errorData")) {

                        const error = new Error();
                        Object.assign(error, result);
                        throw error;
                    }
                    
                    notifications.showInfo('Successful registration!');
                    this.redirect("#/login");
                } catch (e) {
                    notifications.showError(e.message)
                }
            }
            else{
                notifications.showError("Passwords don\'t match!");
                return;
            }
        }
    }
};