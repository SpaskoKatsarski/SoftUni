function solve(info) {
    const neededQuantityForBottle = 1000;

    let bottles = new Map();
    let productsAndQuantity = new Map();

    for (let product of info) {
        product = product.split(' => ');

        let name = product[0];
        let quantity = Number(product[1]);

        if (!productsAndQuantity.has(name)) {
            productsAndQuantity.set(name, 0);
        }

        productsAndQuantity.set(name, productsAndQuantity.get(name) + quantity);

        if (productsAndQuantity.get(name) >= neededQuantityForBottle) {
            if (!bottles.has(name)) {
                bottles.set(name, 0);
            }

            let num = (productsAndQuantity.get(name) / neededQuantityForBottle).toString();
            let indexOfDot = num.indexOf('.');

            let bottlesCount = 0;

            if (indexOfDot === -1) {
                bottlesCount = Number(num);
            } else {
                bottlesCount = Number(num.substring(0, num.indexOf('.')));
            }

            bottles.set(name, bottles.get(name) + bottlesCount);
            productsAndQuantity.set(name, productsAndQuantity.get(name) - bottlesCount * neededQuantityForBottle);
        }
    }

    for (let [product, bottlesCount] of bottles) {
        console.log(`${product} => ${bottlesCount}`);
    }
} 


solve(['Orange => 2000',
'Peach => 1432',
'Banana => 450',
'Peach => 600',
'Strawberry => 549']);