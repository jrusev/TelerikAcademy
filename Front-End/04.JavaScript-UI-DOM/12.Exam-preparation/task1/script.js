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
        calendar.style.width = styles.calendar.width;
        calendar.style.fontFamily = styles.calendar.fontFamily;
        calendar.style.fontSize = styles.calendar.fontSize;

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
            var dayBox = calendar.children[date];
            // duration: '60'
            dayBox.children[1].innerHTML = event.hour + ' ' + event.title;
        });
    }

    function createCalendar(date, numDays) {
        var i, day;
        var calendar = document.createElement('ul');
        calendar.className += ' ' + classNames.calendar;
        for (i = 0; i < numDays; i += 1) {
            // 'Sun 1 June 2014'
            date.setDate(i + 1);
            var dateStr = date.getDayName() + ' ' + date.getDate() + ' ' + date.getMonthName() + ' ' + date.getFullYear();
            day = createDay(dateStr);
            calendar.appendChild(day);
        }
        return calendar;
    }

    function createDay(date, task) {
        var day = document.createElement('li');
        day.className += ' ' + classNames.day;

        var dateRow = document.createElement('div');
        dateRow.className += ' ' + classNames.date;
        dateRow.innerHTML = date;

        var taskRow = document.createElement('div');
        taskRow.className += ' ' + classNames.task;
        taskRow.innerHTML = task || '';

        day.appendChild(dateRow);
        day.appendChild(taskRow);
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