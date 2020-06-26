function acceptance() {
	
	$elements = {
		acceptanceForm: document.querySelector("#acceptanceForm"),
		company: document.querySelector("#fields input[name='shippingCompany']"),
		product: document.querySelector("#fields input[name='productName']"),
		quantity: document.querySelector("#fields input[name='productQuantity']"),
		scrape: document.querySelector("#fields input[name='productScrape']"),
		addBtn: document.querySelector("#acceptance"),
		warehouse: document.querySelector("#warehouse")
	}

	$elements.addBtn.addEventListener("click", addIt);

	function addIt (e){
		if ($elements.company.value 
			&& $elements.product.value
			&& Number($elements.quantity.value)
			&& Number($elements.scrape.value)) {
			
			let finalQty = Number($elements.quantity.value) - Number($elements.scrape.value);

			if (finalQty <= 0) {
				return;
			}

			let productDiv = createHTML("div");
			let paragraph = createHTML("p", null, `[${$elements.company.value}] ${$elements.product.value} - ${finalQty}`);
			let btn = createHTML("button", null, "Out of Stock" , [{k: "type", v: "button"}], {name: "click", func: outOfStock});

			appendChildrenToParent([paragraph, btn], productDiv);
			$elements.warehouse.appendChild(productDiv);
		}

		$elements.company.value = "";
		$elements.product.value = "";
		$elements.quantity.value = "";
		$elements.scrape.value = "";
	}

	function outOfStock(e){
		let parent = e.target.parentNode;
		removeAllChildNodes(parent);
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