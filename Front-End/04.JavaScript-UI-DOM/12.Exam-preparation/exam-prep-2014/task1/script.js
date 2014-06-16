function createCalendar(containerId, events) {
    var container = document.querySelector(containerId);
    var selectedBox = null;
    var calendar = createCalendar(new Date(2014, 5, 1), 30);
    fillTasks(calendar, events);
    container.appendChild(calendar);

    function createCalendar(date, numDays) {
        var i, day;
        var dayTemplate = createDayTemplate();
        var calendar = document.createElement('ul');
        for (i = 1; i <= numDays; i += 1) {
            day = dayTemplate.cloneNode(true);
            date.setDate(i);
            day.children[0].innerHTML = date.toDateString();
            addEventListeners(day);
            calendar.appendChild(day);
        }

        calendar.style.fontFamily = 'calibri';
        calendar.style.fontSize = '0.8em';
        calendar.style.width = 128 * 7 + 'px';

        return calendar;
    }

    function createDayTemplate() {
        var day = document.createElement('li');
        day.style.float = 'left';
        day.style.listStyleType = 'none';
        day.style.margin = '0 -1px -1px 0';
        day.style.border = '1px solid black';
        day.style.width = '120px';

        var dateRow = document.createElement('div');
        dateRow.style.borderBottom = '1px solid black';
        dateRow.style.textAlign = 'center';
        dateRow.style.fontWeight = 'bold';
        dateRow.style.backgroundColor = 'rgb(204, 204, 204)';

        var taskRow = document.createElement('div');
        taskRow.style.padding = '3px';
        taskRow.style.height = '100px';

        day.appendChild(dateRow);
        day.appendChild(taskRow);

        return day;
    }

    function fillTasks(calendar, events) {
        events.forEach(function (event) {
            var date = +event.date;
            var dayBox = calendar.children[date - 1];
            dayBox.children[1].innerHTML = event.hour + ' - ' + event.title;
        });
    }

    function addEventListeners(day) {
        day.addEventListener('mouseover', function (evt) {
            if (selectedBox !== this)
                this.children[0].style.backgroundColor = 'rgb(153, 153, 153)';
        });
        day.addEventListener('mouseout', function (evt) {
            if (selectedBox !== this)
                this.children[0].style.backgroundColor = 'rgb(204, 204, 204)';
        });
        day.addEventListener('click', function (evt) {
            if (selectedBox === this) {
                selectedBox = null;
                this.children[0].style.backgroundColor = 'rgb(153, 153, 153)';
            } else {
                if (selectedBox)
                    selectedBox.children[0].style.background = 'rgb(204, 204, 204)';
                this.children[0].style.backgroundColor = 'rgb(255, 255, 255)';
                selectedBox = this;
            }
        });
    }
}