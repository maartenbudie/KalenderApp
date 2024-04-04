const months = ["January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"];

const currentDate = document.querySelector(".current-date"),
    daysTag = document.querySelector(".days"),
    prevNextIcon = document.querySelectorAll(".icons span");


let date = new Date(),
    currentYear = date.getFullYear(),
    currentMonth = date.getMonth();

const renderCalender = () => {
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
}
renderCalender();

prevNextIcon.forEach(icon => {
    icon.addEventListener("click", () => {
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
        renderCalender();
    })
});