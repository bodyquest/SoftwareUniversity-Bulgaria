import createHTML from "./dom.js";
import * as api from "./db-service.js";

window.addEventListener("load", () => {
    
    // Get input
    const input = {
        firstName: document.querySelector("#firstName"),
        lastName: document.querySelector("#lastName"),
        facultyNumber: document.querySelector("#facNum"),
        grade: document.querySelector("#grade"),
    }

    // Get button, table and add handlers
    const submitBtn = document.querySelector("#submit");
    submitBtn.addEventListener("click", createStudent);

    const tableBody = document.querySelector("#results tbody");
    
    // load students with page
    loadStudents();
    async function loadStudents(){
        tableBody.innerHTML = "<tr><td colspan=`4`>Loading...</td></tr>";
        const students = await api.getStudents();
        tableBody.innerHTML = "";

        if (students) {
            students
            .sort((a, b) => a.ID > b.ID)
            .forEach(b => tableBody.appendChild(renderStudent(b)));
        }
    }

    Object.entries(input).forEach(([k, v]) => v.value = "");

    async function createStudent(e) {
        e.preventDefault();

        if (validateInput(input) === false) {
            alert("All fields are required");
            return;
        }

        const students = await api.getStudents();
        const id = !students ? 0 : students.length + 1;
        const student = {
            ID: id,
            FirstName: input.firstName.value,
            LastName: input.lastName.value, 
            FacultyNumber: input.facultyNumber.value,
            Grade: Number(input.grade.value),
        }

        try {
            const created = await api.createStudent(student);
            tableBody.appendChild(renderStudent(created));
            
            Object.entries(input).forEach(([k, v]) => v.disabled = "");

        } catch (error) {
            alert(error);
            console.log(error);
        }

        Object.entries(input).forEach(([k, v]) => v.value = "");
    }

    function validateInput() {
        let valid = true;

        Object.entries(input).forEach(([k, v]) => {
            if (v.value.length === 0) {
                v.className = "inputError";
                valid = false;
            }else{
                v.removeAttribute("class");
            }
        });

        return valid;
    }

    function renderStudent(student){

        const element = 
        createHTML("tr", [
            createHTML("td", student.ID),
            createHTML("td", student.FirstName),
            createHTML("td", student.LastName),
            createHTML("td", student.FacultyNumber),
            createHTML("td", student.Grade),
        ]);

        return element;
    }
});