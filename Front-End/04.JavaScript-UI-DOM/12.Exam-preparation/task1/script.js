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

        var days = document.getElementsByClassName(classNames.day);
        for (var i = 0, len = days.length; i < len; i++) {
            days[i].style.float = styles.day.float;
            days[i].style.listStyleType = styles.day.listStyleType;
            days[i].style.margin = styles.day.margin;
        }

        var dates = document.getElementsByClassName(classNames.date);
        for (var i = 0, len = dates.length; i < len; i++) {
            dates[i].style.border = styles.date.border;
            dates[i].style.width = styles.date.width;
            dates[i].style.padding = styles.date.padding;
            dates[i].style.borderBottom = styles.date.borderBottom;
            dates[i].style.textAlign = styles.date.textAlign;
            dates[i].style.fontWeight = styles.date.fontWeight;
            dates[i].style.backgroundColor = styles.date.backgroundColor;
        }

        var tasks = document.getElementsByClassName(classNames.task);
        for (var i = 0, len = tasks.length; i < len; i++) {
            tasks[i].style.border = styles.task.border;
            tasks[i].style.width = styles.task.width;
            tasks[i].style.padding = styles.task.padding;
            tasks[i].style.height = styles.task.height;
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