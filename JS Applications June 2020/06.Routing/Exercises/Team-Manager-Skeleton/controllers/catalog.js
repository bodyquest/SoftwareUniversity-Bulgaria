export default {
    get: {
        catalog(context) {
            context.loadPartials({
                header: "../templates/common/header.hbs",
                footer: "../templates/common/footer.hbs",
                team: "../templates/catalog/team.hbs"
            }).then(function(){
                
                const data = Object.assign({}, this.app.userData);
                data.teams = [
                    {
                        _id: "123456",
                        name: "Cherry",
                        comment: "Some comment"
                    },
                    {
                        _id: "1234555",
                        name: "Slivka",
                        comment: "Another comment"
                    },
                    {
                        _id: "12345666",
                        name: "Mushmulka",
                        comment: "Yet another comment"
                    }
                ];

                this.partial("../templates/catalog/teamCatalog.hbs", data);
            });
        },
        details(context) {
            const { id } = context.params;

            context.loadPartials({
                header: "../templates/common/header.hbs",
                footer: "../templates/common/footer.hbs",
                teamMember: "../templates/catalog/teamMember.hbs",
                teamControls: "../templates/catalog/teamControls"
            }).then(function(){
                
                const data = {
                        teamId: "12345666",
                        name: "Mushmulka",
                        comment: "Yet another comment",
                        members: [ 
                            { username: "Ispiridon "},
                            { username: "Trudolyub "},
                            { username: "Uncho "}
                        ]
                };

                Object.assign({data}, this.app.userData);

                this.partial("../templates/catalog/details.hbs", data);
            });
        },
        create(context) {
            const { id } = context.params;

            context.loadPartials({
                header: "../templates/common/header.hbs",
                footer: "../templates/common/footer.hbs",
                createForm: "../templates/create/createForm.hbs"
            }).then(function(){
                
                this.partial("../templates/create/createPage.hbs", this.app.data);
            });
        },
        edit(context) {
            const { id } = context.params;

            context.loadPartials({
                header: "../templates/common/header.hbs",
                footer: "../templates/common/footer.hbs",
                editForm: "../templates/edit/editForm.hbs"
            }).then(function(){
                
                this.partial("../templates/edit/editPage.hbs", this.app.data);
            });
        }
    }
};