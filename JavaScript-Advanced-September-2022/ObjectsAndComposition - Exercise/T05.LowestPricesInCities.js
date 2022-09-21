function solve(info) {
    let result = {};

    for (const part of info) {
        let currPart = part.split(' | ');
        let town = currPart[0];
        let product = currPart[1];
        let price = Number(currPart[2]);

        if (!result.hasOwnProperty(product)) {
            let obj = {
                name: product,
                price,
                town,
            }

            // result.push(obj);
            result[product] = obj;
        } else {
            //We have a product with the same name and now we have to compare their price.
            let previousPrice = result[product].price;

            if (price < previousPrice) {
                let obj = {
                    name: product,
                    price,
                    town,
                }

                delete result[product];
                result[product] = obj;
            }
        }
    }

    for (const el in result) {
        console.log(`${el} -> ${result[el].price} (${result[el].town})`) //NoOffenseToCarLovers becomes first idk why, check it
    }
}

solve(['Sofia City | Audi | 100000',
'Sofia City | BMW | 100000',
'Sofia City | Mitsubishi | 10000',
'Sofia City | Mercedes | 10000',
'Sofia City | NoOffenseToCarLovers | 0',
'Mexico City | Audi | 1000',
'Mexico City | BMW | 99999',
'Mexico City | Mitsubishi | 10000',
'New York City | Mitsubishi | 1000',
'Washington City | Mercedes | 1000']);