function solve(arr) {
    let result = [];

    for (let el of arr.slice(1)) {
        el = el.substring(1, el.length - 2)
        .split(' | ')
        .map(el => el.trim());

        let town = el[0];
        let latitude = Number(Number(el[1]).toFixed(2));
        let longitude = Number(Number(el[2]).toFixed(2));

        result.push({
            'Town': town,
            'Latitude': latitude,
            'Longitude': longitude
        })
    }

    return JSON.stringify(result);
}

console.log(solve(['| Town | Latitude | Longitude |',
'| Sofia | 42.696552 | 23.32601 |',
'| Beijing | 39.913818 | 116.363625 |']));