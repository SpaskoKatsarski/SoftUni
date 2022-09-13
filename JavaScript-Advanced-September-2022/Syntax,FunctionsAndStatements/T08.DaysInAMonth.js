function getDays(month, year) {
    return new Date(year, month, 0).getDate();
};

let daysInSeptember = getDays(2021, 7);
console.log(daysInSeptember);


