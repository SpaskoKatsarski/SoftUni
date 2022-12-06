const { carService } = require('./app.js');

const { expect } = require("chai");
const { describe } = require("mocha");

describe('Testing the functionality of carService', () => {
    describe('isItExpensive function', () => {
        it('should return message with Engine or Transmission as a parameter', () => {
            expect(carService.isItExpensive('Engine')).to.be.equal('The issue with the car is more severe and it will cost more money');
            expect(carService.isItExpensive('Transmission')).to.be.equal('The issue with the car is more severe and it will cost more money');
        });

        it('should return a message with any other string', () => {
            expect(carService.isItExpensive('5')).to.be.equal('The overall price will be a bit cheaper');
            expect(carService.isItExpensive('{}')).to.be.equal('The overall price will be a bit cheaper');
            expect(carService.isItExpensive('Rear wheele')).to.be.equal('The overall price will be a bit cheaper');
        });
    });

    describe('discount function', () => {
        it('should throw an error if one of the params is not of type number', () => {
            expect(function () {
                carService.discount('str', 5);
            }).to.throw(Error, 'Invalid input');

            expect(function () {
                carService.discount(15, 'dog');
            }).to.throw(Error, 'Invalid input');

            expect(function () {
                carService.discount('str', {});
            }).to.throw(Error, 'Invalid input');

            expect(function () {
                carService.discount(true, {});
            }).to.throw(Error, 'Invalid input');
        });

        it('should give 15% discount if number of parts is bigger than 2 and smaller than 7', () => {
            expect(carService.discount(3, 10)).to.be.equal(`Discount applied! You saved ${1.5}$`);
            expect(carService.discount(7, 10)).to.be.equal(`Discount applied! You saved ${1.5}$`);
        });

        it('should give 30% discount if number of parts is bigger than 7', () => {
            expect(carService.discount(8, 10)).to.be.equal(`Discount applied! You saved ${3}$`);
            expect(carService.discount(10, 10)).to.be.equal(`Discount applied! You saved ${3}$`);
        });

        it('should return a message if parts are less or equal to 2', () => {
            expect(carService.discount(2, 15)).to.be.equal('You cannot apply a discount');
            expect(carService.discount(0, 15)).to.be.equal('You cannot apply a discount');
            expect(carService.discount(-15, 15)).to.be.equal('You cannot apply a discount');
        });
    });

    describe('partsToBuy function', () => {
        it('should return 0 if partsCatalog is empty', () => {
            expect(carService.partsToBuy([], ['chair', 'wheele'])).to.be.equal(0);
        });

        it('should throw an exception if one of the params is not of type array', () => {
            expect(function () {
                carService.partsToBuy([], 5);
            }).to.throw(Error, 'Invalid input');

            expect(function () {
                carService.partsToBuy(5, []);
            }).to.throw(Error, 'Invalid input');

            expect(function () {
                carService.partsToBuy({}, 'Joshua');
            }).to.throw(Error, 'Invalid input');
        });

        it('should return the needed money to purchase all items when the parameters are correct', () => {
            let sum = carService.partsToBuy([{ part: "blowoff valve", price: 145 }, { part: "coil springs", price: 230 }, { part: 'wheel', price: 55 }], ["blowoff valve", "wheel"]);
            expect(sum).to.be.equal(200);
        });

        it('should return 0 if no parts are matching in the first and second array', () => {
            let sum = carService.partsToBuy([{ part: "blowoff valve", price: 145 }, { part: "coil springs", price: 230 }, { part: 'wheel', price: 55 }], ["cucumber", "potato"]);
            expect(sum).to.be.equal(0);
        });
    });
});