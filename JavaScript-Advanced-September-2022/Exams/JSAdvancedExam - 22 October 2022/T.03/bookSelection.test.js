const { expect } = require('chai');
const chooseYourCar = require('./app');

describe('Testing chooseCar', () => {
    describe('choosingType function', () => {
        it('should throw error if year is invalid', () => {
            expect(() => {
                chooseYourCar.choosingType('Combi', 'red', 1899);
            }).to.throw(Error, 'Invalid Year!');

            expect(() => {
                chooseYourCar.choosingType('Combi', 'red', 1756);
            }).to.throw(Error, 'Invalid Year!');

            expect(() => {
                chooseYourCar.choosingType('Combi', 'red', 2023);
            }).to.throw(Error, 'Invalid Year!');

            expect(() => {
                chooseYourCar.choosingType('Combi', 'red', 3051);
            }).to.throw(Error, 'Invalid Year!');
        });

        it('should throw error if type is not Sedan', () => {
            expect(() => {
                chooseYourCar.choosingType('SomeType', 'red', 2015);
            }).to.throw(Error, 'This type of car is not what you are looking for.');

            expect(() => {
                chooseYourCar.choosingType('SomeType', 'red', 1900);
            }).to.throw(Error, 'This type of car is not what you are looking for.');

            expect(() => {
                chooseYourCar.choosingType('SomeType', 'red', 2022);
            }).to.throw(Error, 'This type of car is not what you are looking for.');
            
        });

        it('should return message if year >= 2010', () => {
            expect(chooseYourCar.choosingType('Sedan', 'red', 2010)).to.be.equal('This red Sedan meets the requirements, that you have.');
            expect(chooseYourCar.choosingType('Sedan', 'red', 2015)).to.be.equal('This red Sedan meets the requirements, that you have.');
            expect(chooseYourCar.choosingType('Sedan', 'red', 2022)).to.be.equal('This red Sedan meets the requirements, that you have.');
        });

        it('should return message if year is not >= 2010', () => {
            expect(chooseYourCar.choosingType('Sedan', 'red', 2009)).to.be.equal('This Sedan is too old for you, especially with that red color.');
            expect(chooseYourCar.choosingType('Sedan', 'red', 2003)).to.be.equal('This Sedan is too old for you, especially with that red color.');
            expect(chooseYourCar.choosingType('Sedan', 'red', 1900)).to.be.equal('This Sedan is too old for you, especially with that red color.');
        });
    });

    describe('brandName function', () => {
        it('should throw an error with invalid parameters', () => {
            expect(() => {
                chooseYourCar.brandName('hello', 5);
            }).to.throw(Error, 'Invalid Information!');

            expect(() => {
                chooseYourCar.brandName([], 'spasko');
            }).to.throw(Error, 'Invalid Information!');

            expect(() => {
                chooseYourCar.brandName('hello', {});
            }).to.throw(Error, 'Invalid Information!');

            expect(() => {
                chooseYourCar.brandName({}, new Date());
            }).to.throw(Error, 'Invalid Information!');

            expect(() => {
                chooseYourCar.brandName(['b', 'h', 'c', 'h'], -1);
            }).to.throw(Error, 'Invalid Information!');

            expect(() => {
                chooseYourCar.brandName(['b', 'h', 'c', 'h'], 4);
            }).to.throw(Error, 'Invalid Information!');

            expect(() => {
                chooseYourCar.brandName(['b', 'h', 'c', 'h'], -123);
            }).to.throw(Error, 'Invalid Information!');

            expect(() => {
                chooseYourCar.brandName(['b', 'h', 'c', 'h'], 5);
            }).to.throw(Error, 'Invalid Information!');

            expect(() => {
                chooseYourCar.brandName(['b', 'h', 'c', 'h'], 55);
            }).to.throw(Error, 'Invalid Information!');
        });

        it('should remove the index brand', () => {
            let brands = ['BMW', 'Skoda', 'Fiat', 'Mazda'];

            let cars = chooseYourCar.brandName(brands, 1);

            expect(cars.length).to.be.equal(16);
        });
    });

    describe('carFuelConsumption function', () => {
        it('should throw an exception if invalid paramteres', () => {
            expect(() => {
                chooseYourCar.carFuelConsumption('Spasko', 15);
            }).to.throw(Error, 'Invalid Information!');

            expect(() => {
                chooseYourCar.carFuelConsumption(15, 'Spasko');
            }).to.throw(Error, 'Invalid Information!');

            expect(() => {
                chooseYourCar.carFuelConsumption({}, 'Spasko');
            }).to.throw(Error, 'Invalid Information!');

            expect(() => {
                chooseYourCar.carFuelConsumption({}, []);
            }).to.throw(Error, 'Invalid Information!');

            expect(() => {
                chooseYourCar.carFuelConsumption(5, -3);
            }).to.throw(Error, 'Invalid Information!');

            expect(() => {
                chooseYourCar.carFuelConsumption(-5, 3);
            }).to.throw(Error, 'Invalid Information!');

            expect(() => {
                chooseYourCar.carFuelConsumption(5, -3);
            }).to.throw(Error, 'Invalid Information!');

            expect(() => {
                chooseYourCar.carFuelConsumption(0, 3);
            }).to.throw(Error, 'Invalid Information!');

            expect(() => {
                chooseYourCar.carFuelConsumption(3, 0);
            }).to.throw(Error, 'Invalid Information!');

            expect(() => {
                chooseYourCar.carFuelConsumption(0, 0);
            }).to.throw(Error, 'Invalid Information!');

            expect(() => {
                chooseYourCar.carFuelConsumption(-15, -12);
            }).to.throw(Error, 'Invalid Information!');

            expect(() => {
                chooseYourCar.carFuelConsumption(-1, -1);
            }).to.throw(Error, 'Invalid Information!');
        });

        it('should the car is efficient enough', () => {
            let distanceInKilometers = 100;
            let consumptedFuelInLiters = 7;

            let litersPerHundredKm = ((consumptedFuelInLiters / distanceInKilometers)* 100).toFixed(2);

            expect(chooseYourCar.carFuelConsumption(distanceInKilometers, consumptedFuelInLiters)).to.be.equal(`The car is efficient enough, it burns ${litersPerHundredKm} liters/100 km.`);
        });

        it('should the car is efficient enough', () => {
            let distanceInKilometers = 100;
            let consumptedFuelInLiters = 5;

            let litersPerHundredKm = ((consumptedFuelInLiters / distanceInKilometers)* 100).toFixed(2);

            expect(chooseYourCar.carFuelConsumption(distanceInKilometers, consumptedFuelInLiters)).to.be.equal(`The car is efficient enough, it burns ${litersPerHundredKm} liters/100 km.`);
        });

        it('should the car is efficient enough', () => {
            let distanceInKilometers = 66;
            let consumptedFuelInLiters = 1;

            let litersPerHundredKm = ((consumptedFuelInLiters / distanceInKilometers)* 100).toFixed(2);

            expect(chooseYourCar.carFuelConsumption(distanceInKilometers, consumptedFuelInLiters)).to.be.equal(`The car is efficient enough, it burns ${litersPerHundredKm} liters/100 km.`);
        });

        it('should the car is not efficient enough', () => {
            let distanceInKilometers = 99;
            let consumptedFuelInLiters = 8;

            let litersPerHundredKm = ((consumptedFuelInLiters / distanceInKilometers)* 100).toFixed(2);

            expect(chooseYourCar.carFuelConsumption(distanceInKilometers, consumptedFuelInLiters)).to.be.equal(`The car burns too much fuel - ${litersPerHundredKm} liters!`);
        });

        it('should the car is not efficient enough', () => {
            let distanceInKilometers = 100;
            let consumptedFuelInLiters = 8;

            let litersPerHundredKm = ((consumptedFuelInLiters / distanceInKilometers)* 100).toFixed(2);

            expect(chooseYourCar.carFuelConsumption(distanceInKilometers, consumptedFuelInLiters)).to.be.equal(`The car burns too much fuel - ${litersPerHundredKm} liters!`);
        });

        it('should the car is not efficient enough', () => {
            let distanceInKilometers = 99;
            let consumptedFuelInLiters = 7;

            let litersPerHundredKm = ((consumptedFuelInLiters / distanceInKilometers)* 100).toFixed(2);

            expect(chooseYourCar.carFuelConsumption(distanceInKilometers, consumptedFuelInLiters)).to.be.equal(`The car burns too much fuel - ${litersPerHundredKm} liters!`);
        });
    });
});