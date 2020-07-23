function host(endpoint) {
    return `https://api.backendless.com/C37FA95F-0D6A-9940-FF9B-AAABADC18D00/438AA7CE-7E50-4CA0-B6E7-6EEE19783B2E/${endpoint}`;
}

const endpoints = {
    teams: `data/teams`,
    members: '?loadRelations=members',
    update_user: `data/Users/`,
}

async function addTeamMember (userId, teamId) {

    const token = localStorage.getItem("userToken");
    if (!token) {
        throw new Error ("User is not logged in");
    }
    
    return (await fetch(host(endpoints.teams +`/${teamId}/members`), {
        method: "POST",
        headers: {
            "Content-Type": "application/json",
            "user-token" : token
        },
        body: JSON.stringify([userId])
    })).json();
}

async function addTeamToUser(userId, teamId) {

    const token = localStorage.getItem("userToken");
    if (!token) {
        throw new Error ("User is not logged in");
    }

    return (await fetch(host(endpoints.update_user + `/${userId}`), {
        method: 'PUT',
        headers: {
            'Content-type': 'application/json',
            'user-token': token
        },
        body: JSON.stringify({
            teamId: teamId
        })
    })).json();
}

export default {

    async getTeams(){
        return (await fetch(host(endpoints.teams))).json();
    },

    async getTeamById(teamId) {

        const token = localStorage.getItem("userToken");
        if (!token) {
            throw new Error ("User is not logged in");
        }
        const uri = host(endpoints.teams + `/${teamId}` + endpoints.members);
        debugger;
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
            throw new Error ("User is not logged in");
        }

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
    
            return createdTeam;
        }
    },

    async details(id) {
        return (await fetch(host(endpoints.teams + `/${id}`))).json();
    },

    async edit(id, team){
        const token = localStorage.getItem("userToken");
        if (!token) {
            throw new Error ("User is not logged in");
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
            Object.assign(error, response);
            throw error;
        }

        return result;
    }
};