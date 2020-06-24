function solve() {
   
   $elements = {
      inventory: document.querySelector("#products ul"),
      filterBtn: document.querySelector("#products button"),
      filterInput: document.querySelector("#filter"),
      addProducts: document.querySelector("#add-new"),
      addBtn: document.querySelector("form button"),
      myProducts: document.querySelector("#myProducts ul"),
      buyBtn: document.querySelector("#myProducts button"),
      totalPrice: document.querySelectorAll("h1")
   }

   let totalSum = 0;
   const inventoryList = [];

   $elements.addBtn.addEventListener("click", addProduct);
   $elements.filterBtn.addEventListener("click", filterProducts);
   $elements.buyBtn.addEventListener("click", buyProducts);

   function addProduct(e){
      e.preventDefault();

      let name =  document.querySelectorAll("form input")[0].value;
      let qty = Number(document.querySelectorAll("form input")[1].value);
      let price =  Number(document.querySelectorAll("form input")[2].value);

      let productLi = createHTML("li");
      let productSpan = createHTML("span", null, name);
      let productStrong = createHTML("strong", null, `Available: ${qty}`);
      let productDiv = createHTML("div");
      let productDivStrong = createHTML("strong", null, price.toFixed(2));
      let productDivBtn = createHTML("button", null, "Add to Client\'s List", null, {name: "click", func: addToList});

      productDiv.appendChild(productDivStrong);
      productDiv.appendChild(productDivBtn);

      productLi = appendChildrenToParent (
         [productSpan, productStrong, productDiv], productLi
      )

      $elements.inventory.appendChild(productLi);

      inventoryList.push({
         name,
         qty,
         price
      });
   }

   function addToList(e){
      let name = e.target.parentNode.parentNode.children[0].textContent;
      let qty = e.target.parentNode.parentNode.children[1];
      
      const product = inventoryList.find(p => p.name === name);
      
      let productLi = createHTML("li", null, `${name}`);
      let productStrong = createHTML("strong", null, `${product.price.toFixed(2)}`);

      productLi.appendChild(productStrong);
      $elements.myProducts.appendChild(productLi);

      totalSum +=  product.price;
      $elements.totalPrice[1].textContent = `Total Price: ${(totalSum).toFixed(2)}`;

      let index = inventoryList.findIndex(p => p.name === name);
      if (product.qty > 0) {
         product.qty -=1;
         qty.textContent = `Available: ${product.qty}`;

         if (product.qty === 0) {
            inventoryList.splice(index, 1);
            const parent = e.target.parentNode.parentNode;
            parent.remove();
         }
      }
   }

   function buyProducts(e){
      removeAllChildNodes($elements.myProducts);
      $elements.totalPrice[1].textContent = `Total Price: ${(Number(0)).toFixed(2)}`;
   }

   function filterProducts(e){
      let filterValue = $elements.filterInput.value;

      Array.from($elements.inventory.children).forEach(el => {
         let productName = el.querySelector("span").textContent;

         if (productName.toLowerCase().includes(filterValue.toLowerCase())) {
            el.style.display = "block";
         }
         else{
            el.style.display = "none";
         }
      })

      $elements.filterInput.value = "";
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