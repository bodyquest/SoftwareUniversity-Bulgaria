import {getAllShoes} from "../data.js";

export default async function home() {
    const context = {};

    if (this.app.userData.email) {
        context.shoes = await getAllShoes();
    }
    
    Object.assign(context, this.app.userData);

    this.partials = {
        header: await this.load("/templates/common/header.hbs"),
        footer: await this.load("/templates/common/footer.hbs"),
        loginPage: await this.load("/templates/login/loginPage.hbs"),
        userHome: await this.load("/templates/home/userHome.hbs"),
        guestHome: await this.load("/templates/home/guestHome.hbs"),
    }
    
    this.partial("/templates/home/homePage.hbs", context);
}