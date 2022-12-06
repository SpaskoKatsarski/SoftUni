window.addEventListener("load", solve);

function solve() {
  const tableBody = document.getElementById('table-body');
  const soldCarsList = document.getElementById('cars-list');
  const profitEl = document.getElementById('profit');

  document.getElementById('publish').addEventListener('click', onPublish);

  const makeInput = document.getElementById('make');
  const modelInput = document.getElementById('model');
  const yearInput = document.getElementById('year');
  const fuelInput = document.getElementById('fuel');
  const originalCostInput = document.getElementById('original-cost');
  const sellingPriceInput = document.getElementById('selling-price');

  function onPublish(e) {
    e.preventDefault();

    const make = makeInput.value;
    const model = modelInput.value;
    const year = yearInput.value;
    const fuel = fuelInput.value;
    const orgCost = originalCostInput.value;
    const sellPrice = sellingPriceInput.value;

    if (!make || !model || !year || !fuel || !orgCost || !sellPrice) {
      return;
    }

    if (Number(orgCost) >= Number(sellPrice)) {
      return;
    }

    const tr = document.createElement('tr');
    tr.classList.add('row');

    const makeTd = document.createElement('td');
    makeTd.textContent = make;

    const modelTd = document.createElement('td');
    modelTd.textContent = model;

    const yearTd = document.createElement('td');
    yearTd.textContent = year;

    const fuelTd = document.createElement('td');
    fuelTd.textContent = fuel;

    const orgCostTd = document.createElement('td');
    orgCostTd.textContent = orgCost;

    const sellPriceTd = document.createElement('td');
    sellPriceTd.textContent = sellPrice;

    const editBtn = document.createElement('button');
    editBtn.textContent = 'Edit';
    editBtn.setAttribute('class', 'action-btn edit');
    editBtn.addEventListener('click', onEdit);

    const sellBtn = document.createElement('button');
    sellBtn.textContent = 'Sell';
    sellBtn.setAttribute('class', 'action-btn sell');
    sellBtn.addEventListener('click', onSell);

    const btnTd = document.createElement('td');

    btnTd.appendChild(editBtn);
    btnTd.appendChild(sellBtn);

    tr.appendChild(makeTd);
    tr.appendChild(modelTd);
    tr.appendChild(yearTd);
    tr.appendChild(fuelTd);
    tr.appendChild(orgCostTd);
    tr.appendChild(sellPriceTd);

    tr.appendChild(btnTd);

    tableBody.appendChild(tr);

    makeInput.value = '';
    modelInput.value = '';
    yearInput.value = '';
    fuelInput.value = '';
    originalCostInput.value = '';
    sellingPriceInput.value = '';
  }

  function onEdit(e) {
    const tr = e.target.parentElement.parentElement;

    makeInput.value = tr.children[0].textContent;
    modelInput.value = tr.children[1].textContent;
    yearInput.value = tr.children[2].textContent;
    fuelInput.value = tr.children[3].textContent;
    originalCostInput.value = tr.children[4].textContent;
    sellingPriceInput.value = tr.children[5].textContent;

    tr.remove();
  }

  function onSell(e) {
    const tr = e.target.parentElement.parentElement;

    const li = document.createElement('li');
    li.classList.add('each-list');

    const makeSpan = document.createElement('span');
    makeSpan.textContent = `${tr.children[0].textContent} ${tr.children[1].textContent}`;

    const yearSpan = document.createElement('span');
    yearSpan.textContent = tr.children[2].textContent;

    const profitSpan = document.createElement('span');
    const profit = Number(tr.children[5].textContent) - Number(tr.children[4].textContent);
    profitSpan.textContent = profit;

    li.appendChild(makeSpan);
    li.appendChild(yearSpan);
    li.appendChild(profitSpan);
    soldCarsList.appendChild(li);

    profitEl.textContent = (Number(profitEl.textContent) + profit).toFixed(2);
    tr.remove();
  }
}
