class Library{
    constructor(libraryName){
        this.libraryName = libraryName;

        this.subscribers = [];
        this.subscriptionTypes = {
            normal: this.libraryName.length,
            special: this.libraryName.length * 2,
            vip: Number.MAX_SAFE_INTEGER
        }
    }

    subscribe(name, type){
        if (!this.subscriptionTypes[type]) {
            throw new Error(`The type ${type} is invalid`);
        }
        
        let foundSubscriber = this.subscribers.find(s => s.name === name);
        if (!foundSubscriber) {
            this.subscribers.push({
                name,
                type,
                books: []
            });
        }
        else{
            foundSubscriber.type = type;
        }

        return foundSubscriber 
        ? foundSubscriber 
        : this.subscribers[this.subscribers.length -1];
    }

    unsubscribe(name){
        let index = this.subscribers.findIndex(s => s.name === name);
        if (index === -1) {
            throw new Error(`There is no such subscriber as ${name}`);
        }

        this.subscribers.splice(index, 1);

        return this.subscribers;
    }

    receiveBook(subscriberName, bookTitle, bookAuthor){
        const subscriber = this.subscribers.find(s => s.name === subscriberName);
        if (!subscriber) {
            throw new Error(`There is no such subscriber as ${subscriberName}`);
        }
        const type = subscriber.type;

        if (subscriber.books.length < this.subscriptionTypes[type]) {
            subscriber.books.push({
                title: bookTitle,
                author: bookAuthor
            })
        }
        else{
            throw new Error(`You have reached your subscription limit ${this.subscriptionTypes[type]}!`);
        }

        return subscriber;
    }

    showInfo(){
        let result = [];
        if (this.subscribers.length === 0) {
            return `${this.libraryName} has no information about any subscribers`;
        }

        // THIS ALSO WORKS
        // return this.subscribers
        // .map(s => {
        //     const books = s.books
        //     .map(b => `${b.title} by ${b.author}`)
        //     .join(", ");

        //     return `Subscriber: ${s.name}, Type: ${s.type}\nReceived books: ${books}`;
        // })
        // .join("\n");
        
        else{
            for (const person of this.subscribers) {
                let type = person.type;

                let books = person.books.reduce((acc, curr) => {
                    acc.push(`${curr.title} by ${curr.author}`);
                    return acc;
                }, []);

                result.push(
                    `Subscriber: ${person.name}, Type: ${type}`,
                    `Received books: ${Array.from(books).join(", ")}`
                )
            }
        }

        return result.join("\n");
    }
}

let lib = new Library('Lib');

lib.subscribe('Peter', 'normal');
lib.subscribe('John', 'special');

lib.receiveBook('John', 'A Song of Ice and Fire', 'George R. R. Martin');
lib.receiveBook('Peter', 'Lord of the rings', 'J. R. R. Tolkien');
lib.receiveBook('John', 'Harry Potter', 'J. K. Rowling');

console.log(lib.showInfo());
