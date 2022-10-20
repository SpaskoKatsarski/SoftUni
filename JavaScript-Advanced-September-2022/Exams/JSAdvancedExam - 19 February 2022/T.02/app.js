class LibraryCollection {
    constructor(capacity) {
        this.capacity = capacity;
        this.books = [];
    }

    addBook(bookName, bookAuthor) {
        if (this.books.length === this.capacity) {
            throw new Error('Not enough space in the collection.');
        }

        let book = {
            bookName,
            bookAuthor,
            payed: false
        }

        this.books.push(book);

        return `The ${bookName}, with an author ${bookAuthor}, collect.`;
    }

    payBook(bookName)  {
        let book = this.books.find(b => b.bookName === bookName);

        if (!book) {
            throw new Error(`${bookName} is not in the collection.`);
        }

        if (book.payed) {
            throw new Error(`${bookName} has already been paid.`);
        }

        book.payed = true;
        return `${bookName} has been successfully paid.`;
    }

    removeBook(bookName) {
        let book = this.books.find(b => b.bookName === bookName);

        if (!book) {
            throw new Error(`The book, you're looking for, is not found.`);
        }

        if (!book.payed) {
            throw new Error(`${bookName} need to be paid before removing from the collection.`);
        }

        this.books.splice(this.books.indexOf(book), 1);
        return `${bookName} remove from the collection.`;
    }

    getStatistics(bookAuthor) {
        if (bookAuthor === undefined) {
            let result = [];
            result.push(`The book collection has ${this.capacity - this.books.length} empty spots left.`);

            for (let book of this.books.sort((a, b) => a.bookName.localeCompare(b.bookName))) {
                let paid = book.payed ? 'Has Paid' : 'Not Paid';
                result.push(`${book.bookName} == ${book.bookAuthor} - ${paid}.`);
            }

            return result.join('\n');
        }

        let book = this.books.find(b => b.bookAuthor === bookAuthor);

        if (!book) {
            throw new Error(`${bookAuthor} is not in the collection.`);
        }

        let paid = book.payed ? 'Has Paid' : 'Not Paid';
        return `${book.bookName} == ${book.bookAuthor} - ${paid}.`;
    }
}

let library = new LibraryCollection(2);
console.log(library.addBook("In Search of Lost Time", "Marcel Proust"));