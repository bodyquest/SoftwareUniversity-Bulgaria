export default {
    get: {
        about(context) {
            context.loadPartials({
                header: "../templates/common/header.hbs",
                footer: "../templates/common/footer.hbs"
            }).then(function(){
    
                this.partial("../templates/about/about.hbs", context.app.userData);
            });
        }
    }
};