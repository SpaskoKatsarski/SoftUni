const { expect } = require('chai');
const mathEnforcer = require('../T04.MathEnforcer');

// describe('testing the funcs inside mathEnforcer', () => {

//     it('should return undefined if arg is not a numbver', () => {
//         expect(mathEnforcer.addFive('Gosho')).to.be.undefined;
//     });

//     it('should add 5 to the given number', () => {
//         expect(mathEnforcer.addFive(5)).to.be.equal(10);
//     });

//     it('should add 5 to positive sum', () => {
//         expect(mathEnforcer.addFive(5 + 10)).to.be.equal(20);
//     })

//     it('should return undefined if arg is not a numbver', () => {
//         expect(mathEnforcer.subtractTen('Gosho')).to.be.undefined;
//     });

//     it('should remove 10 from the given number', () => {
//         expect(mathEnforcer.subtractTen(15)).to.be.equal(5);
//     });

//     it('should return undefined if the first parameter is not a number', () => {
//         expect(mathEnforcer.sum('Sth', 5)).to.be.undefined;
//     });

//     it('should return undefined if the second parameter is not a number', () => {
//         expect(mathEnforcer.sum(1, 'Hello!')).to.be.undefined;
//     });

//     it('should return the sum of the two given numbers', () => {
//         expect(mathEnforcer.sum(1, 5)).to.be.equal(6);
//     })
// });

describe("mathEnforcer",function(){
    describe("mathEnforcer.addFive(num)",function(){
       it("should be close to 6 within 6.99",function(){
          expect(mathEnforcer.addFive(1.999)).closeTo(6.999,0.001,"Numbers are close");
       });
       it("mathEnforcer.addFive(4) should return 9",function(){
          expect(mathEnforcer.addFive(4)).to.equal(9);
       });
       it("mathEnforcer.addFive(-4) should return 1",function(){
          expect(mathEnforcer.addFive(-4)).to.equal(1);
       });
       it("mathEnforcer.addFive('Pesho') should return undefined",function(){
          expect(mathEnforcer.addFive('pesho')).to.equal(undefined);
       });
       it("mathEnforcer.addFive('5') should return undefined",function(){
          expect(mathEnforcer.addFive('5')).to.equal(undefined);
       });
       it("mathEnforcer.addFive([5]) should return undefined",function(){
          expect(mathEnforcer.addFive([5])).to.equal(undefined);
       });
       it("mathEnforcer.addFive(0) should return 5",function(){
          expect(mathEnforcer.addFive(0)).to.equal(5);
       });
       it("mathEnforcer.addFive() should return undefined",function(){
          expect(mathEnforcer.addFive()).to.equal(undefined);
       });
       it("mathEnforcer.addFive({pesho:5}) should return undefined",function(){
          expect(mathEnforcer.addFive({pesho:5})).to.equal(undefined);
       });
    });
 
    describe("mathEnforcer.subtractTen(num)",function(){
       it("mathEnforcer.subtractTen(4) should return -6",function(){
          expect(mathEnforcer.subtractTen(4)).to.equal(-6);
       });
       it("mathEnforcer.subtractTen(-4) should return -14",function(){
          expect(mathEnforcer.subtractTen(-4)).to.equal(-14);
       });
       it("mathEnforcer.subtractTen('Pesho') should return undefined",function(){
          expect(mathEnforcer.subtractTen('pesho')).to.equal(undefined);
       });
       it("mathEnforcer.subtractTen(0) should return -10",function(){
          expect(mathEnforcer.subtractTen(0)).to.equal(-10);
       });
       it("mathEnforcer.subtractTen(10) should return 0",function(){
          expect(mathEnforcer.subtractTen(10)).to.equal(0);
       });
       it("mathEnforcer.subtractTen(5) should return -5",function(){
          expect(mathEnforcer.subtractTen(5)).to.equal(-5);
       });
       it("mathEnforcer.subtractTen(10.001) should be close to 0.001",function(){
        expect(mathEnforcer.subtractTen(10.001)).equal(10.001-10);
       });
       it("mathEnforcer.subtractTen('5') should return undefined",function(){
          expect(mathEnforcer.subtractTen('5')).to.equal(undefined);
       });
       it("mathEnforcer.subtractTen([5]) should return undefined",function(){
          expect(mathEnforcer.subtractTen([5])).to.equal(undefined);
       });
       it("mathEnforcer.subtractTen() should return undefined",function(){
          expect(mathEnforcer.subtractTen()).to.equal(undefined);
       });
       it("mathEnforcer.subtractTen({pesho:5}) should return undefined",function(){
          expect(mathEnforcer.subtractTen({pesho:5})).to.equal(undefined);
       });
 
    });
 
    describe("mathEnforcer.sum(num1,num2)",function(){
       it("mathEnforcer.sum(2,-8) should return -6",function(){
          expect(mathEnforcer.sum(2,-8)).to.equal(-6);
       });
       it("mathEnforcer.sum(2,3) should return 5",function(){
          expect(mathEnforcer.sum(2,3)).to.equal(5);
       });
       it("mathEnforcer.sum('Pesho',3) should return undefined",function(){
          expect(mathEnforcer.sum('pesho',3)).to.equal(undefined);
       });
       it("mathEnforcer.sum('Pesho','pesho') should return undefined",function(){
          expect(mathEnforcer.sum('pesho','pesho')).to.equal(undefined);
       });
       it("mathEnforcer.sum(3,'pesho') should return undefined",function(){
          expect(mathEnforcer.sum(3,'pesho')).to.equal(undefined);
       });
 
       it("mathEnforcer.sum(-5,-5) should return -10",function(){
          expect(mathEnforcer.sum(-5,-5)).to.equal(-10);
       });
       it("mathEnforcer.sum([-5],[-5]) should return undefined",function(){
          expect(mathEnforcer.sum([-5],[-5])).to.equal(undefined);
       });
       it("mathEnforcer.sum('-5','-5') should return undefined",function(){
          expect(mathEnforcer.sum('-5','-5')).to.equal(undefined);
       });
       it("mathEnforcer.sum([-5,-5]) should return undefined",function(){
          expect(mathEnforcer.sum([-5,-5])).to.equal(undefined);
       });
       it("mathEnforcer.sum(10.0001,1.009) should be close to 11.0091",function(){
          expect(mathEnforcer.sum(10.0001,1.009)).closeTo(11.0091,0.001,"Numbers are close");
       });
       it("mathEnforcer.sum() should return undefined",function(){
          expect(mathEnforcer.sum()).to.equal(undefined);
       });
       it("mathEnforcer.sum(0,0) should return undefined",function(){
          expect(mathEnforcer.sum(0,0)).to.equal(0);
       });
    });
 });