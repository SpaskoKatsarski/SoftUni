const { expect } = require('chai');
const { isOddOrEven } = require('../T02.EvenOrOdd');

describe('isOddOrEven', () => {
    it('should return undefined if the passed argument is not of type string', () => {
        let arg = 5;

        expect(isOddOrEven(arg)).to.be.undefined;
    });

    it('should return even if the length is even number', () => {
        let name = 'Koko';

        expect(isOddOrEven(name)).to.be.equal('even');
    });

    it('should return odd if the length is odd number', () => {
        let name = 'Danny';

        expect(isOddOrEven(name)).to.be.equal('odd');
    });
});