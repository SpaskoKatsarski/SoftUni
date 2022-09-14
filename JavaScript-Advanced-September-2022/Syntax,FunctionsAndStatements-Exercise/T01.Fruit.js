function calculatePrice(fruit, grams, moneyPerKilogram) {
    let kilos = grams / 1000;

    console.log(`I need $${(kilos * moneyPerKilogram).toFixed(2)} to buy ${kilos.toFixed(2)} kilograms ${fruit}.`);
}

calculatePrice('orange', 2500, 1.80);