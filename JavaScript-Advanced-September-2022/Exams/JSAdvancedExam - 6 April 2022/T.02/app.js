class Garden {
    constructor(spaceAvailable) {
        this.spaceAvailable = spaceAvailable;
        this.plants = [];
        this.storage = [];
    }

    addPlant(plantName, spaceRequired) {
        if (this.spaceAvailable < spaceRequired) {
            throw new Error('Not enough space in the garden.');
        }

        this.plants.push({
            plantName,
            spaceRequired,
            ripe: false,
            quantity: 0
        });

        this.spaceAvailable -= spaceRequired;

        return `The ${plantName} has been successfully planted in the garden.`;
    }

    ripenPlant(plantName, quantity) {
        let plant = this.plants.find(p => p.plantName === plantName);

        if (!plant) {
            throw new Error(`There is no ${plantName} in the garden.`);
        }

        if (plant.ripe) {
            throw new Error(`The ${plantName} is already ripe.`);
        }

        if (quantity <= 0) {
            throw new Error('The quantity cannot be zero or negative.');
        }

        plant.ripe = true;
        plant.quantity += quantity;

        if (quantity === 1) {
            return `${quantity} ${plantName} has successfully ripened.`;
        }

        return `${quantity} ${plantName}s have successfully ripened.`;
    }

    harvestPlant(plantName) {
        let plant = this.plants.find(p => p.plantName === plantName);

        if (!plant) {
            throw new Error(`There is no ${plantName} in the garden.`);
        }

        if (!plant.ripe) {
            throw new Error(`The ${plantName} cannot be harvested before it is ripe.`);
        }

        this.plants.splice(this.plants.indexOf(plant), 1);

        this.storage.push({
            plantName,
            quantity: plant.quantity
        });

        this.spaceAvailable += plant.spaceRequired;

        return `The ${plantName} has been successfully harvested.`;
    }

    generateReport() {
        let result = [];

        result.push(`The garden has ${this.spaceAvailable} free space left.`);

        let plantsInfo = `Plants in the garden: `
        let names = [];
        let sortedPlants = this.plants.sort((a, b) => a.plantName.localeCompare(b.plantName));

        for (const plant of sortedPlants) {
            names.push(plant.plantName);
        }

        plantsInfo += names.join(', ');
        result.push(plantsInfo);

        if (this.storage.length === 0) {
            result.push('Plants in storage: The storage is empty.');
        } else {
            let storageInfo = `Plants in storage: `;
            let res = [];

            for (let plant of this.storage) {
                res.push(`${plant.plantName} (${plant.quantity})`);
            }
            storageInfo += res.join(', ');

            result.push(storageInfo);
        }

        return result.join('\n');
    }
}

const myGarden = new Garden(250)
console.log(myGarden.addPlant('apple', 20));
console.log(myGarden.addPlant('orange', 200));
console.log(myGarden.addPlant('raspberry', 10));
console.log(myGarden.ripenPlant('apple', 10));
console.log(myGarden.ripenPlant('orange', 1));
console.log(myGarden.harvestPlant('orange'));
console.log(myGarden.generateReport());