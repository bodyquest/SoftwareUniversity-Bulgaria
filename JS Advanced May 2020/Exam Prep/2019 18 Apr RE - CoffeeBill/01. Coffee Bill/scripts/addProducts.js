function addProduct(){

    const [product, price] = Array.from(document.querySelectorAll("#add-product input"));
    const list = document.querySelector("#product-list");
    const totalSum = document.querySelectorAll("tfoot td")[1];

    const addBtn = document.querySelector("button");
    addBtn.addEventListener("click", addIt);

    let total = 0;

    function addIt(e){

        if (product.value && Number(price.value)) {
            let productTr = createHTML("tr");
            let productTdName = createHTML("td", null, product.value)
            let productTd = createHTML("td", null, Number(price.value).toFixed(2));

            appendChildrenToParent([productTdName, productTd], productTr);
            list.appendChild(productTr);

            //parse to number
            total += Number(price.value);
            totalSum.textContent = `${(total).toFixed(2)}` // get two decimal points
        }

        product.value = "";
        price.value = "";
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