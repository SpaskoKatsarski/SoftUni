const { expect } = require('chai');
const bookSelection = require('./app');

describe('Testing the functionality of bookSelection', () => {
    describe('isGenreSuitable function', () => {
        it('should return not suitable if age <= 12', () => {
            let message = bookSelection.isGenreSuitable('Thriller', 12);

            expect(message).to.be.equal('Books with Thriller genre are not suitable for kids at 12 age');
        });

        it('should return not suitable if age <= 12', () => {
            let message = bookSelection.isGenreSuitable('Thriller', 5);

            expect(message).to.be.equal('Books with Thriller genre are not suitable for kids at 5 age');
        });

        it('should return not suitable if age <= 12', () => {
            let message = bookSelection.isGenreSuitable('Horror', 12);

            expect(message).to.be.equal('Books with Horror genre are not suitable for kids at 12 age');
        });

        it('should return not suitable if age <= 12', () => {
            let message = bookSelection.isGenreSuitable('Horror', 11);

            expect(message).to.be.equal('Books with Horror genre are not suitable for kids at 11 age');
        });

        it('should return suitible if correct', () => {
            let message = bookSelection.isGenreSuitable('Thriller', 13);

            expect(message).to.be.equal('Those books are suitable');
        });

        it('should return suitible if correct', () => {
            let message = bookSelection.isGenreSuitable('Thriller', 15);

            expect(message).to.be.equal('Those books are suitable');
        });

        it('should return suitible if correct', () => {
            let message = bookSelection.isGenreSuitable('Horror', 13);

            expect(message).to.be.equal('Those books are suitable');
        });

        it('should return suitible if correct', () => {
            let message = bookSelection.isGenreSuitable('Thriller', 29);

            expect(message).to.be.equal('Those books are suitable');
        });

        it('should return suitible if correct', () => {
            let message = bookSelection.isGenreSuitable('Fairy', 12);

            expect(message).to.be.equal('Those books are suitable');
        });

        it('should return suitible if correct', () => {
            let message = bookSelection.isGenreSuitable('Fairy', 5);

            expect(message).to.be.equal('Those books are suitable');
        });

        it('should return suitible if correct', () => {
            let message = bookSelection.isGenreSuitable('Fairy', 45);

            expect(message).to.be.equal('Those books are suitable');
        });
    });

    describe('isItAffordable function', () => {
        it('should throw exception with invalid params', () => {
            expect(() => {
                bookSelection.isItAffordable('stinky', 50)
            }).to.throw(Error, 'Invalid input');
        });

        it('should throw exception with invalid params', () => {
            expect(() => {
                bookSelection.isItAffordable(15, '54')
            }).to.throw(Error, 'Invalid input');
        });

        it('should throw exception with invalid params', () => {
            expect(() => {
                bookSelection.isItAffordable({}, '54')
            }).to.throw(Error, 'Invalid input');
        });

        it('result with 0 should be affordable', () => {
            let message = bookSelection.isItAffordable(34, 34);

            expect(message).to.be.equal('Book bought. You have 0$ left');
        });

        it('result with positive number should be affordable', () => {
            let message = bookSelection.isItAffordable(24, 34);

            expect(message).to.be.equal('Book bought. You have 10$ left');
        });

        it('result with negative number should not be affordable', () => {
            let message = bookSelection.isItAffordable(34, 33);

            expect(message).to.be.equal("You don't have enough money");
        });

        it('result with negative number should not be affordable', () => {
            let message = bookSelection.isItAffordable(34, 24);

            expect(message).to.be.equal("You don't have enough money");
        });
    });

    describe('suitableTitles function', () => {
        it('should throw an exception if types are incorrect', () => {
            expect(() => {
                bookSelection.suitableTitles({}, 'Horror');
            }).to.throw(Error, 'Invalid input');
        });

        it('should throw an exception if types are incorrect', () => {
            expect(() => {
                bookSelection.suitableTitles([ 'Hello', 'How are you?', 'Cat' ], []);
            }).to.throw(Error, 'Invalid input');
        });

        it('should throw an exception if types are incorrect', () => {
            expect(() => {
                bookSelection.suitableTitles(15, {});
            }).to.throw(Error, 'Invalid input');
        });

        it('should return only the books with the selected genre', () => {
            let it = {
                title: 'It',
                genre: 'Horror'
            };

            let dahmer = {
                title: 'Dahmer',
                genre: 'Horror',
            }

            let littlePony = {
                title: 'Pony',
                genre: 'Fiary',
            }

            let allBooks = [];
            allBooks.push(it);
            allBooks.push(littlePony);
            allBooks.push(dahmer);
            
            let books = bookSelection.suitableTitles(allBooks, 'Horror');

            expect(books.length).to.be.equal(2);
        });

        it('should return 0 when there are no matches', () => {
            let it = {
                title: 'It',
                genre: 'Horror'
            };

            let dahmer = {
                title: 'Dahmer',
                genre: 'Horror',
            }

            let littlePony = {
                title: 'Pony',
                genre: 'Fiary',
            }

            let allBooks = [];
            allBooks.push(it);
            allBooks.push(littlePony);
            allBooks.push(dahmer);
            
            let books = bookSelection.suitableTitles(allBooks, 'Comedy');

            expect(books.length).to.be.equal(0);
        });
    })
});