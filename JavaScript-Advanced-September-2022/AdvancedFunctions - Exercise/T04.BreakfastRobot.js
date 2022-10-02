function solution() {
    let store = {
        protein: 0,
        carbohydrate: 0,
        fat: 0,
        flavour: 0
    }

    let recipesEnum = {
        apple: { carbohydrate: 1, flavour: 2},
        lemonade: { carbohydrate: 10, flavour: 20 },
        burger: { carbohydrate: 5, fat: 7, flavour: 3 },
        eggs: { protein: 5, fat: 1, flavour: 1 },
        turkey: { protein: 10, carbohydrate: 10, fat: 10, flavour: 10 }
    }

    let manager = cmdExecutor();
    return (input) => {
        let [action, arg1, arg2] = input.split(' ');
        return manager[action](arg1, arg2);
    }

    function cmdExecutor() {
        return {
            restock: (microelement, quantity) => {
                store[microelement] += Number(quantity);
                return 'Success';
            },
            prepare: (recipe, quantity) => {
                let storeCopy = Object.create(store);
                let foodToPrepare = recipesEnum[recipe]; 

                //apple: { carbohydrate: 1, flavour: 2} - needed 1 * quantity carbs and 2 * quantity flavours
                for (const microElement of Object.keys(foodToPrepare)) {
                    if (foodToPrepare[microElement] * Number(quantity) > storeCopy[microElement]) { 
                        return `Error: not enough ${microElement} in stock`;
                    }

                    storeCopy[microElement] -= foodToPrepare[microElement] * Number(quantity);
                }

                store = storeCopy;
                return 'Success';
            },
            report: () => {
                return `protein=${store['protein']} carbohydrate=${store['carbohydrate']} fat=${store['fat']} flavour=${store['flavour']}`;
            }
        }
    }
}

let manager = solution (); 
console.log (manager ("restock flavour 50")); // Success 
console.log (manager ("prepare lemonade 4")); // Error: not enough carbohydrate in stock 