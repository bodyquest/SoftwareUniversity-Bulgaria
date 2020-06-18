function solve(){
    const main = document.querySelector("main > section");
    const archive = document.querySelector(".archive-section > ul");

    document.querySelector("button.btn.create").addEventListener("click", createArticle);
    

    function createArticle(e){
        e.preventDefault();

        const title = document.querySelector("#title").value;
        const creator = document.querySelector("#creator").value;
        const category = document.querySelector("#category").value;
        const content = document.querySelector("#content").value;

        const deleteBtn = el("button", "Delete", {className: "btn delete"});
        const archiveBtn = el("button", "Archive", {className: "btn archive"});

        deleteBtn.addEventListener("click", () => {
            main.removeChild(article);
        });

        archiveBtn.addEventListener("click", () => {
            main.removeChild(article);
            archive.appendChild(el("li", title));

            const items = [...archive.querySelectorAll("li")];

            // remove all elements in order to sort and visualize again in HTML
            archive.innerHTML = "";

            // sort and visualize again in HTML
            items.sort((a, b) => a.textContent.localeCompare(b.textContent))
                .forEach(el => archive.appendChild(el));
        });

        const article = el("article", [
            el("h1", title),
            el("p", ["Category: ", el("strong", category)]),
            el("p", ["Creator: ", el("strong", creator)]),
            el("p", content),
            el("div", [deleteBtn, archiveBtn], {className: "buttons"})
        ]);

        main.appendChild(article);
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
