function solve() {
    // • The Person class should have a name and an email
    // • The Teacher class should have a name, an email, and a subject

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

    return {
        Person,
        Teacher
    }
}

let obj = solve();

let teacher = new obj.Teacher('Ivana', 'Galeva', 'Physics');
console.log(teacher);