let firstArr = ['1', '2', '3'];
firstArr.map(Number);

console.log(typeof firstArr[0]);

let query = 'ko';

let names = ['Spasko', 'Danko', 'Bobi', 'Branko', 'Some random name...!!!'];

names = names.filter(n => {
    return n.toLowerCase().indexOf(query.toLowerCase()) >= 0; 
});

console.log(names);