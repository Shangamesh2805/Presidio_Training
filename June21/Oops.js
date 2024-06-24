// Base class
class Person {
    constructor(name, id) {
        this.name = name;
        this.id = id;
        this.scores = {
            midterm: 0,
            final: 0,
            project: 0
        };
    }

    // Encapsulation: setting scores through a method
    setScores(midterm, final, project) {
        this.scores.midterm = midterm;
        this.scores.final = final;
        this.scores.project = project;
    }

    // Encapsulation: accessing scores through a method
    getScores() {
        return this.scores;
    }

    // Polymorphism: calculateAverage can be overridden in subclasses
    calculateAverage() {
        let total = this.scores.midterm + this.scores.final + this.scores.project;
        return total / 3;
    }
}

// Inheritance: HonorsStudent inherits from Person
class HonorsStudent extends Person {
    constructor(name, id, program) {
        super(name, id);
        this.program = program;
    }

    // Polymorphism: overriding calculateAverage to add bonus points
    calculateAverage() {
        let total = this.scores.midterm + this.scores.final + this.scores.project + 10; // Bonus points
        return total / 3;
    }
}

// Usage
let student1 = new Person("Alice Johnson", 101);
student1.setScores(85, 90, 88);
console.log(`${student1.name}'s scores:`, student1.getScores());
console.log(`Average score: ${student1.calculateAverage().toFixed(2)}`);

let honorsStudent1 = new HonorsStudent("Bob Smith", 102, "Honors Program");
honorsStudent1.setScores(85, 90, 88);
console.log(`${honorsStudent1.name} (${honorsStudent1.program})'s scores:`, honorsStudent1.getScores());
console.log(`Average score (with bonus): ${honorsStudent1.calculateAverage().toFixed(2)}`);
