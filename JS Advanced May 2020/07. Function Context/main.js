// 1. Example
const queue = {
    work: [],

    add(fn, priority){
        this.work.push(fn);
    },

    process() {
        this.work.forEach(fn => fn());
    }
};
const user1 = {
    name: "User1",
    logName() { console.log(this.name); }
};
const user2 = {
    name: "User2",
    logName() { console.log(this.name); }
};
const user3 = {
    name: "User3",
    logName() { console.log(this.name); }
};

queue.add(user1.logName.bind(user1));
queue.add(user2.logName.bind(user2));
queue.add(user3.logName.bind(user3));

// 2. Example
const lib = {
    logFullName () {
        console.log(this.firstName + " " + this.lastName);
    }
};

const obj1 = {
    firstName: "One",
    lastName: "Two"
};

lib.logFullName.call(obj1);
// we add context to this function so it returns what we expect

// Area and Volume Calculator

function area(){
    return this.x * this.y;
}

function volume(){
    return this.x * this.y * this.z;
}

function calculate(input) {
   let objects = JSON.parse(input);
};

calculate
("[{'x': '1', 'y': '2', 'z': '10'},{'x': '7', 'y': '7', 'z': '10'}, {'x': '5', 'y': '2', 'z': '10'}]");