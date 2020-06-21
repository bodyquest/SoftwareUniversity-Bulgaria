function solve(){
    function Balloon (color, gasWeight) {
            this.color = color;
            this.gasWeight = gasWeight;
    }

    function PartyBalloon (color, gasWeight, ribbonColor, ribbonLength){
        Balloon.call(this, color, gasWeight);

        this._ribbon = {
            color: ribbonColor,
            length: ribbonLength
        }
    }

    // we make the PartyBalloon to have the prototype Balloon
    Object.setPrototypeOf(PartyBalloon, Balloon);
    // PartyBalloon.prototype = Object.create(Balloon.prototype);

    Object.defineProperty(PartyBalloon.prototype, "ribbon", {
        get: function() {return this._ribbon;}
    });

    function  BirthdayBalloon (color, gasWeight, ribbonColor, ribbonLength, text) {
        PartyBalloon.call(this, color, gasWeight, ribbonColor, ribbonLength);

            this._text = text;
        }

    Object.setPrototypeOf(BirthdayBalloon, PartyBalloon);
    // BirthdayBalloon.prototype = Object.create(PartyBalloon.prototype);
    Object.defineProperty(BirthdayBalloon.prototype, "text", {
        get: function() {return this._text;}
    });

    return{
        Balloon,
        PartyBalloon,
        BirthdayBalloon
    }
}

const balloons = solve(); // module with classes inside

const a = new balloons.PartyBalloon("Green", 2, "Red", 15);
console.log(a);
console.log(a.ribbon.color);
