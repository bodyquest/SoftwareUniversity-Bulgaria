import models from "../models/index.js";

export default {
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

            context.loadPartials({
                header: "../templates/common/header.hbs",
                footer: "../templates/common/footer.hbs",
                registerForm: "../templates/register/registerForm.hbs"
            })
            .then(function () {
                this.partial("../templates/register/registerPage.hbs");
            });
        },
        logout(context){
            models.user.logout()
                .then((response) => {
                context.redirect("#/home");
            });
        }
    },
    post: {
        login(context){
            const {username, password} = context.params;
            
            models.users.login(username, password)
                .then((response) => {
                    // context.notification = true;
                    // context.message = "Login successful!";

                     context.user = response;
                     context.username = response.email;
                     context.isLoggedIn = true;
                     context.redirect("#/home")
                })
                .catch((e) => {
                    alert(e);
                    console.error(e);
                });

        },
        register(context){
            const {username, password, repeatPassword} = context.params;

            this.app.userData.loggedIn = true;
            this.app.userData.username = username;
            
            if (password === repeatPassword) {
                models.users.register(username, password)
                .then((response) => {
                    if (response.hasOwnProperty("errorData")) {
                        const error = new Error();
                        Object.assign(error, response);
                        throw error;
                    }
                    context.redirect("#/login")
                })
                .catch((e) => {
                    alert(e.message);
                    console.error(e);
                });
            }
            else{
                alert("Passwords don\'t match!");
                return;
            }
        }
    }
};