// Example of Partial Application 
// the finalRender() function can be reused because it can collect needed data from the previous functions which do the various tasks for the fial function.

function renderTable(employees, offices, otherData){
    // do something with DOM
}

function collectEmployees(employees){
    //.. parsing could exist
    return function(offices, otherData){
        renderTable(employees, offices, otherData);
    }
}

const employeeData = ["john", "peter", "george"];
const collectOtherData = collectEmployees(employeeData);

// in other part of the application
const offices = ["main", "south", "west"];
const otherData = [5, 1, 67, 12];
const finalRender = collectOtherData(offices, otherData);

// ... render the data
finalRender();