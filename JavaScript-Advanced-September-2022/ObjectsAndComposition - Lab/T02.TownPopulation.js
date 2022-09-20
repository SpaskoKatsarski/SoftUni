function solve(towns) {
    let result = {};
    
    for (const town of towns) {
        let currTown = town.split(' <-> ');
        if (Object.keys(result).some(k => k === currTown[0])) {
            result[currTown[0]] += Number(currTown[1]);
        } else {
            result[currTown[0]] = Number(currTown[1]);
        }
    }

    for (const town in result) {
        console.log(`${town} : ${result[town]}`);
    }
}

solve(['Istanbul <-> 100000',
'Honk Kong <-> 2100004',
'Jerusalem <-> 2352344',
'Mexico City <-> 23401925',
'Istanbul <-> 1000']);