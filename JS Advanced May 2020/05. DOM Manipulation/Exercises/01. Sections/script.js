function create(words) {
   const content = document.getElementById("content");

   for (const word of words) {
      let div = document.createElement("div");
      let paragraph = document.createElement("p");

      paragraph.innerHTML = word;
      paragraph.style.display = "none";

      div.appendChild(paragraph);
      div.addEventListener("click", () => {
         paragraph.style.display = "block";
      });
      
      content.appendChild(div);
   }
}