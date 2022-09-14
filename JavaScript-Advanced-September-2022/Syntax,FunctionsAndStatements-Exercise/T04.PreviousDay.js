function findPreviousDate(year, month, day) {
    let date = new Date(year, month - 1, day);

    console.log(`${date.getFullYear()}-${date.getMonth() + 1}-${date.getDate()}`);
}

findPreviousDate(2016, 6, 30);
findPreviousDate(2016, 10, 1);

let date = new Date(2021, 6 - 1, 20);
console.log(date);

console.log(date.getMonth() + 1);