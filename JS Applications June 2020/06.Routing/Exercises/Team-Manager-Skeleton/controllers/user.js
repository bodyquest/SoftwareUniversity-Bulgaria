import models from "../models/index.js";

function userLoggedOut()
{
  console.log( "user has been logged out" );
}

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

                    context.redirect("#/home");
            })
            .then( userLoggedOut )
            .catch( gotError );
        }
    },
    post: {
        login(context){
            const {username, password} = context.params;
            
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
                
                localStorage.setItem("userToken", response["user-token"]);
                localStorage.setItem("username", response.username);
                localStorage.setItem("userId", response.objectId);
                
                context.redirect("#/home");
                })
                .catch((e) => {
                    alert(e.message);
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