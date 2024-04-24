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
loadedCategories = [],
dateSelected = date.getDate(),
selectedEventId = 0;

const renderCalendar = () => {
    let firstDayOfMonth = new Date(currentYear, currentMonth, 1).getDay(),
    lastDateOfMonth = new Date(currentYear, currentMonth + 1, 0).getDate(),
    lastDateOfLastMonth = new Date(currentYear, currentMonth, 0).getDate(),
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
    } else {
        currentMonth += 1;
    }
    
    if (currentMonth < 0 || currentMonth > 11) {
        date = new Date(currentYear, currentMonth);
        currentYear = date.getFullYear();
        currentMonth = date.getMonth();
    } else {
        date = new Date();
    }
    renderCalendar();
}

const selectDay = (event) => {
    if (event.target.tagName === 'LI' && !event.target.classList.contains("inactive")) {
        //getCategory();
        
        dateSelected = event.target.innerText;
        showDateData();
        addEventForm.style.visibility = "hidden";
        addEventForm.style.display = "none";
        editEventForm.style.visibility = "hidden";
        editEventForm.style.display = "none";
    }
}


const showDateData = () => {
    let headerTag = document.querySelector(".event-list h");
    
    headerTag.innerText = `${dateSelected} ${months[currentMonth]} ${currentYear}`;
    
    $.ajax({
        type: "POST",
        url: "/Home/GetAllEventsForDate",
        data: { date: dateSelected, month: currentMonth, year: currentYear },
        success: function(data) {
            loadedEvents.length = 0;
            eventCount = 0;
            
            var eventList = document.querySelector(".events");
            eventList.innerHTML = "";
            var eventListHtml = "";
            
            for (let i = 0; i < data.events.length; i++) {
                var eventElement = document.createElement("li");
                eventList.appendChild(eventElement);
                eventElement.id = eventCount;
                eventElement.innerText = data.events[i].name;
                eventElement.style.background = `#${getCategoryColour()}`;
                
                function getCategoryColour(){
                    for(var j = 0; j < loadedCategories.length; j++)
                    {
                        if(loadedCategories[j].id === data.events[i].categoryId)
                        {
                            return loadedCategories[j].colour;
                        }
                    }
                    return "FFFFFF";
                };
                eventCount++;
                loadedEvents[loadedEvents.length] = data.events[i];
            }
            eventList.addEventListener("click", () => {
                if (event.target.tagName === "LI") {
                    selectEvent(event.target.id);
                }
            });
        }
    });
};

const editEventForm = document.querySelector(".editeventform");
const addEventButton = document.getElementById("addEventButton");
const addEventForm = document.querySelector(".addeventform");

const deleteEventButton = document.getElementById("deleteeventbutton");

const selectEvent = (id) => {
    var selectedEvent = loadedEvents[id];
    selectedEventId = selectedEvent.id;
    
    document.getElementById("editeventname").value = selectedEvent.name;
    document.getElementById("editeventstarttime").value = selectedEvent.start_time;
    document.getElementById("editeventendtime").value = selectedEvent.end_time;
    document.getElementById("editeventlocation").value = selectedEvent.location;
    document.getElementById("editeventrepetition").value = selectedEvent.repetition;
    
    addEventForm.style.visibility = "hidden";
    addEventForm.style.display = "none";
    editEventForm.style.visibility = "visible";
    editEventForm.style.display = "block";
};

addEventButton.addEventListener("click", () => {
    editEventForm.style.visibility = "hidden";
    editEventForm.style.display = "none";
    addEventForm.style.visibility = "visible";
    addEventForm.style.display = "block";
});
addEventForm.addEventListener('submit', () => {
    addEvent();
});
editEventForm.addEventListener('submit', () => {
    editEvent();
});
const editEvent = () => {
    event.preventDefault();
    
    const eventName = editEventForm.querySelector('#editeventname').value;
    const eventStartTime = editEventForm.querySelector('#editeventstarttime').value;
    const eventEndTime = editEventForm.querySelector('#editeventendtime').value;
    const eventLocation = editEventForm.querySelector('#editeventlocation').value;
    const eventRepetition = editEventForm.querySelector('#editeventrepetition').value;
    
    let startDate = `${dateSelected}-${currentMonth + 1}-${currentYear} ${eventStartTime}`;
    let endDate = `${dateSelected}-${currentMonth + 1}-${currentYear} ${eventEndTime}`;
    
    $.ajax({
        type: "POST",
        url: "/Home/EditEvent",
        data: { id: selectedEventId, name: eventName, startTime: startDate, endTime: endDate, location: eventLocation, repetition: eventRepetition },
        success: function() {
            showDateData();
            editEventForm.style.visibility = "hidden";
        }
    })
};
const addEvent = () => {
    event.preventDefault();
    
    const eventName = addEventForm.querySelector('#eventname').value;
    const eventStartTime = addEventForm.querySelector('#eventstarttime').value;
    const eventEndTime = addEventForm.querySelector('#eventendtime').value;
    const eventLocation = addEventForm.querySelector('#eventlocation').value;
    const eventRepetition = addEventForm.querySelector('#eventrepetition').value;
    
    let startDate = `${dateSelected}-${currentMonth + 1}-${currentYear} ${eventStartTime}`;
    let endDate = `${dateSelected}-${currentMonth + 1}-${currentYear} ${eventEndTime}`;
    
    addEventForm.reset();
    
    $.ajax({
        type: "POST",
        url: "/Home/AddNewEvent",
        data: { name: eventName, startTime: startDate, endTime: endDate, location: eventLocation, repetition: eventRepetition },
        success: function() {
            showDateData();
            addEventForm.style.visibility = "hidden";
            addEventForm.style.display = "none";
        }
    });
}

const deleteEvent = () => {
    $.ajax({
        type: "POST",
        url: "/Home/DeleteEvent",
        data: { id: selectedEventId },
        success: function() {
            showDateData();
            editEventForm.style.visibility = "hidden";
            editEventForm.style.display = "none";
        }
    });
};

const getAllCategories = () => {
    $.ajax({
        type: "POST",
        url: "/Home/GetAllCategories",
        success: function(data) {
            for(var i = 0; i < data.categories.length; i++){
                loadedCategories[loadedCategories.length] = data.categories[i];
            }
            console.table(loadedCategories);
        }
    })
};

prevNextIcon.forEach(icon => {
    icon.addEventListener("click", () => {
        cycleMonth(icon);
    })
});

days.addEventListener("click", (event) => {
    selectDay(event);
})

deleteEventButton.addEventListener("click", () => {
    deleteEvent();
})

const getCategoryData = () => {

};
renderCalendar();
getAllCategories();
showDateData();