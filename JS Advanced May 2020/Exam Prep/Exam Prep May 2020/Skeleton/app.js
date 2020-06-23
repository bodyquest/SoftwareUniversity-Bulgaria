function solve(){

    { // function to make HTML elements
    // functions to move the elements
    

    // 4. attach functionality
    // 5. addd the element to the DOM
    }

    // 1. references to the elements
    const sections = document.querySelectorAll("section");

    const openDiv = sections.item(1).querySelectorAll("div").item(1);
    const progressDiv = sections.item(2).querySelectorAll("div").item(1);
    const finishDiv = sections.item(3).querySelectorAll("div").item(1);

    const inputTask = document.querySelector("#task");
    const inputDescription = document.querySelector("#description");
    const inputDate = document.querySelector("#date");

    document.querySelector("#add").addEventListener("click", addTask);

    // 2. create the DOM elements
    function addTask(e){
        e.preventDefault();
        
        // 3. read what is inside the input / validate input
        const taskName = inputTask.value.trim();
        const taskDescr = inputDescription.value.trim();
        const taskDate = inputDate.value.trim();
        
        
        if (taskName.length > 0 && taskDescr.length > 0 && taskDate.length > 0) {
            const startBtn = el("button", "Start", {className: "green"});
            const finishBtn = el("button", "Finish", {className: "orange"});
            const deleteBtn = el("button", "Delete", {className: "red"});
            
            const btnDiv = el("div", [
                startBtn,
                deleteBtn,
            ], {className: "flex"});
            const task = el("article", [
                el("h3", taskName),
                el("p", `description: ${taskDescr}`),
                el("p", `Due Date: ${taskDate}`),
                btnDiv
            ])
            startBtn.addEventListener("click", () => {
                progressDiv.appendChild(task);
                startBtn.remove();
                btnDiv.appendChild(finishBtn);
            })
            finishBtn.addEventListener("click", () => {
                finishDiv.appendChild(task);
                btnDiv.remove();
            })
            deleteBtn.addEventListener("click", () => {
                task.remove();
            })
            openDiv.appendChild(task);
        }
    }

    function el(type, content, attributes){
        const result = document.createElement(type);
  
        if (attributes !== undefined) {
            Object.assign(result, attributes);
        }
        if (Array.isArray(content)) {
            content.forEach(append);
        }else{
            append(content);
        }
  
        function append(node){
            if (typeof node === "string") {
                node = document.createTextNode(node);
            }
  
            result.appendChild(node);
        }
  
        return result;
    }
}