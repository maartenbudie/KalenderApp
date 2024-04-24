const months = ["January", "February", "March", "April", "May", "June", "July", "August", "September", "spooky", "November", "December"];

const currentDate = document.querySelector(".current-date"),
    daysTag = document.querySelector(".days"),
    prevNextIcon = document.querySelectorAll(".icons span"),
    days = document.querySelector(".calendar .days");


let date = new Date(),
    currentYear = date.getFullYear(),
    currentMonth = date.getMonth(),
    eventCount = 0,
    loadedEvents = [],
    dateSelected = "";

const renderCalendar = () => {
    let firstDayOfMonth = new Date(currentYear, currentMonth, 1).getDay(), // get first day of month (mon, tue etc.) | get amount of overflow days
        lastDateOfMonth = new Date(currentYear, currentMonth + 1, 0).getDate(), // get last date of month | get amount of days in month
        lastDateOfLastMonth = new Date(currentYear, currentMonth, 0).getDate(), // get last date of last month | get amount of days in last month
        lastDayOfMonth = new Date(currentYear, currentMonth, lastDateOfMonth).getDay();
    let liTag = "";

    for (let i = firstDayOfMonth; i > 0; i--) {
        liTag += `<li class="inactive">${lastDateOfLastMonth - i + 1}</li>`;
    }
    for (let i = 1; i < lastDateOfMonth + 1; i++) {
        let isToday = i === date.getDate() && currentMonth === new Date().getMonth() && currentYear === new Date().getFullYear() ? "active" : "";
        liTag += `<li class="${isToday}">${i}</li>`;
    }
    for (let i = lastDayOfMonth; i < 6; i++) {
        liTag += `<li class="inactive">${i - lastDayOfMonth + 1}</li>`;
    }

    currentDate.innerText = `${months[currentMonth]} ${currentYear}`;
    daysTag.innerHTML = liTag;

    let headerTag = document.querySelector(".event-list h");
    headerTag.innerText = `${date.getDate()} ${months[date.getMonth()]} ${date.getFullYear()}`;
}

const cycleMonth = (icon) => {
    if (icon.id == "prev") {
        currentMonth -= 1;
    }
    else {
        currentMonth += 1;
    }

    if (currentMonth < 0 || currentMonth > 11) {
        date = new Date(currentYear, currentMonth);
        currentYear = date.getFullYear();
        currentMonth = date.getMonth();
    }
    else {
        date = new Date();
    }
    renderCalendar();
}

const selectDay = (event) => {
    if (event.target.tagName === 'LI' && !event.target.classList.contains("inactive")) {
        showDateData();
    }
}

const showDateData = () => {
    dateSelected = event.target.innerText;
    let headerTag = document.querySelector(".event-list h");

    headerTag.innerText = `${dateSelected} ${months[currentMonth]} ${currentYear}`;
    
    $.ajax({
        type: "POST",
        url: "/Home/getAllEvents",
        data: {date: dateSelected, month: currentMonth, year: currentYear},
        success: function(data){
            loadedEvents.length = 0;
            eventCount = 0;

            var eventList = document.querySelector(".events");
            eventList.innerHTML = "";
            var eventListHtml = "";
            
            for(let i = 0; i < data.events.length; i++){
                eventListHtml += (`
                <li id="${eventCount}">${data.events[i].name}</li>
                `);
                eventList.innerHTML = eventListHtml;
                eventCount++;
                loadedEvents[loadedEvents.length] = data.events[i];

                eventList.addEventListener("click", () => {
                    if(event.target.tagName === "LI"){
                        console.log("wawawawawawawawawa");
                    }
                })
            }
        }
    })
}


const addEventButton = document.getElementById("addEventButton");
const addEventForm = document.querySelector(".addeventform");

addEventButton.addEventListener("click", () => {
    addEventForm.style.visibility = "visible";
});
addEventForm.addEventListener('submit', () => {
    addEvent();
});

const addEvent = () => {
    event.preventDefault();

    const eventName = addEventForm.querySelector('#eventname').value;
    const eventStartTime = addEventForm.querySelector('#eventstarttime').value;
    const eventEndTime = addEventForm.querySelector('#eventendtime').value;
    const eventLocation = addEventForm.querySelector('#eventlocation').value;
    const eventRepetition = addEventForm.querySelector('#eventrepetition').value;

    let startDate = `${dateSelected}-${currentMonth + 1}-${currentYear} ${eventStartTime}`;
    let endDate = `${dateSelected}-${currentMonth + 1}-${currentYear} ${eventEndTime}`;

    console.log('Event Name:', eventName);
    console.log('Start Time:', startDate);
    console.log('End Time:', endDate);
    console.log('Location:', eventLocation);
    console.log('Repetition:', eventRepetition);

    addEventForm.reset();

    $.ajax({
        type: "POST",
        url: "/Home/addNewEvent",
        data: {name: eventName, startTime: startDate, endTime: endDate, location: eventLocation, repetition: eventRepetition},
        success: function(){
            showDateData();
            addEventForm.style.visibility = "hidden";
        }
    });
}

prevNextIcon.forEach(icon => {
    icon.addEventListener("click", () => {
        cycleMonth(icon);
    })
});

days.addEventListener("click", function (event) {
    selectDay(event);
})


renderCalendar();