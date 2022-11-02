function solve() {
    let infoEl = document.getElementById('info').getElementsByClassName('info')[0];
    let departBtn = document.getElementById('depart');
    let arriveBtn = document.getElementById('arrive');

    let nextStop = 'depot';
    let nextStopData;

    async function depart() {
        departBtn.disabled = true;
        arriveBtn.disabled = false;

        nextStopData = await getStopData(nextStop);
        infoEl.textContent = `Next stop ${nextStopData.name}`;
    }

    function arrive() {
        arriveBtn.disabled = true;
        departBtn.disabled = false;

        infoEl.textContent = `Arriving at ${nextStopData.name}`;
        nextStop = nextStopData.next;
    }

    async function getStopData(id) {
        try {
            let response = await fetch(`http://localhost:3030/jsonstore/bus/schedule/${id}`);
            let stopData = await response.json();

            return stopData;
        } catch (e) {
            infoEl.textContent = 'Error';
            departBtn.disabled = true;
            arriveBtn.disabled = true;
        }
    }

    return {
        depart,
        arrive
    }
}

let result = solve();