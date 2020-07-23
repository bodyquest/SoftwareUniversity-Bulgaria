import models from "../models/modelsIndex.js";
import extend from "../utilities/context.js";

export default {
    get: {
        login(context){
            console.log(context);

            extend(context).then(function(){
                this.partial("../views/login.hbs");
            });
        },
        register(context){
            extend(context).then(function(){
                this.partial("../views/register.hbs");
            });
        },
        logout(context){
            models.users.logout().then((response) => {
                context.redirect("#/");
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
                     context.redirect("#/")
                })
                .catch((e) => {
                    alert(e);
                    console.error(e);
                });

        },
        register(context){
            const {username, password, rePassword} = context.params;

            if (password === rePassword) {
                models.users.register(username, password)
                    .then((response) => {
                        context.redirect("#/user/login")
                    })
                    .catch((e) => {
                        alert(e);
                        console.error(e);
                    });
            }
        }
    }
};