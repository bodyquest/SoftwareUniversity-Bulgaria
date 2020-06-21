function solve(){

    const juniorTasks = [
        " is working on a simple task."
    ];
    const seniorTasks = [
        " is working on a complicated task.",
        " is taking time off work.",
        " is supervising junior workers."
    ];
    const managerTasks = [
        " scheduled a meeting.",
        " is preparing a quarterly report."
    ];

    class Employee{
        constructor(name, age){

            if (new.target === Employee) {
                throw new Error("Cannot instantiate directly.");
            }

            this.name = name;
            this.age = age;
            this.salary = 0;
            this.tasks = [];
        }

        work(){
            const currentTask = this.tasks.shift();
            console.log(this.name + currentTask);
            this.tasks.push(currentTask);
        }

        collectSalary(){
            console.log(`${this.name} received ${this.getSalary()} this month.`);
        }

        getSalary(){
            return this.salary;
        }
    }

    class Junior extends Employee{
        constructor(name, age){
            super(name, age);

            juniorTasks.forEach(t => this.tasks.push(t));
        }
    }

    class Senior extends Employee{
        constructor(name, age){
            super(name, age);

            seniorTasks.forEach(t => this.tasks.push(t));
        }

    }

    class Manager extends Employee{
        constructor(name, age){
            super(name, age);

            this.dividend = 0;

            managerTasks.forEach(t => this.tasks.push(t));
        }

        collectSalary(){
            console.log(`${this.name} received ${this.salary + this.dividend} this month.`);
        }

        getSalary(){
            return this.super.getSalary() + this.dividend;
        }
    }

    return {
        Employee,
        Junior,
        Senior,
        Manager
    }
}

const people = solve();
//const a = new people.Employee() // must return error not allowing instantiation

const b = new people.Junior("George", 25)
b.salary = 1000;
b.work(); // works on a simple task

const c = new people.Senior("Peter", 27)
c.salary = 2000;
c.work();
c.work();
c.collectSalary();

const d = new people.Manager("John Doe", 33)
d.salary = 3000;
d.dividend = 1000;
d.work();
d.collectSalary();

