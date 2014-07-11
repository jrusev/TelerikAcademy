define([], function () {
	var Student = (function () {
		//name, exam, homework, attendance, teamwork, bonus
		function Student(params) {
			this.name = params.name;
			this.exam = params.exam;
			this.homework = params.homework;
			this.attendance = params.attendance;
			this.teamwork = params.teamwork;
			this.bonus = params.bonus;
		}

		Student.prototype.toString = function () {
			return '{' + this.name + ', exam: ' + this.exam.toFixed(2) + ', total score: '+ (this.totalScore.toFixed(2) || 'n.a.') + '}';
		};

		return Student;
	}());

	return Student;
});