let colors = [];

colors.push(Array(10).fill('#ebedf0'));
colors.push(Array(4).fill('#9be9a8'));
colors.push(Array(2).fill('#40c463'));
colors.push(Array(2).fill('#30a14e'));
colors.push(Array(1).fill('#216e39'));

const colorPalette = [].concat.apply([], colors);

// Color Palette
//const colorPalette = ['#ebedf0', '#9be9a8', '#40c463', '#30a14e', '#216e39']

let color1 = colorPalette[Math.floor(Math.random() * colorPalette.length)];

let grid = document.querySelector(".items");
for (let i = 0; i < (daysOfYear()); i++) {
    let item = document.createElement("div");
    item.setAttribute("class", "item");
    item.setAttribute("data-text", "N-найсе commits today!");
    grid.appendChild(item);
}

// Set color values on the element
document.querySelectorAll('.item')
    .forEach(
        i => i.style.setProperty(
            '--color1', colorPalette[Math.floor(Math.random() * colorPalette.length)]
        )
    );

function daysOfYear() 
{
    let currentTime = new Date();
    let year = currentTime.getFullYear();
    return isLeapYear(year) ? 366 : 365;
}

function isLeapYear(year) {
     return year % 400 === 0 || (year % 100 !== 0 && year % 4 === 0);
}