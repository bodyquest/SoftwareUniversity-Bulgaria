function solve() {
    // TODO ...
    // get the Name, Age, Kind and current Owner

     const [name, age, kind, currentOwner] = document.querySelectorAll("#container input");
    const addBtn = document.querySelector("#container button");

    const adoptionList = document.querySelector("#adoption ul");


    addBtn.addEventListener("click", addToList);

    function addToList(e){
        e.preventDefault();
        let nameValue = name.value;
        let ageValue = age.value;
        let kindValue = kind.value;
        let currentOwnerValue = currentOwner.value;

        // check if OR or AND needed
        if (nameValue && Number(ageValue) && kindValue && currentOwnerValue) {
            
            let li = createHTML("li");
            let paragraph = createHTML("p");
            paragraph.innerHTML = `<strong>${nameValue}</strong> is a <strong>${ageValue}</strong> year old <strong>${kindValue}</strong>`;

            // let strongName = createHTML("strong", null, nameValue);
            // let strongAge = createHTML("strong", null, ageValue);
            // let strongKind = createHTML("strong", null, kindValue);

            let span = createHTML("span", null, `Owner: ${currentOwnerValue}`);
            let button = createHTML("button", null, "Contact with owner", null, {name: "click", func: takeIt});

            appendChildrenToParent([paragraph, span, button], li);
            adoptionList.appendChild(li);
        }

        // clear inputs at the end
        name.value = "";
        age.value = "";
        kind.value = "";
        currentOwner.value = ""
    }

    function takeIt(e){
        let parent = e.target.parentNode;
        e.target.remove();

        let div = createHTML("div");
        let input = createHTML("input", null, null, [{k: "placeholder", v: "Enter your names"}]);
        let button = createHTML("button", null, "Yes! I take it!", null, {name: "click", func:newOwnerTakesIt});

        appendChildrenToParent([input, button], div);
        parent.appendChild(div);
    }

    function newOwnerTakesIt(e){
        let input = document.querySelector("#adoption input");
        let paragraph = e.target.parentNode.parentNode.querySelector("p");

        const adoptedList = document.querySelector("#adopted ul")

        if (input.value !== "") {
            
            let li = createHTML("li");
            let paragraphNew = paragraph.cloneNode(true);
           

            // let strongName = createHTML("strong", null, nameValue);
            // let strongAge = createHTML("strong", null, ageValue);
            // let strongKind = createHTML("strong", null, kindValue);

            let span = createHTML("span", null, `New Owner: ${input.value}`);
            let button = createHTML("button", null, "Checked", null, {name: "click", func: checked});

            appendChildrenToParent([paragraphNew, span, button], li);
            adoptedList.appendChild(li);

            document.querySelector("#adoption input").parentNode.parentNode.remove();
        }
    }

    function checked(e){
        e.target.parentNode.remove();
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

  	function removeAllChildNodes(parent) {
	   while (parent.firstChild) {
		   parent.removeChild(parent.firstChild);
	   }
  	}
}

