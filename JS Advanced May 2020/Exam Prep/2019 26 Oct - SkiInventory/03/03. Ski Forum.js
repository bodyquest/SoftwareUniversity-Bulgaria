class Forum{
    constructor(){
        this._users = [];
        this._questions = [];
        this._id = 1;

        this.currentLoggedUsers = [];
    }

    register(username, password, repeatPassword, email){
        // Input can not be empty
        // Passwords do not match
        // This user already exists!
        // ${username} with ${email} was registered successfully!

        if (username === "" 
            || password === "" 
            || repeatPassword === ""
            || email === "") {
            throw new Error("Input can not be empty");
        }
        
        if(password !== repeatPassword){
            throw new Error("Passwords do not match");
        }

        if (this._users.find(u => u.username === username)) {
            throw new Error("This user already exists!");
        }
        else{
            this._users.push({
                username,
                password,
                email
            });
        }

        return `${username} with ${email} was registered successfully!`;
    }

    login(username, password){
        // There is no such user
        // Hello! You have logged in successfully

        if (!this._users.find(u => u.username === username)) {
            throw new Error("There is no such user");
        }

        if (this._users.find(u => u.username === username && u.password === password)) {
            this.currentLoggedUsers.push(username);
            return `Hello! You have logged in successfully`;
        }
    }

    logout(username, password){
        // There is no such user
        // You have logged out successfully
        // throw new Error("");

        if (!this._users.find(u => u.username === username)) {
            throw new Error("There is no such user");
        }

        if (this._users.find(u => u.username === username && u.password === password)) {
            this.currentLoggedUsers.splice(this.currentLoggedUsers.indexOf(username), 1);
            return "You have logged out successfully";
        }
    }

    postQuestion(username, question){
        
        // You should be logged in to post questions
        // Invalid question
        // Your question has been posted successfully

        if (!this._users.find(u => u.username === username) || !this.currentLoggedUsers.includes(username)) {
            throw new Error("You should be logged in to post questions");
        }
        
        if (question === "") {
            throw new Error("Invalid question");
        }

        this._questions.push({
            id: this._id++,
            question: question,
            username: username,
            answers: []
        });
        
        return `Your question has been posted successfully`;
    }

    postAnswer(username, questionId, answer){
        // You should be logged in to post answers
        // Invalid answer
        // There is no such question
        // Your answer has been posted successfully

        if (!this._users.find(u => u.username === username) || !this.currentLoggedUsers.includes(username)) {
            throw new Error("You should be logged in to post answers");
        }

        if (answer === "") {
            throw new Error("Invalid answer");
        }

        if (!this._questions.find(q => q.id === questionId)) {
            throw new Error("There is no such question");
        }
        
        let question = this._questions.find(q => q.id === questionId);
        question.answers.push( {answer, username} );

        return `Your answer has been posted successfully`;
    }

    showQuestions(){
        /**
         * "Question {id} by {username}: {question}
            ---{username}: {answer}
            Question {id} by {username}: {question}
            ---{username}: {answer}
            ---{username}: {answer}
         */
        let result = [];
        this._questions.forEach(q => {
            result += `Question ${q.id} by ${q.username}: ${q.question}\n`,
            q.answers.forEach(a => {
                result += `---${a.username}: ${a.answer}\n`
            })
        });

        return result.trim();
    }
}

let forum = new Forum();

forum.register('Michael', '123', '123', 'michael@abv.bg');
forum.register('Stoyan', '123ab7', '123ab7', 'some@gmail@.com');
forum.login('Michael', '123');
forum.login('Stoyan', '123ab7');

forum.postQuestion('Michael', "Can I rent a snowboard from your shop?");
forum.postAnswer('Stoyan',1, "Yes, I have rented one last year.");
forum.postQuestion('Stoyan', "How long are supposed to be the ski for my daughter?");
forum.postAnswer('Michael',2, "How old is she?");
forum.postAnswer('Michael',2, "Tell us how tall she is.");

console.log(forum.showQuestions());
