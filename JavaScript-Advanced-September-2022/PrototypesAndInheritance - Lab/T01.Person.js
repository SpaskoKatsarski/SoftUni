function createPerson(firstName, lastName) {
    let person = {
        get firstName() {
            return this._firstName;
        },

        set firstName(value) {
            this._firstName = value;
        },

        get lastName() {
            return this._lastName;
        },

        set lastName(value) {
            this._lastName = value;
        },

        get fullName() {
            return `${this.firstName} ${this.lastName}`;
        },

        set fullName(value) {
            if (value.split(' ').length === 2) {
                let [first, second] = value.split(' ');

                this.firstName = first;
                this.lastName = second;
            }
        }
    }

    person.firstName = firstName;
    person.lastName = lastName;

    return person;
}

let person = createPerson("Peter", "Ivanov");
console.log(person.fullName); //Peter Ivanov
person.firstName = "George";
console.log(person.fullName); //George Ivanov
person.lastName = "Peterson";
console.log(person.fullName); //George Peterson
person.fullName = "Nikola Tesla";
console.log(person.firstName); //Nikola
console.log(person.lastName); //Tesla