function solve(input) {
    let cars = new Map();

    for (let el of input) {
        let [ brand, model, quantity ] = el.split(' | ');

        if (!cars.has(brand)) {
            cars.set(brand, new Map());
        }

        let models = cars.get(brand);

        if (!models.has(model)) {
            models.set(model, 0);
        }

        models.set(model, models.get(model) + Number(quantity));
    }

    for (let [brand, models] of cars) {
        console.log(brand);

        for (let [model, quant] of models) {
            console.log(`###${model} -> ${quant}`);
        }
    }
}

solve(['Audi | Q7 | 1000',
'Audi | Q6 | 100',
'Audi | Q6 | 1000',
'BMW | X6 | 100',
'Citroen | C4 | 123',
'Volga | GAZ-24 | 1000000',
'Lada | Niva | 1000000',
'Lada | Jigula | 1000000',
'Citroen | C4 | 22',
'Citroen | C5 | 10']);