// NOTE: The comment sections inside the index.html file is an example of how suppose to be structured the current elements.
//       - You can use them as an example when you create those elements, to check how they will be displayed, just uncomment them.
//       - Also keep in mind that, the actual skeleton in judge does not have this comment sections. So do not be dependent on them!
//       - They are present in the skeleton just to help you!


// This function will be invoked when the html is loaded. Check the console in the browser or index.html file.
function mySolution(){

    // make object with all main HTML elements which we need for the problem
    const $elements = {
        askQuestionArea: document.querySelector("#inputSection textarea"),
        usernameInput: document.querySelector("#inputSection div input[type='username']"),
        askQuestionBtn: document.querySelector("#inputSection div button"),
        pendingQuestionsDiv: document.querySelector("#pendingQuestions"),
        openQuestionsDiv: document.querySelector("#openQuestions")
    }

    $elements.askQuestionBtn.addEventListener("click", askQuestion);

    function askQuestion(e){
        const question = $elements.askQuestionArea.value;
        const givenUsername = $elements.usernameInput.value;
        const username = givenUsername === "" ? "Anonymous" : givenUsername;

        let pendingQuestionDiv = createHTML("div", "pendingQuestion");
        let userImage = createHTML("img", null, null, [{k: "src", v: "./images/user.png"}, {k: "width", v: 32}, {k: "height", v: 32}]);

        let usernameSpan = createHTML("span", null, username);
        let questionParagraph = createHTML("p", null, question);
        let actionsDiv = createHTML("div", "actions");
            let archiveBtn = 
                createHTML("button", "archive", "Archive", null, {name: "click", func: archiveQuestion});
            let openBtn = 
                createHTML("button", "open", "Open", null, {name: "click", func: openQuestion});

        // add buttons to actionsDiv
        actionsDiv = appendChildrenToParent([archiveBtn, openBtn], actionsDiv);

        // add elements to the pendingQuestionDiv
        pendingQuestionDiv = appendChildrenToParent([userImage, usernameSpan, questionParagraph, actionsDiv], pendingQuestionDiv);

        $elements.pendingQuestionsDiv.appendChild(pendingQuestionDiv);
    }

    function archiveQuestion(e){
        const parent = e.target.parentNode.parentNode;
        parent.remove();
    }

    function openQuestion(e){
        const questionDiv = e.target.parentNode.parentNode;
        questionDiv.className = "openQuestion";
                let actionsDiv =  questionDiv
                    .querySelector("div.actions");

                actionsDiv.innerHTML = "";
                const replyBtn = 
                    createHTML("button", "reply", "Reply", null, {name: "click", func: replyToQuestion});
        actionsDiv = appendChildrenToParent([replyBtn], actionsDiv);

        replySectionDiv = 
            createHTML("div", "replySection", null, [{k: "style", v: "display: none;"}]);
                replyInput = createHTML("input", "replyInput", null, [{k: "type", v: "text"}, {k: "placeholder", v: "Reply to this question here..."}]);
                sendAnswerBtn = createHTML("button", "replyButton", "Send", null, {name: "click", func: addAnswer});
                let answersOl = createHTML("ol", "reply", null, [{k: "type", v: "1"}]);

        replySectionDiv = appendChildrenToParent([replyInput, sendAnswerBtn, answersOl], replySectionDiv);
        questionDiv.appendChild(replySectionDiv);

        $elements.openQuestionsDiv.appendChild(questionDiv); 
    }

    function addAnswer(){
        const parent = this.parentNode;
        const answerInput = parent.querySelector("input").value;
        let answerLi = createHTML("li", null, answerInput);

        parent.querySelector("ol").appendChild(answerLi);
    }

    function replyToQuestion(e){
        let button = e.target;
        let replySectionDiv = this.parentNode.parentNode.querySelector(".replySection");

        if (button.textContent === "Reply") {
            replySectionDiv.style.display = "block";
            button.textContent = "Back";
        }
        else{
            replySectionDiv.style.display = "none";
            button.textContent = "Reply";
        }
    }

    function createHTML(tagName, className, textContent, attributes, event){
        let element = document.createElement(tagName);
        if (className) {
            element.classList.add(className);
        }

        if (textContent) {
            element.textContent = textContent;
        }

        if (attributes) {
            attributes.forEach((a) => element.setAttribute(a.k, a.v)
            )
        }

        if (event) {
            element.addEventListener(event.name, event.func );
        }

        return element;
    }   

    function appendChildrenToParent(children, parent){
        children.forEach((c) => parent.appendChild(c));
        return parent;
    }
}