function greeting() {
    console.log('Hello there!')
}

greeting();

function calculateMoneyPerDay(monthlySalary) {
    let moneyPerDay = monthlySalary / 30;

    console.log('Daily salary: ' + moneyPerDay.toFixed(2));
}

calculateMoneyPerDay(1500);

function findDuplicates(text) {
        let strArr = text.split(" ");
        let res = [];

        for(let i = 0; i < strArr.length; i++){
           if(strArr.indexOf(strArr[i]) !== strArr.lastIndexOf(strArr[i])){
              if(!res.includes(strArr[i])){
                 res.push(strArr[i]);
              };
           };
        };
        
        console.log('Duplicates: ')
        console.log(res.join('\n'));
}

let str = 'This is text where I show my love for my dog. I really like to show my love for my dog, cause she is really a very cute dog!'
findDuplicates(str);