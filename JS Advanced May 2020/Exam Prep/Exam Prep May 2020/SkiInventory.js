function solve(){
    const products = document.querySelector("#products ul");
    const order = document.querySelector("#myProducts ul");

    const form = document.querySelector("#add-new");
    const inputName = form[1];
    const inputQty = form[2];
    const inputPrice = form[3];

    form[4].addEventListener("click", addProduct);
    const filterInput = document.querySelector("#filter");
    document.querySelector(".filter button").addEventListener("click", filter);

    function filter(e){
        const query = filterInput.value.trim().toLowerCase();
        Array.from(products.querySelector("li")).forEach(p => {
            
            if (p.children[0].textContent.toLowerCase().includes(query)) {
                p.style.display = "";
            }else{
                p.style.display = "none";
            }
        });
    }

    let currentPrice = 0;

    function addProduct(e){
        e.preventDefault();

        const name = inputName.value;
        let qty = Number(inputQty.value);
        const price = Number(inputPrice.value);

        const qtyStrong = el("strong", `Available: ${qty}`);
        const addBtn = el("button", "Add to Client\s List");

        const product = el("li", [
            el("span", name),
            qtyStrong,
            el("div", [
                el("strong", price),
                addBtn
            ])
        ]);

        addBtn.addEventListener("click", (e) => {
            order.appendChild(el("li", [
                name,
                el("strong", price)
            ]));

            qty --;
            if (qty === 0) {
                product.remove();
            }else{
                qtyStrong.textContent = `Available: ${qty}`;
            }
        })


        products.appendChild(product);
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
            if (typeof node === "string" || typeof node === "number") {
                node = document.createTextNode(node);
            }
  
            result.appendChild(node);
        }
  
        return result;
    }
}