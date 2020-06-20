function getPeople (){

    let people = [];
    class Person{
        constructor(firstName, lastName, age, email){
            this.firstName = firstName;
            this.lastName = lastName;
            this.age = age;
            this.email = email;
        }

        toString(){
            return `${this.firstName} ${this.lastName} (age: ${this.age}, email: ${this.email})`
        }
    }

    people.push(
        new Person("Ana", "Simpson", 22, "anna@yahoo.com"),
        new Person("SoftUni"),
        new Person("Stephan", "Johnson", 25),
        new Person("Gabriel", "Peterson", 24, "g.p@gmail.com"))

    return people;
}

console.log(getPeople().join(", "));

// 5. Point Distance
class Point {
    constructor(x, y){
        this.x = x;
        this.y = y;
    }

    static distance(p1, p2){
        let dx = p1.x - p2.x;
        let dy = p1.y - p2.y;

        return Math.sqrt(Math.pow(dx, 2) + Math.pow(dy, 2))
    }
}

let p1 = new Point(5, 5);
let p2 = new Point (9, 8);

console.log(Point.distance(p1, p2));


// 6. Cards (create IIFE)
let result = (function card(){

    const faces = ["2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A"];
    const Suits = {
        DIAMONDS: "♦",
        HEARTS: "♥",
        CLUBS: "♣",
        SPADES: "♠"
    }

    class Card {
        constructor(face, suit){
            this.innerFace = face;
            this.innerSuit = suit;
        }

        get face(){
            return this.innerFace;
        }
        set face(f){
            if (faces.includes(f.toString())) {
                this.innerFace = f;
            }else{
                throw new Error("No such face");
            }
        }

        get suit(){
            return this.innerSuit;
        }
        set suit(s){
            if (Object.values(Suits).includes(s)) {
                this.innerSuit = s;
            }else{
                throw new Error("No such suit");
            }
        }
    }

    return {
        Suits: Suits,
        Card: Card
     };
})();

let Card = result.Card;
let Suits = result.Suits;

let card = new Card("Q", Suits.HEARTS);
console.log(card.face, card.suit);