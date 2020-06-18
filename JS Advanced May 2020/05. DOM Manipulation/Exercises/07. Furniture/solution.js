function solve() {
  const tbody = document.querySelector("tbody");

  // add listener to first btn
  const [generate, buy] = [...document.querySelectorAll("button")];
  const [input, output] = [...document.querySelectorAll("textarea")];

  generate.addEventListener("click", onGenerate);
  buy.addEventListener("click", onBuy);

  function onGenerate(e) {
    // read the input
    const data = JSON.parse(input.value);
    // for each element add the content to table
    for (let item of data) {
      const row = document.createElement("tr");
      const html = `<td><img src="${item.img}"></td><td><p>${item.name}</p></td><td><p>${item.price}</p></td><td><p>${item.decFactor}</p></td><td><input type="checkbox" /></td>`;
    row.innerHTML = html;
    tbody.appendChild(row);
    }
  }
  function onBuy(e) {
    // walk the table and get the selected result
    const bought = [...tbody.querySelectorAll("input")]
      .filter(i => i.checked)
      .map(i => i.parentNode.parentNode)
      .map(row => ({
        name: row.children[1].textContent.trim(),
        price: Number(row.children[2].textContent),
        decFactor: Number(row.children[3].textContent)
      }));
       
      const result = [
        `Bought furniture: ${bought.map(i => i.name).join(", ")}`,
        `Total price: ${bought.reduce((p, c, i, a) => p + c.price, 0).toFixed(2)}`,
        `Average decoration factor: ${bought.reduce((p, c, i, a) => p + c.decFactor, 0)/ bought.length}`
      ];

      output.value = result.join("\n");
  }
}