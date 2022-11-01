async function getInfo() {
    let stopIdEl = document.getElementById('stopId');
    let stopId = stopIdEl.value;
    let url = `http://localhost:3030/jsonstore/bus/businfo/${stopId}`;
    let stopEl = document.getElementById('stopName');
    let busesEl = document.getElementById('buses');

    busesEl.innerHTML = '';
    stopIdEl.value = '';

    try {
        let response = await fetch(url);
        let data = await response.json();

        stopEl.textContent = data.name;
        Object.entries(data.buses).forEach(([k, v]) => {
            let li = document.createElement('li');
            li.textContent = `Bus ${k} arrives in ${v} minutes`;

            busesEl.appendChild(li);
        })
    } catch (e) {
        stopEl.textContent = 'Error';
    }
}