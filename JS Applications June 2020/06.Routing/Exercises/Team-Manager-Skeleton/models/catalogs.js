import models from "../models/index.js";
import notifications from '../scripts/notifications.js';

function host(endpoint) {
    return `https://api.backendless.com/C37FA95F-0D6A-9940-FF9B-AAABADC18D00/438AA7CE-7E50-4CA0-B6E7-6EEE19783B2E/${endpoint}`;
}

const endpoints = {
    teams: `data/teams`,
    members: '?loadRelations=members',
    update_user: `data/Users`,
    teamIds: `?loadRelations=teamId`
}

async function addTeamMember (userId, teamId) {

    const token = localStorage.getItem("userToken");
    
    return (await fetch(host(endpoints.teams +`/${teamId}/members`), {
        method: "POST",
        headers: {
            "Content-Type": "application/json",
            "user-token" : token
        },
        body: JSON.stringify([userId])
    })).json();
}

async function joinTeamMember (userId, teamId) {

    const token = localStorage.getItem("userToken");

    const teamUri = host(endpoints.teams +`/${teamId}/members`);
        const teamWithMembers = await (await fetch(teamUri, {
            method: 'get',
            headers: {
                'user-token': token
            }
        })).json();
    
    // add new member
    let teamMembers = teamWithMembers.map(m => m.objectId);
    teamMembers.push(userId);

    // update team by adding all members
    return (await fetch(host(endpoints.teams +`/${teamId}/members`), {
        method: "POST",
        headers: {
            "Content-Type": "application/json",
            "user-token" : token
        },
        body: JSON.stringify(teamMembers)
    })).json();
}

async function addTeamToUser(userId, teamId) {

    const token = localStorage.getItem("userToken");

    return (await fetch(host(endpoints.update_user + `/${userId}/teamId`), {
        method: 'POST',
        headers: {
            'Content-type': 'application/json',
            'user-token': token
        },
        body: JSON.stringify([teamId])
    })).json();
}

export default {

    async getTeams(){
        return (await fetch(host(endpoints.teams))).json();
    },

    async getTeamById(teamId) {

        const token = localStorage.getItem("userToken");
        if (!token) {
            notifications.showError("User is not logged in");
            context.redirect('#/home');
        return;
        }
        const uri = host(endpoints.teams + `/${teamId}` + endpoints.members);
        return await (await fetch(uri, {
            method: 'get',
            headers: {
                'user-token': token
            }
        })).json();
    },

    async create(team){
        const token = localStorage.getItem("userToken");
        if (!token) {
            notifications.showError("User is not logged in");
            context.redirect('#/home');
            return;
        }

        // check if current user has a TEAM
        const user = await models.users.getUserById();
        if (user.teamId.length !== 0) {
            notifications.showError("You have a team and can\'t create new one!");
            context.redirect('#/catalog');
            return;
        }

        // create new TEAM
        const createdTeam = await (await fetch(host(endpoints.teams), {
            method: "POST",
            headers: {
                "Content-Type": "application/json",
                "user-token" : token
            },
            body: JSON.stringify({
                name: team.name,
                comment: team.comment
            })
        })).json();

        if (createdTeam.hasOwnProperty("errorData")) {

            const error = new Error();
            Object.assign(error, response);
            throw error;
        }

        // add the current user as MEMBER
        const updatedTeam = await addTeamMember( createdTeam.ownerId, createdTeam.objectId );
        
        if (updatedTeam.hasOwnProperty("errorData")) {

            const error = new Error();
            Object.assign(error, updatedTeam);
            throw error;
        }

        if (updatedTeam.code) {
            return updatedTeam;
        } else {

            const updatedUser = await addTeamToUser(createdTeam.ownerId, createdTeam.objectId);

            if (updatedUser.hasOwnProperty("errorData")) {

                const error = new Error();
                Object.assign(error, updatedUser);
                throw error;
            }
    
            return this.getTeamById(createdTeam.objectId);
        }
    },

    async details(id) {
        return (await fetch(host(endpoints.teams + `/${id}`))).json();
    },

    async edit(id, team){
        const token = localStorage.getItem("userToken");
        if (!token) {
            notifications.showError("User is not logged in");
            context.redirect('#/home');
            return;
        }

        const result = await (await fetch(host(endpoints.teams + `/${id}`), {
            method: "PUT",
            headers: {
                "Content-Type": "application/json",
                "user-token" : token
            },
            body: JSON.stringify({
                name: team.name,
                comment: team.comment
            })
        })).json();

        if (result.hasOwnProperty("errorData")) {

            const error = new Error();
            Object.assign(error, result);
            throw error;
        }

        return result;
    },

    async join(teamId){
        const token = localStorage.getItem("userToken");

        if (!token) {
            notifications.showError("User is not logged in");
            context.redirect('#/home');
            return;
        }

        const user = await models.users.getUserById();
        const teamUri = host(endpoints.teams +`/${teamId}/members`);
        const teamWithMembers = await (await fetch(teamUri, {
            method: 'get',
            headers: {
                'user-token': token
            }
        })).json();

        let teamMembers = teamWithMembers.map(m => m.objectId);
        let userIsMember = teamMembers.indexOf(user.objectId) > -1;

        if (userIsMember) {
            notifications.showError("You can\'t join a second team!");
            context.redirect('#/catalog');
            return;
        }

        const updatedTeam = await joinTeamMember( user.objectId, teamId );
        const updatedUser = await addTeamToUser( user.objectId, teamId);
        
        return updatedUser
    },

    async leave(){
        const token = localStorage.getItem("userToken");

        if (!token) {
            notifications.showError("User is not logged in");
            context.redirect('#/home');
            return;
        }

        const user = await models.users.getUserById();
        const userId = user.objectId;
        const teamId = user.teamId[0].objectId;

        const userTeamUri = host(endpoints.teams +`/${teamId}/members`);
        const teamWithMembers = await (await fetch(userTeamUri, {
            method: 'GET',
            headers: {
                'user-token': token
            }
        })).json();

        let teamMembers = teamWithMembers.map(m => m.objectId);
        const userIndex = teamMembers.indexOf(userId);

        if (userIndex < 0) {
            notifications.showError("You are not a member of that team!");
            context.redirect('#/catalog');
            return;
        }

        teamMembers.splice(userIndex, 1);

        const numberUsers = await (await fetch(userTeamUri, {
            method: 'POST',
            headers: {
                'Content-type': 'application/json',
                'user-token': token
            },
            body: JSON.stringify(teamMembers)
        })).json();

        const updatedUser = (await fetch(host(endpoints.update_user + `/${userId}/teamId`), {
            method: 'POST',
            headers: {
                'Content-type': 'application/json',
                'user-token': token
            },
            body: JSON.stringify([])
        })).json();

        return updatedUser;
    }
};