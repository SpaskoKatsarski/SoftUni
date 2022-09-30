function solve() {
  let buttons = document.getElementsByTagName('button');
  let textAreas = document.getElementsByTagName('textarea');
  
  buttons[0].addEventListener('click', generate);
  buttons[1].addEventListener('click', checkout);

  function generate() {
    let obj = JSON.parse(textAreas[0].value);

      let imgSrc = obj.img;
      let name = obj.name;
      let price = Number(obj.price);
      let decFactor = Number(obj.decFactor);

      document.getElementsByTagName('tbody')[0].innerHTML += `<td><img src="${imgSrc}"></td>` +
      `<td><p>${name}</p></td>` +
      `<td><p>${price}</p></td>` +
      `<td><p>${decFactor}</p></td>` +
      `<td><input type="checkbox" /></td>`;
  }

  function checkout() {
    let boughtItems = [];
    let totalPrice = 0;
    let totalDecPoints = 0;
    let totalBought = 0;
    
    let items = Array.from(document.querySelectorAll('tbody tr'));

    for (let item of items) {
      if (item.children[4].children[0].checked) {
        boughtItems.push(item.children[1].children[0].textContent) 
        totalPrice += Number(item.children[2].children[0].textContent);
        totalDecPoints += Number(item.children[3].children[0].textContent);

        totalBought++;
      }
    }
    debugger;
    textAreas[1].textContent = `Bought furniture: ${boughtItems.join(', ')}\n`;
    textAreas[1].textContent += `Total price: ${totalPrice}\n`;
    textAreas[1].textContent += `Average decoration factor: ${(totalDecPoints / totalBought).toFixed(2)}`;
  }
}