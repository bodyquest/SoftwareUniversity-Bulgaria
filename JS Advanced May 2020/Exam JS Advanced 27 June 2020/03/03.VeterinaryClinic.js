class VeterinaryClinic{

    constructor(clinicName, capacity){
        this.clinicName = clinicName;
        this.capacity = Number(capacity);

        this.clients = [];
        this.totalProfit = 0;
        this.currentWorkload = 0;
    }

    newCustomer(ownerName, petName, kind, procedures){
    
        if (this.capacity === this.currentWorkload) {
            throw new Error("Sorry, we are not able to accept more patients!");
        }

        const owner = this.clients.find(c => c.owner === ownerName);
        if(!owner){
            let owner = {
                owner: ownerName,
                pets: [
                    {
                        name: petName,
                        kind: kind,
                        procedures: [...procedures]
                    }
                ]
            }
            this.clients.push(owner);
            this.currentWorkload ++;
            return `Welcome ${petName}!`
        }
        
        if(owner && !owner.pets.find(p => p.name === petName)){
            owner.pets.push({
                name: petName,
                kind: kind,
                procedures: [...procedures]
            });

            return `Welcome ${petName}!`
        }
        else if (owner.pets.find(p => p.name === petName) && owner.pets.find(p => p.name === petName).procedures.length > 0) {
            throw new Error(`This pet is already registered under ${ownerName} name! ${petName}is on our lists,waiting for ${owner.pets.find(p => p.name === petName).procedures.join(", ")}.`);
        }
        else if(owner.pets.find(p => p.name === petName) && owner.pets.find(p => p.name === petName).procedures.length === 0){
            pet.procedures = [...procedures];
            this.currentWorkload ++;
            return `Welcome ${petName}!`
        }
    }

    onLeaving (ownerName, petName){
        const owner = this.clients.find(c => c.owner === ownerName);
        const pet = owner.pets.find(p => p.name === petName);

        if (!owner) {
            throw new Error("Sorry, there is no such client!");
        }

        if (!owner || pet.procedures.length === 0) {
            throw new Error(`Sorry, there are no procedures for ${petName}!`);
        }

        this.totalProfit += 500 * (pet.procedures.length);
        pet.procedures.length = 0;

        this.currentWorkload --;

        return `Goodbye ${petName}. Stay safe!`;
    }

    toString(){

        let sortedOwners = this.clients.sort((a, b) => a.owner.localeCompare(b.owner));

        let sickPets = this.clients.filter(c => c.pets.filter(p => p.procedures.length > 0)).length;
        let percentBusy = sickPets / this.capacity * 100;

        let result = [];
        result.push(`${this.clinicName} is ${percentBusy}% busy today!`);
        result.push(`Total profit: ${(this.totalProfit).toFixed(2)}$`);

        let sorted = this.clients.sort((a, b) => a.name - b.name);
        sortedOwners.forEach((owner) =>{
            result.push(`${owner.owner} with:`);
            owner.pets.sort((a, b) => a.name.localeCompare(b.name)).forEach((pet) => {
                result.push(`---${pet.name} - a ${pet.kind.toLowerCase()} that needs: ${pet.procedures.join(", ")}`)
            })
        });
        
        return result.join("\n");
    }
}

let clinic = new VeterinaryClinic('SoftCare', 10);
console.log(clinic.newCustomer('Jim Jones', 'Tom', 'Cat', ['A154B', '2C32B', '12CDB']));
console.log(clinic.newCustomer('Anna Morgan', 'Max', 'Dog', ['SK456', 'DFG45', 'KS456']));
console.log(clinic.newCustomer('Jim Jones', 'Tiny', 'Cat', ['A154B'])); 
console.log(clinic.onLeaving('Jim Jones', 'Tiny'));
console.log(clinic.toString());
console.log(clinic.newCustomer('Jim Jones', 'Sara', 'Dog', ['A154B']));
console.log(clinic.toString());
