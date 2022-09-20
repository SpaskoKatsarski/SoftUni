function cityTaxes(name, population, treasury) {
    let obj = {
        name,
        population,
        treasury
    }

    let collectTaxes = function () {
        Math.floor(this.treasury += this.population * this.taxRate);
    }
    let applyGrowth = function (percentage) {
        Math.floor(this.population += this.population * percentage / 100);
    }
    let applyRecession = function (percentage) {
        Math.floor(this.treasury -= this.treasury * percentage / 100);
    }

    obj.taxRate = 10;
    obj.collectTaxes = collectTaxes;
    obj.applyGrowth = applyGrowth;
    obj.applyRecession = applyRecession;

    return obj;
}

const city =
  cityTaxes('Tortuga',
  7000,
  15000);
city.collectTaxes();
console.log(city.treasury);
city.applyGrowth(5);
console.log(city.population);