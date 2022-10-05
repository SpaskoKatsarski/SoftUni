const { expect } = require("chai");
const sum  = require("../T04.SumOfNumbers");

describe('sum', () => {
    it('should return correct result', () => {
        let arr = [1, 2, 3, 4];
        let res = sum(arr);

        expect(res).to.be.equal(10);
    });
});