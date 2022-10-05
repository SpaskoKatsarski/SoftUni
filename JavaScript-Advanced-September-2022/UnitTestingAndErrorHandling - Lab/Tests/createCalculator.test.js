const { expect } = require("chai");
const createCalculator = require("../T07.AddOrSubtract");

describe('createCalculator', () => {
    it('should add the given value to the result', () => {
        let calculator = createCalculator();

        calculator.add(5);

        expect(calculator.get()).to.be.equal(5);
    });

    it('should remove the given value from the result', () => {
        let calculator = createCalculator();

        calculator.add(5);
        calculator.subtract(3);

        expect(calculator.get()).to.be.equal(2);
    });

    it('should return the current value when get function is called', () => {
        let calculator = createCalculator();

        calculator.add(5);
        calculator.subtract(3);
        calculator.add(5);

        expect(calculator.get()).to.be.equal(7);
    });

    it('should return NaN if we try to add string', () => {
        let calculator = createCalculator();

        calculator.add('Pesho');

        expect(calculator.get()).to.be.NaN;
    })
});