class Company {
    constructor() {
        this.departments = {};
    }

    addEmployee(name, salary, position, department) {
        if (!name || !salary || salary < 0 || !position || !department) {
            throw new Error('Invalid input!');
        }

        if (!this.departments.hasOwnProperty(department)) {
            this.departments[department] = {
                totalSalary: 0,
                averageSalary: 0,
                employees: []
            };
        }

        this.departments[department].employees.push({
            name,
            salary,
            position,

            toString() {
                return `${this.name} ${this.salary} ${this.position}`;
            }
        });

        this.departments[department].totalSalary += salary;
        this.departments[department].averageSalary = this.departments[department].totalSalary / this.departments[department].employees.length;

        return `New employee is hired. Name: ${name}. Position: ${position}`;
    }

    bestDepartment() {
        let bestDep = Object.entries(this.departments)
        .sort(([depName1, depInfo1], [depName2, depInfo2]) => {
            return depInfo2.averageSalary - depInfo1.averageSalary;
        })[0];

        bestDep[1].employees = bestDep[1].employees.sort((a, b) => {
            return b.salary - a.salary || a.name.localeCompare(b.name);
        });

        let result = `Best Department is: ${bestDep[0]}\nAverage salary: ${bestDep[1].averageSalary.toFixed(2)}\n`;

        for (const employee of bestDep[1].employees) {
            result += `${employee}\n`;
        }

        return result.trimEnd();
    }
}

let c = new Company();
c.addEmployee("Stanimir", 2000, "engineer", "Construction");
c.addEmployee("Pesho", 1500, "electrical engineer", "Construction");
c.addEmployee("Slavi", 500, "dyer", "Construction");
c.addEmployee("Stan", 2000, "architect", "Construction");
c.addEmployee("Stanimir", 1200, "digital marketing manager", "Marketing");
c.addEmployee("Pesho", 1000, "graphical designer", "Marketing");
c.addEmployee("Gosho", 1350, "HR", "Human resources");
console.log(c.bestDepartment());