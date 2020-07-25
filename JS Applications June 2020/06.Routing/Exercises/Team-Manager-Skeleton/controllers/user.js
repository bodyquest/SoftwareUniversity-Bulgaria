import models from "../models/index.js";
import notifications from '../scripts/notifications.js';

function gotError( err )
{
  console.log( "error message - " + err.message );
  console.log( "error code - " + err.statusCode );
}

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
            models.users.logout()
                .then((response) => {

                    this.app.userData.loggedIn = false;
                    this.app.userData.userId = undefined;
                    this.app.userData.username = undefined;
                    this.app.userData.hasTeam = false;
                    this.app.userData.teamId = undefined;

                    localStorage.removeItem("username");
                    localStorage.removeItem("userToken");
                    localStorage.removeItem("userId");

                    notifications.showInfo('Successful logout!');
                    context.redirect("#/home");
            })
            .catch( (e) =>{
                notifications.showError(e.message);
                context.redirect('#/home');
            });
        }
    },
    post: {
        login(context){
            const {username, password} = context.params;
            //

            models.users.login(username, password)
            .then((response) => {
                if (response.hasOwnProperty("errorData")) {
                    
                    const error = new Error();
                    Object.assign(error, response);
                    throw error;
                }
                
                this.app.userData.loggedIn = true;
                this.app.userData.username = response.username;
                this.app.userData.userId = response.objectId;

                models.users.getUserById()
                .then((user) => {
                    
                    if(user.teamId.length !== 0){
                        context.app.userData.hasTeam = true;
                        context.app.userData.teamId = user.teamId[0].objectId;
                    }

                    localStorage.setItem("userToken", response["user-token"]);
                    localStorage.setItem("username", response.username);
                    localStorage.setItem("userId", response.objectId);
                    
                    notifications.showInfo('Successful login!');
                    context.redirect("#/home");
                });
            })
            .catch((e) => {
                notifications.showError(e.message);
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

                    notifications.showInfo('Successful registration!');
                    context.redirect("#/login")
                })
                .catch((e) => {
                    notifications.showError(e.message);
                });
            }
            else{
                notifications.showError("Passwords don\'t match!");
                return;
            }
        }
    }
};