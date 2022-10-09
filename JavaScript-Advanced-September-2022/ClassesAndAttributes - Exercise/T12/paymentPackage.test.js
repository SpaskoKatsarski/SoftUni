const { expect, assert } = require('chai');
const PaymentPackage = require('./T12.PaymentPackage');

describe('PaymentPackage functionality', () => {
    describe('Testing the constructor', () => {

        it('should initialize the instance correctly with valid parameters', () => {
            let package = new PaymentPackage('SomeName', 50);

            expect(package.name).to.be.equal('SomeName');
            expect(package.value).to.be.equal(50);
            expect(package.VAT).to.be.equal(20);
            expect(package.active).to.be.true;
        });

        it('should throw an error if the constructor receives only name', () => {
            assert.throws(() => { new PaymentPackage('SomeName') });
        });

        it('should throw an error if the constructor receives only value', () => {
            assert.throws(() => { new PaymentPackage(15) });
        });

        it('should throw an error if the constructor receives nothing', () => {
            assert.throws(() => { new PaymentPackage() });
        });
    });

    describe('Testing the getters and setters', () => {
        it('name setter should work correctly', () => {
            let package = new PaymentPackage('SomeName', 50);

            expect(package.name).to.be.equal('SomeName');

            package.name = 'New';

            expect(package.name).to.be.equal('New');
        });
    });

    it('value setter should work correctly', () => {
        let package = new PaymentPackage('SomeName', 50);

        expect(package.value).to.be.equal(50);

        package.value = 5;

        expect(package.value).to.be.equal(5);

        package.value = 0;

        expect(package.value).to.be.equal(0);
    });

    it('VAT setter should work correctly', () => {
        let package = new PaymentPackage('SomeName', 50);

        expect(package.VAT).to.be.equal(20);

        package.VAT = 15;

        expect(package.VAT).to.be.equal(15);

        package.VAT = 0;

        expect(package.VAT).to.be.equal(0);
    });

    it('active setter should work correctly', () => {
        let package = new PaymentPackage('SomeName', 50);

        expect(package.active).to.be.true;

        package.active = false;

        expect(package.active).to.be.false;
    });

    describe('Testing the getters and setters with invalid data', () => {
        it('should throw an error when name is not a string', () => {
            assert.throws(() => new PaymentPackage(15, 50), 'Name must be a non-empty string');
        });

        it('should throw an error when name length is 0', () => {
            assert.throws(() => new PaymentPackage('', 50), 'Name must be a non-empty string');
        });

        it('should throw an error when value is not a number', () => {
            assert.throws(() => new PaymentPackage('Name', 'bruh'), 'Value must be a non-negative number');
        });

        it('should throw an error when value is set to an object', () => {
            assert.throws(() => new PaymentPackage('Name', {}), 'Value must be a non-negative number');
        });

        it('should throw an error when value is less than zero', () => {
            assert.throws(() => new PaymentPackage('Name', -1), 'Value must be a non-negative number');
        });

        it('should throw an error when value is way less than zero', () => {
            assert.throws(() => new PaymentPackage('Name', -112442), 'Value must be a non-negative number');
        });

        it('should throw an error when VAT is not a number', () => {
            let package = new PaymentPackage('SomeName', 50);

            assert.throws(() => package.VAT = 'Gosho', 'VAT must be a non-negative number');
        });

        it('should throw an error when VAT is less than zero', () => {
            let package = new PaymentPackage('SomeName', 50);

            assert.throws(() => package.VAT = -1, 'VAT must be a non-negative number');
        });

        it('should throw an error when VAT is way less than zero', () => {
            let package = new PaymentPackage('SomeName', 50);

            assert.throws(() => package.VAT = -152.52, 'VAT must be a non-negative number');
        });

        it('should throw an error when active is set to a non-boolean value', () => {
            let package = new PaymentPackage('SomeName', 50);

            assert.throws(() => package.active = 'Pesho', 'Active status must be a boolean');
        });
    });

    describe('Testing the functionality of toString()', () => {
        it('should not display inactive if active is set to true', () => {
            let package = new PaymentPackage('SomeName', 50);

            let expectedOutput = `Package: ${package.name}\n` +
                `- Value (excl. VAT): ${package.value}\n` +
                `- Value (VAT ${package.VAT}%): ${package.value * (1 + package.VAT / 100)}`;

            expect(package.toString()).to.be.equal(expectedOutput);
        });

        it('should display inactive if active is set to false', () => {
            let package = new PaymentPackage('SomeName', 50);

            package.active = false;

            let expectedOutput = `Package: ${package.name} (inactive)\n` +
                `- Value (excl. VAT): ${package.value}\n` +
                `- Value (VAT ${package.VAT}%): ${package.value * (1 + package.VAT / 100)}`;

            expect(package.toString()).to.be.equal(expectedOutput);
        });

        it('should not display inactive if active is set to true (changing the value of a property)', () => {
            let package = new PaymentPackage('SomeName', 50);

            package.VAT = 1;

            let expectedOutput = `Package: ${package.name}\n` +
                `- Value (excl. VAT): ${package.value}\n` +
                `- Value (VAT ${package.VAT}%): ${package.value * (1 + package.VAT / 100)}`;

            expect(package.toString()).to.be.equal(expectedOutput);
        });
    });
}); 