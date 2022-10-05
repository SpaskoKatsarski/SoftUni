const { expect } = require('chai');
const isSymmetric = require('../UnitTestingAndErrorHandling - Lab/T05.CheckForSymmetry');

describe('isSymmetric', () => {
    it('should return true if the array is symmetric', () => {
        let arr = [1, 2, 3, 4, 3, 2, 1];

        let result = isSymmetric(arr);

        expect(result).to.be.equal(true);
    });

    it("should return true for [5,'hi',{a:5},new Date(),{a:5},'hi',5]", () => {
        expect(isSymmetric([5,'hi',{a:5},new Date(),{a:5},'hi',5])).to.be.equal(true);
    });

    it('should return true if there is only one element in the array', () => {
        let arr = [5];

        let res = isSymmetric(arr);

        expect(res).to.be.equal(true);
    })

    it('should return false if the given argument is not an array', () => {
        let arg = 'Pesho';

        let result = isSymmetric(arg);

        expect(result).to.be.equal(false);
    });

    it('should return true with a given array, containing different type, but is still symetric', () => {
        let arr = [1, 2, 3, new Date(), 3, 2, 1];
        
        let res = isSymmetric(arr);

        expect(res).to.be.equal(true);
    });

    it("should return false in this case [-1,2,1]", function () {
        expect(isSymmetric([-1,2,1])).to.be.equal(false);
    });

    it("should return false for 1,2,2,1", function () {
        expect (isSymmetric(1,2,2,1)).to.be.equal(false);
    });
});