const { expect } = require("chai");
const rgbToHexColor = require("../T06.RGBtoHex");

describe('rgbToHexColor', () => {
    it('should return the same color in hexadecimal format as a string', () => {
        let result = rgbToHexColor(66, 135, 245);

        expect(result).to.be.equal('#4287F5');
    });

    it('should return #000000 with zeroes', () => {
        let result = rgbToHexColor(0, 0, 0);

        expect(result).to.be.equal('#000000');
    });

    it("should return #FFFFFF with 255 for each argument", function () {
        expect(rgbToHexColor(255, 255, 255)).to.equal("#FFFFFF");
    })

    it('should return undefined if one of the arguments is floating point number', () => {
        expect(rgbToHexColor(3.5, 12, 52)).to.be.equal(undefined);
    })

    it('should return undefined if red parameter is not a number', () => {
        let result = rgbToHexColor('Pesho', 135, 245);

        expect(result).to.be.equal(undefined);
    });

    it('should return undefined if blue parameter is not a number', () => {
        let result = rgbToHexColor(66, 'Pesho', 245);

        expect(result).to.be.equal(undefined);
    });

    it('should return undefined if green parameter is not a number', () => {
        let result = rgbToHexColor(66, 135, 'Pesho');

        expect(result).to.be.equal(undefined);
    });

    it('should return undefined if red parameter is less than 0', () => {
        let result = rgbToHexColor(-1, 135, 245);

        expect(result).to.be.equal(undefined);
    });

    it('should return undefined if blue parameter is less than 0', () => {
        let result = rgbToHexColor(66, -1, 245);

        expect(result).to.be.equal(undefined);
    });

    it('should return undefined if green parameter is less than 0', () => {
        let result = rgbToHexColor(66, 135, -1);

        expect(result).to.be.equal(undefined);
    });

    it('should return undefined if red parameter is greater than 255', () => {
        let result = rgbToHexColor(256, 135, 245);

        expect(result).to.be.equal(undefined);
    });

    it('should return undefined if blue parameter is greater than 255', () => {
        let result = rgbToHexColor(66, 256, 245);

        expect(result).to.be.equal(undefined);
    });

    it('should return undefined if green parameter is greater than 255', () => {
        let result = rgbToHexColor(66, 135, 256);

        expect(result).to.be.equal(undefined);
    });
});