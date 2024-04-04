const months = ["January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"];

const currentDate = document.querySelector(".current-date"),
daysTag = document.querySelector(".days");

let date = new Date(),
currentYear= date.getFullYear(),
currentMonth = date.getMonth();

const renderCalender = () => {
    let lastDateOfMonth = new Date(currentYear, currentMonth + 1, 0 ).getDate();
    let liTag = "";

    for(let i = 1; i < lastDateOfMonth; i++){
        liTag += `<li>${i}</li>`;
    }

    currentDate.innerText = `${months[currentMonth]} ${currentYear}`;
    daysTag.innerHTML = liTag;
}
renderCalender();