function personAndTeacher(){
    class Person {
        constructor(name, email){
            this.name = name;
            this.email = email;
        }
    }

    class Teacher extends Person{
        constructor(name, email, subject){
            super(name, email);
            this.subject = subject;
        }
    }

    return {
        Person,
        Teacher
    }
}

function toStringExtension() {
    class Person {
        constructor(name, email){
            this.name = name;
            this.email = email;
        }

        toString(){
            return `Person (name: ${this.name}, email: ${this.email})`;
        }
    }

    class Teacher extends Person {
        constructor(name, email, subject){
            super(name, email);

            this.subject = subject;
        }

        toString(){
            return `Teacher (name: ${this.name}, email: ${this.email}, subject: ${this.subject})`;
        }
    }

    class Student extends Person {
        constructor(name, email, course){
            super(name, email);

            this.course = course;
        }

        toString(){
            return `Student (name: ${this.name}, email: ${this.email}, course: ${this.course})`;
        }
    }

    return {
        Person,
        Teacher,
        Student
    }
}

class Person {
    constructor(name, email){
        this.name = name;
        this.email = email;
    }

    toString(){
        return `Person (name: ${this.name}, email: ${this.email})`;
    }
}

class Teacher extends Person {
    constructor(name, email, subject){
        super(name, email);

        this.subject = subject;
    }

    toString(){
        return `Teacher (name: ${this.name}, email: ${this.email}, subject: ${this.subject})`;
    }
}

let person = new Person();
let teacher = new Teacher();

person.name = "Ivan";
person.email = "mail@email.com";

teacher.subject = "Math";

console.log(person.toString());
console.log(teacher.toString());

