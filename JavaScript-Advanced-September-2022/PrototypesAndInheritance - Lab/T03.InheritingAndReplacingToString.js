function result() {
    class Person {
        constructor(name, email) {
            this.name = name;
            this.email = email;
        }
    }

    class Teacher extends Person {
        constructor(name, email, subject) {
            super(name, email);
            this.subject = subject;
        }
    }

    class Student extends Person {
        constructor(name, email, course) {
            super(name, email);
            this.course = course;
        }
    }

    Person.prototype.toString = function() {
        let keysAndValues = [];

        for (const key of Object.keys(this)) {
            keysAndValues.push(`${key}: ${this[key]}`);
        }

        let type = this.constructor.name;
        let properties = keysAndValues.join(', ');

        return `${type} (${properties})`;
    }

    return {
        Person,
        Teacher,
        Student
    };
}

let classes = result();

let Person = classes.Person;
let Teacher = classes.Teacher;
let Student = classes.Student;

let p = new Person("Pesho",'Pesho@pesh.com');

let pString = p.toString();
console.log(pString);