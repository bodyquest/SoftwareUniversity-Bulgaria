function solve() {

   // add event listener
   document.querySelector("#searchBtn")
      .addEventListener("click", onSearch);
   const input = document.querySelector("#searchField");

   function onSearch(e) {
      // read the input
      const query = input.value.trim().toLocaleLowerCase();

      if (query.trim().length > 0) {
         // walk the rows and remove class="select"
         const tbody = document.querySelector("tbody");
         [...tbody.querySelectorAll("tr")]
            .forEach( r => {
               r.classList.remove("select");
            });

         // walk the cells and find matches -> 
         [...tbody.querySelectorAll("td")]
            .forEach( d => {
               if (d.textContent.trim()
               .toLocaleLowerCase()
               .includes(query)) {
                  d.parentNode.classList.add("select");
               }
            });

         // clear the field
         input.value = "";
      }
   }
}