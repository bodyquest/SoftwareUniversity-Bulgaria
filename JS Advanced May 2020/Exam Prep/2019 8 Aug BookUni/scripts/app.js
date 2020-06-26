function solve(){

    const $elements = {
        bookInput: document.querySelectorAll("form input")[0],
        yearInput: document.querySelectorAll("form input")[1],
        yearPrice: document.querySelectorAll("form input")[2],
        addBookBtn: document.querySelector("form button"),
        oldBooks: document.querySelectorAll("#outputs div")[0],
        newBooks: document.querySelectorAll("#outputs div")[1],
        profitHeader: document.querySelectorAll("h1")[1]
    }

    let totalSum = 0;

    $elements.addBookBtn.addEventListener("click", addBook);

    function addBook(e){
        e.preventDefault();
        const title = $elements.bookInput.value;
        const year = Number($elements.yearInput.value);
        const price = Number($elements.yearPrice.value);

        if (title !== "" && year > 0 && price > 0) {
            if (year >= 2000) {
                createBook(false, title, year, price, $elements.newBooks);
            }
            else{
                createBook(true, title, year, price, $elements.oldBooks);
            }
        }
    }

    function createBook(isOld, title, year, price, shelf){
        price = isOld ? price * 0.85 : price;
        const bookElement = document.createElement("div");
                
        const p = document.createElement("p");
        const buyBtn = document.createElement("button");
        
        bookElement.classList.add("book");
        p.textContent = `${title} [${year}]`;
        buyBtn.textContent = `Buy it only for ${price.toFixed(2)} BGN`;
        
        buyBtn.addEventListener("click", buyBook);
        function buyBook(e){
            totalSum += price;
            e.target.parentNode.parentNode.removeChild(e.target.parentNode);

            $elements.profitHeader.textContent = `Total Store Profit: ${totalSum.toFixed(2)} BGN`;
        }

        bookElement.appendChild(p);
        bookElement.appendChild(buyBtn);
        
        if (!isOld) {
            const moveBtn = document.createElement("button");
            moveBtn.textContent = `Move to old section`;
            bookElement.appendChild(moveBtn);

            moveBtn.addEventListener("click", moveBook);

            function moveBook(e){
                e.target.parentNode.parentNode.removeChild(e.target.parentNode);

                createBook(true, title, year, price, $elements.oldBooks)
            }
        }

        shelf.appendChild(bookElement);
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
}