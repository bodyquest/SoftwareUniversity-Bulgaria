function solve(){
    class Balloon {
        constructor(color, gasWeight){
            this.color = color;
            this.gasWeight = Number(gasWeight);
        }
    }

    class PartyBalloon extends Balloon{

        constructor(color, gasWeight, ribbonColor, ribbonLength){
            super(color, gasWeight);

            this._ribbon = {
                color: ribbonColor,
                length: Number(ribbonLength)
            }

            // Object.defineProperty(this, "ribbon", {
            //     get: () => _ribbon
            // });
        }

        get ribbon(){
            return this._ribbon;
        }
    }

    class BirthdayBalloon extends PartyBalloon{
        constructor(color, gasWeight, ribbonColor, ribbonLength, text){
            super(color, gasWeight, ribbonColor, ribbonLength);

            this._text = text;
        }

        get text() {
            return this._text;
        }
    }

    return{
        Balloon,
        PartyBalloon,
        BirthdayBalloon
    }
}

const balloons = solve(); // module with classes inside

const a = new balloons.BirthdayBalloon("Green", 2, "Red", 15, "Happy BD!");
console.log(a);
