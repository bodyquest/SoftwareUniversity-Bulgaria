import models from "../models/index.js";
import notifications from '../scripts/notifications.js';

export default {
    get: {
        catalog(context) {
            context.loadPartials({
                header: "../templates/common/header.hbs",
                footer: "../templates/common/footer.hbs",
                team: "../templates/catalog/team.hbs"
            }).then(function(){
            
                models.catalogs.getTeams()
                .then((response) => {
                    if (response.hasOwnProperty("errorData")) {
    
                        const error = new Error();
                        Object.assign(error, response);
                        throw error;
                    }
                    const teams = response;
                    const data = Object.assign({teams}, context.app.userData);
                    
                    this.partial("../templates/catalog/teamCatalog.hbs", data);
                })
                .catch((e) => {
                    notifications.showError(e.message);
                });
                
            });
        },
        details(context) {
            const { id } = context.params;

            context.loadPartials({
                header: "../templates/common/header.hbs",
                footer: "../templates/common/footer.hbs",
                teamMember: "../templates/catalog/teamMember.hbs",
                teamControls: "../templates/catalog/teamControls.hbs"
            }).then(function(){
                
                models.catalogs.details(id)
                .then((response) => {
                    if (response.hasOwnProperty("errorData")) {

                        const error = new Error();
                        Object.assign(error, response);
                        throw error;
                    }
                    const team = response;
                    Object.assign(team, context.app.userData);

                    if (context.app.userData.userId === team.ownerId) {
                        team.isAuthor = true;
                    }

                    if (context.app.userData.teamId === team.objectId) {
                        team.isOnTeam = true;
                    }
                    
                    this.partial("../templates/catalog/details.hbs", team);

                })
                .catch((e) => {
                    alert(e.message);
                    console.error(e);
                });
                
            });
        },
        create(context) {

            context.loadPartials({
                header: "../templates/common/header.hbs",
                footer: "../templates/common/footer.hbs",
                createForm: "../templates/create/createForm.hbs"
            }).then(function(){
                
                this.partial("../templates/create/createPage.hbs", context.app.userData);
            });
        },
        edit(context) {
            
            const { id } = context.params;
            
            context.loadPartials({
                header: "../templates/common/header.hbs",
                footer: "../templates/common/footer.hbs",
                editForm: "../templates/edit/editForm.hbs"
            }).then(function(){

                models.catalogs.getTeamById(id)
                .then((response) => {
                    if (response.hasOwnProperty("errorData")) {

                        const error = new Error();
                        Object.assign(error, response);
                        throw error;
                    }
                    let team = response;

                    Object.assign(team, context.app.userData);
                    
                    this.partial("../templates/edit/editPage.hbs", team);

                })
                .catch((e) => {
                    alert(e.message);
                    console.error(e);
                });
                
            });
        },
        join(context){
            const { id } = context.params;
            debugger;
            models.catalogs.join(id)
            .then((response) => {
                if (response.hasOwnProperty("errorData")) {

                    const error = new Error();
                    Object.assign(error, response);
                    throw error;
                }
                
                context.app.userData.hasTeam = true;
                context.app.userData.teamId = id;

                notifications.showInfo('You joined the team!');
                context.redirect('#/catalog');
            })
            .catch((e) => {
                notifications.showError(e.message);
            });
        },
        leave(context){
            
        }
    },
    post: {
        create(context){
            const { name, comment } = context.params;
            const team = {
                name,
                comment
            };

            if (Object.values(team).some(v => v.length == 0)) {
                notifications.showError ("All fields are required!");
                return;
            }

            if (context.app.userData.hasTeam) {
                notifications.showError('You have a team and can\'t create one!');
                context.redirect('#/catalog');
                return;
            }
            
            models.catalogs.create(team)
            .then((response) => {
                if (response.hasOwnProperty("errorData")) {

                    const error = new Error();
                    Object.assign(error, response);
                    throw error;
                }

                context.app.userData.hasTeam = true;
                context.app.userData.teamId = response.objectId;
                
                notifications.showInfo('Team created!');
                context.redirect(`#/catalog/${response.objectId}`)
            })
            .catch((e) => {
                notifications.showError(e.message);
            });
        },
        edit(context){
            const { id, name, comment } = context.params;
            const team = {
                name,
                comment
            };

            if (Object.values(team).some(v => v.length == 0)) {
                notifications.showError ("All fields are required!");
                return;
            }

            models.catalogs.edit(id, team)
            .then((response) => {
                if (response.hasOwnProperty("errorData")) {

                    const error = new Error();
                    Object.assign(error, response);
                    throw error;
                }

                context.app.userData.teamId = response.objectId;

                notifications.showInfo('Team edited successfully!');
                context.redirect(`#/catalog/${response.objectId}`)
            })
            .catch((e) => {
                notifications.showError(e.message);
            });
        }
       
    }
};