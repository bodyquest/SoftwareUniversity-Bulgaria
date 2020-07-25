import models from "../models/index.js";

export default {
    get: {
        home(context) {
            context.loadPartials({
                header: "../templates/common/header.hbs",
                footer: "../templates/common/footer.hbs"
            }).then(function(){
                models.users.getUserById()
                .then((user) => {
                    
                    if(user.teamId.length !== 0){
                        context.app.userData.hasTeam = true;
                        context.app.userData.teamId = user.teamId[0].objectId;
                    }
                    
                    this.partial("../templates/home/home.hbs", context.app.userData);
                });
            });
        }
    }
};