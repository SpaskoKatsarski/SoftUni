let iconsEnum = {
    'Sunny': '&#x2600',
    'Partly sunny': '&#x26C5',
    'Overcast': '&#x2601',
    'Rain': '&#x2614',
    'Degrees': '&#176'
}

let currentDiv = document.getElementById('current');
let upcomingDiv = document.getElementById('upcoming');

let forecastDiv = document.getElementById('forecast');

function attachEvents() {
    document.getElementById('submit').addEventListener('click', getWeather)
}

async function getWeather() {
    try {
        let location = document.getElementById('location').value;
        let url = 'http://localhost:3030/jsonstore/forecaster/locations';
        let response = await fetch(url);
        let data = await response.json();
    
        let info = data.find(x => x.name === location);
    
        createForcaster(info.code);
    } catch (e) {
        forecastDiv.style.display = 'block';
        forecastDiv.textContent = 'Error';
    }
}

async function createForcaster(code) {
    let todayUrl = `http://localhost:3030/jsonstore/forecaster/today/${code}`;
    let tomorrowUrl = `http://localhost:3030/jsonstore/forecaster/upcoming/${code}`;

    let responseToday = await fetch(todayUrl);
    let dataForToday = await responseToday.json();

    let responseTomorrow = await fetch(tomorrowUrl);
    let dataForTomorrow = await responseTomorrow.json();

    let todayForecast = createToday(dataForToday);
    currentDiv.appendChild(todayForecast);

    let tomorrowForecast = createTomorrow(dataForTomorrow);
    upcomingDiv.appendChild(tomorrowForecast);

    forecastDiv.style.display = 'block';

    function createTomorrow(data) {
        let result = [];

        for (const day of data.forecast) {
            let { condition, high, low } = day;

            let upcomingSpan = document.createElement('span');
            upcomingSpan.classList.add('upcoming');

            let symbolSpan = document.createElement('span');
            symbolSpan.classList.add('symbol');
            symbolSpan.innerHTML = iconsEnum[condition];

            let firstDataSpan = document.createElement('span');
            firstDataSpan.classList.add('forecast-data');
            firstDataSpan.innerHTML = `${low}${iconsEnum['Degrees']}/${high}${iconsEnum['Degrees']}`;

            let secondDataSpan = document.createElement('span');
            secondDataSpan.classList.add('forecast-data');
            secondDataSpan.textContent = condition;

            upcomingSpan.appendChild(symbolSpan);
            upcomingSpan.appendChild(firstDataSpan);
            upcomingSpan.appendChild(secondDataSpan);

            result.push(upcomingSpan);
        }

        let div = document.createElement('div');
        div.classList.add('forecast-info');

        for (const template of result) {
            div.appendChild(template);
        }

        return div;
    }

    function createToday(data) {
        let { condition, high, low } = data.forecast;

        let div = document.createElement('div');
        div.classList.add('forecasts');

        let symbolSpan = document.createElement('span');
        symbolSpan.classList.add('condition', 'symbol');
        symbolSpan.innerHTML = iconsEnum[condition];

        let parentSpan = document.createElement('span');
        parentSpan.classList.add('condition');

        let span1 = document.createElement('span');
        span1.classList.add('forecast-data');
        span1.textContent = data.name;

        let span2 = document.createElement('span');
        span2.classList.add('forecast-data');
        span2.innerHTML = `${low}${iconsEnum['Degrees']}/${high}${iconsEnum['Degrees']}`

        let span3 = document.createElement('span');
        span3.classList.add('forecast-data');
        span3.textContent = condition;

        parentSpan.appendChild(span1);
        parentSpan.appendChild(span2);
        parentSpan.appendChild(span3);

        div.appendChild(symbolSpan);
        div.appendChild(parentSpan);

        return div;
    }
}

attachEvents();