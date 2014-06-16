var classNames = {
    calendar: 'calendar',
    day: 'day',
    date: 'date',
    task: 'task',
};

var styles = {
    calendar: {
        fontFamily: 'calibri',
        fontSize: '0.8em',
        width: '896px',
    },
    day: {
        float: 'left',
        listStyleType: 'none',
        margin: '0 -1px -1px 0',
    },
    date: {
        border: '1px solid black',
        width: '120px',
        padding: '3px',
        borderBottom: 'none',
        textAlign: 'center',
        fontWeight: 'bold',
        backgroundColor: '#CCCCCC',
    },
    task: {
        border: '1px solid black',
        width: '120px',
        padding: '3px',
        height: '100px',
    }
};

function createCalendar(containerId, events) {
    var container = document.querySelector(containerId);

    var startDate = new Date(2014, 5, 1);
    var calendar = createCalendar(startDate, 30);
    container.appendChild(calendar);
    fillTasks(calendar, events);
    applyStyles(calendar);

    function applyStyles(calendar) {
        applyProps(classNames.calendar);
        applyProps(classNames.day);
        applyProps(classNames.date);
        applyProps(classNames.task);

        function applyProps(className) {
            var elements = document.getElementsByClassName(className);
            for (var i = 0, len = elements.length; i < len; i++)
                for (var prop in styles[className])
                    elements[i].style[prop] = styles[className][prop];
        }
    }

    function fillTasks(calendar, events) {
        events.forEach(function (event) {
            var date = +event.date;
            var dayBox = calendar.children[date - 1];

            function addMinutes(time, minsToAdd) {
                function z(n) {
                    return (n < 10 ? '0' : '') + n;
                };
                var bits = time.split(':');
                var mins = bits[0] * 60 + +bits[1] + +minsToAdd;

                return z(mins % (24 * 60) / 60 | 0) + ':' + z(mins % 60);
            }

            var endTime = addMinutes(event.hour, event.duration);
            //dayBox.children[1].innerHTML = event.hour + '-' + endTime + ' ' + event.title;
            dayBox.children[1].innerHTML = event.hour + ': ' + event.title;
        });
    }

    function createCalendar(date, numDays) {
        var i, day;
        var calendar = document.createElement('ul');
        calendar.className += ' ' + classNames.calendar;
        //day = createDay();
        for (i = 0; i < numDays; i += 1) {
            // 'Sun 1 June 2014'
            date.setDate(i + 1);
            var dateStr = date.getDayName() + ' ' + date.getDate() + ' ' + date.getMonthName() + ' ' + date.getFullYear();
            day = createDay();
            day.children[0].innerHTML = dateStr;
            calendar.appendChild(day);
        }
        return calendar;
    }

    function createDay() {
        // this function is called only once
        var day = document.createElement('li');
        day.className += ' ' + classNames.day;

        var dateRow = document.createElement('div');
        dateRow.className += ' ' + classNames.date;

        var taskRow = document.createElement('div');
        taskRow.className += ' ' + classNames.task;

        day.appendChild(dateRow);
        day.appendChild(taskRow);

        day.addEventListener('mouseover', function (evt) {
            if (this.children[0].style.backgroundColor !== 'rgb(255, 255, 255)')
                this.children[0].style.backgroundColor = 'rgb(153, 153, 153)';
        });

        day.addEventListener('mouseout', function (evt) {
            if (this.children[0].style.backgroundColor !== 'rgb(255, 255, 255)')
                this.children[0].style.backgroundColor = 'rgb(204, 204, 204)';
        });

        day.addEventListener('click', function (evt) {
            var elements = document.getElementsByClassName(classNames.date);
            var currentColor = this.children[0].style.backgroundColor;
            for (var i = 0, len = elements.length; i < len; i++)
                elements[i].style.backgroundColor = styles[classNames.date]['backgroundColor'];

            if (currentColor === 'rgb(255, 255, 255)')
                this.children[0].style.backgroundColor = 'rgb(204, 204, 204)';
            else
                this.children[0].style.backgroundColor = 'rgb(255, 255, 255)';
        });

        return day;
    }
}

(function () {
    var days = ['Sun', 'Mon', 'Tue', 'Wed', 'Thur', 'Fri', 'Sat'];
    var months = ['January', 'February', 'March', 'April', 'May', 'June', 'July', 'August', 'September', 'October', 'November', 'December'];

    Date.prototype.getMonthName = function () {
        return months[this.getMonth()];
    };
    Date.prototype.getDayName = function () {
        return days[this.getDay()];
    };
})();