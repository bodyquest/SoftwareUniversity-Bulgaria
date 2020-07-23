import extend from "../utilities/context.js";

export default {
    get: {
        home(context) {
            extend(context).then(function () {
                this.partial("../views/home.hbs");
            });
        }
    }
};