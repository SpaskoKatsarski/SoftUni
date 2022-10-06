const { expect } = require('chai');
const { lookupChar } = require('../T03.CharLookup');

describe('lookupChar', () => {
    it('should return undefined if the first argument is not of type string', () => {
        expect(lookupChar(new Error(), 5)).to.be.undefined;
    });

    it('should return undefined if the second argument is not of type int', () => {
        expect(lookupChar('Pesho', { name: 'Ivan' })).to.be.undefined;
    });

    it('should return undefined if the second argument is double', () => {
        expect(lookupChar('Pesho', 3.1)).to.be.undefined;
    });

    it('should return "Incorrect index" if the index is less than 0', () => {
        let str = 'Hello';
        let index = -1;

        expect(lookupChar(str, index)).to.be.equal('Incorrect index');
    });

    it('should return "Incorrect index" if the index is bigger than the length of the string', () => {
        let str = 'Hello';
        let index = 5;

        expect(lookupChar(str, index)).to.be.equal('Incorrect index');
    });

    it('should return the char at the given index', () => {
        let str = 'Spasko';
        let index = 3;

        let result = lookupChar(str, index);

        expect(result).to.be.equal('s');
    })
});