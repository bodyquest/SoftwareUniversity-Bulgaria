import {createShoe,
        editShoe,
        deleteShoe,
        getShoeById,
        userBought,
        getAllShoes
        } from "../data.js";


export default {
    get: {
        async create(context){
            context.partials = {
                header: await this.load("/templates/common/header.hbs"),
                footer: await this.load("/templates/common/footer.hbs")
            };

            this.partial("/templates/shoe/create.hbs", context.app.userData);
        },
        async edit(context){
            const shoeId = context.params.shoeId;
            const shoe = await getShoeById(shoeId);
            console.log(shoe);
            

            const info = Object.assign(shoe, context.app.userData);
            context.partials = {
                header: await this.load("/templates/common/header.hbs"),
                footer: await this.load("/templates/common/footer.hbs")
            };

            this.partial("/templates/shoe/edit.hbs", info);
        },
        async details(context){
            const shoeId = context.params.shoeId;

            const shoe = await getShoeById(shoeId);
            
            const info = Object.assign(shoe, context.app.UserData);
            info.isAuthor = shoe.ownerId === sessionStorage.getItem("userId");
            info.hasBought = await userBought(shoeId, sessionStorage.getItem("userId"));

            this.partials = {
                header: await this.load("/templates/common/header.hbs"),
                footer: await this.load("/templates/common/footer.hbs")
            };

            await this.partial("/templates/shoe/details.hbs", info);

           if (info.hasBought) {
            const buyBtn = document.getElementById("#buyBtn");
            
            buyBtn.addEventListener("click", async (e) => {
                e.preventDefault();
                try {
                    const result = await buyShoe(shoeId);
                    this.redirect("#/details/" + result.objectId);
                } catch (e) {
                    console.log("something went wrong");
                }
            });
           }
        },
        async delete(context){
            const shoeId = context.params.shoeId;

            try {
                const result = await deleteShoe(shoeId);
                    
                if (result.hasOwnProperty("errorData")) {

                    const error = new Error();
                    Object.assign(error, result);
                    throw error;
                }
                
                this.redirect("#/home");
                
            } catch (e) {
                console.log(e.message);
            }
        }
    },
    post: {
        async create(){
            const {name, brand, description, imageUrl} = this.params;
            const price = Number(this.params.price);

            const authorId = sessionStorage.getItem("userId");

            try {
                if (name.length === 0) {
                    const error = new Error();
                    throw error;
                }
                const shoe = {
                    name,
                    brand,
                    description,
                    imageUrl,
                    price,
                    buyersCount: 0
                };

                const result = await createShoe(shoe);
                if (result.hasOwnProperty("errorData")) {

                    const error = new Error();
                    Object.assign(error, result);
                    throw error;
                }

                this.redirect("#/details/" + result.objectId);
            } catch (e) {
                console.log(e.message);
            }
        },
        async edit(){
            debugger;
            const shoeId = this.params.shoeId;
            const {name, brand, description, imageUrl} = this.params;
            const price = Number(this.params.price);

            console.log(this.params);

            try {
                if (name.length == 0) {
                    //notifications.showError("Name is required");
                    return;
                }

                const shoe = {
                    name,
                    brand,
                    description,
                    imageUrl,
                    price
                };

                const result = await editShoe(shoeId, shoe);
                if (result.hasOwnProperty("errorData")) {

                    const error = new Error();
                    Object.assign(error, result);
                    throw error;
                }

                //notifications.showInfo('Shoe edited!');
                this.redirect("#/details/" + result.objectId);
            } catch (e) {
                console.log("something went wrong");
            }
        }
    }
}