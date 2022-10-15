window.addEventListener("load", solve);

function solve() {
  let makeInput = document.getElementById('make');
  let modelInput = document.getElementById('model');
  let yearInput = document.getElementById('year');
  let fuelTypeInput = document.getElementById('fuel')
  let originalPriceInput = document.getElementById('original-cost');
  let sellingPriceInput = document.getElementById('selling-price');

  let tableBody = document.getElementById('table-body');
  let soldCarsList = document.getElementById('cars-list');

  let profitEl = document.getElementById('profit');

  document.getElementById('publish').addEventListener('click', addToTable);

  function addToTable(event) {
    event.preventDefault();

    let make = makeInput.value;
    let model = modelInput.value;
    let year = yearInput.value;
    let fuelType = fuelTypeInput.value;
    let originalPrice = Number(originalPriceInput.value);
    let sellingPrice = Number(sellingPriceInput.value);

    if (!make || !model || !year || !fuelType || !originalPrice || !sellingPrice) {
      return;
    } else if (originalPrice > sellingPrice) {
      return;
    }

    let tableRow = document.createElement('tr');
    tableRow.classList.add('row');

    let makeTd = document.createElement('td');
    makeTd.textContent = make;

    let modelTd = document.createElement('td');
    modelTd.textContent = model;

    let yearTd = document.createElement('td');
    yearTd.textContent = year;

    let fuelTd = document.createElement('td');
    fuelTd.textContent = fuelType;

    let originalPriceTd = document.createElement('td');
    originalPriceTd.textContent = originalPrice;

    let sellingPriceTd = document.createElement('td');
    sellingPriceTd.textContent = sellingPrice;

    let buttonsTd = document.createElement('td');

    let editBtn = document.createElement('button');
    let sellBtn = document.createElement('button');

    editBtn.setAttribute('class', 'action-btn edit');
    editBtn.textContent = 'Edit';
    editBtn.addEventListener('click', returnInfo);

    function returnInfo(event) {
      let carInfo = getCarInfo(event.target);

      let make = carInfo[0];
      let model = carInfo[1];
      let year = carInfo[2];
      let fuelType = carInfo[3];
      let orgCost = carInfo[4];
      let newPrice = carInfo[5];

      makeInput.value = make;
      modelInput.value = model;
      yearInput.value = year;
      fuelTypeInput.value = fuelType;
      originalPriceInput.value = orgCost;
      sellingPriceInput.value = newPrice;

      event.target.parentElement.parentElement.remove();
    }

    sellBtn.setAttribute('class', 'action-btn sell');
    sellBtn.textContent = 'Sell';
    sellBtn.addEventListener('click', publish);

    function publish(event) {
      let li = document.createElement('li');
      li.classList.add('each-list');

      let carInfo = getCarInfo(event.target);

      let makeAndModelSpan = document.createElement('span');
      makeAndModelSpan.textContent = `${carInfo[0]} ${carInfo[1]}`;

      let yearSpan = document.createElement('span');
      yearSpan.textContent = carInfo[2];

      let profitSpan = document.createElement('span');
      let profit = Number(carInfo[5]) - Number(carInfo[4]);
      profitSpan.textContent = profit;

      li.appendChild(makeAndModelSpan);
      li.appendChild(yearSpan);
      li.appendChild(profitSpan);

      soldCarsList.appendChild(li);
      profitEl.textContent = (Number(profitEl.textContent.substring(0, profitEl.textContent.indexOf('.'))) + profit).toFixed(2);

      event.target.parentElement.parentElement.remove();
    }

    buttonsTd.appendChild(editBtn);
    buttonsTd.appendChild(sellBtn);

    tableRow.appendChild(makeTd);
    tableRow.appendChild(modelTd);
    tableRow.appendChild(yearTd);
    tableRow.appendChild(fuelTd);
    tableRow.appendChild(originalPriceTd);
    tableRow.appendChild(sellingPriceTd);
    tableRow.appendChild(buttonsTd);

    tableBody.appendChild(tableRow);

    makeInput.value = '';
    modelInput.value = '';
    yearInput.value = '';
    fuelTypeInput.value = '';
    originalPriceInput.value = '';
    sellingPriceInput.value = '';
  }

  function getCarInfo(clickedButtom) {
      let make = clickedButtom.parentElement.parentElement.getElementsByTagName('td')[0].textContent;
      let model = clickedButtom.parentElement.parentElement.getElementsByTagName('td')[1].textContent;
      let year = clickedButtom.parentElement.parentElement.getElementsByTagName('td')[2].textContent;
      let fuelType = clickedButtom.parentElement.parentElement.getElementsByTagName('td')[3].textContent;
      let orgCost = clickedButtom.parentElement.parentElement.getElementsByTagName('td')[4].textContent;
      let newPrice = clickedButtom.parentElement.parentElement.getElementsByTagName('td')[5].textContent;

      return [make, model, year, fuelType, orgCost, newPrice];
  }
}