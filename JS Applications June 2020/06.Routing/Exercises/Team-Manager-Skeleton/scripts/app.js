const app = Sammy ("#main", function() {
    this.use("Handlebars", "hbs");
    
    // home
    this.get("#/home", function(context) {
        context.loadPartials({
            header: "../templates/common/header.hbs",
            footer: "../templates/common/footer.hbs"
        }).then(function(){
            this.partial("../templates/home/home.hbs");
        });
    });
    
    // user
    
});

(() => {
    app.run("#/home");
})();