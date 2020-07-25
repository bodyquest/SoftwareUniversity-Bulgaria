import models from "../models/index.js";
import notifications from '../scripts/notifications.js';

function host(endpoint) {
    return `https://api.backendless.com/C37FA95F-0D6A-9940-FF9B-AAABADC18D00/438AA7CE-7E50-4CA0-B6E7-6EEE19783B2E/${endpoint}`;
}

const endpoints = {
    teams: `data/teams`,
    members: '?loadRelations=members'
}

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
        async details(context) {
            const { id } = context.params;
            const token = localStorage.getItem("userToken");

            const user = await models.users.getUserById();
            const userId = user.objectId;

            const teamUri = host(endpoints.teams +`/${id}/members`);
            const teamWithMembers = await (await fetch(teamUri, {
                method: 'GET',
                headers: {
                    'user-token': token
                }
            })).json();

            let teamMembers = teamWithMembers.map(m => m.objectId);
            let userIsMember = teamMembers.indexOf(userId) > -1;

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
                    
                    if (user.objectId === team.ownerId) {
                        team.isAuthor = true;
                    }
                    else{
                        team.isAuthor = false;
                    }

                    if (userIsMember) {
                        team.isOnTeam = true;
                    }

                    console.log(teamWithMembers);

                    const renderData = {
                        objectId: team.objectId,
                        name: team.name,
                        comment: team.comment,
                        members: teamWithMembers.reduce((acc, curr) => {
                            acc.push({username: curr.username});
                            return acc;
                        }, []),
                        isAuthor: team.isAuthor,
                        isOnTeam: userIsMember
                    };
                    
                    this.partial("../templates/catalog/details.hbs", renderData);
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
            const token = localStorage.getItem('userToken');
            if (!token) {
                notifications.showError('User is not logged in');
                this.redirect('#/home');
                return;
            }
            
            models.catalogs.leave()
            .then((response) => {
                if (response.hasOwnProperty("errorData")) {
                        const error = new Error();
                        Object.assign(error, response);
                        throw error;
                }

                context.app.userData.hasTeam = false;
                context.app.userData.teamId = undefined;

                notifications.showInfo('You left the team!');
                context.redirect('#/catalog');
            })
            .catch ((e) => {
                notifications.showError(e.message);
            });
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