// 07. Bug Tracker
// functionality - add, delete, change, change the HTML automatically
/**
 * { ID: Number,
  author: String,
  description: String,
  reproducible: Boolean,
  severity: Number,
  status: String }

 */

 // we should expose a module with functionalities:
 // !!! this means return object with the functions, the API actually

function solve () {
    // declare associative array with comparator functions
    const comparators = {
        "ID": (a, b) => a[0] - b[0],
        "author": (a, b) => a[1].author.localeCompare(b[1].author),
        "severity": (a, b) => a[1].severity - b[1].severity
    }
    
    // declare collection with bugs-reports - a template and DOM references
    let currentId = 0;
    const reports = new Map();
    let outputRef = null;
    let sortingMethod = "ID";

    // factory function - making bugs-reports
    // this function should create DOM element and add it to the array "elements"

    // "Peter", "I found this bug", true, 1
    function report(author, description, reproducible, severity){
        let status = "Open"
        const statusSpan = el("span", `${status} | ${severity}`, {className: "status"});

        const element = el("div", [
            el("div", el("p", description), {className: "body"}),
            el("div", [
                el("span", `Submitted by: ${author}`, {className: "author"}),
                statusSpan
            ], {className: "title"})
        ], {
            id: `report_${currentId}`,
            className: "report"
        });

        const newReport = {
            ID: currentId,
            author,
            description, 
            reproducible,
            severity,
            element // DOM element
        };

        Object.defineProperty(newReport, "status", {
            get: () => status,
            set: (value) => {
                status = value;
                statusSpan.textContent = `${status} | ${severity}`;
            }
        });

        // add object with id to the reports associative collection
        reports.set(currentId, newReport);
        
        currentId ++;
        
        render();
    }
    // functions for report manipulation
    function setStatus(id, newStatus){
        reports.get(id).status = newStatus;
    }

    function remove(id){
        reports.get(id).element.remove();
        reports.delete(id);
        render();
    }

    function sort(method){
        // sort DOM elements
        sortingMethod = method;
        render();
    }

    // function to attach the generated HTML
    function output(newSelector){
        outputRef = document.querySelector(newSelector);
        render();
    }

    function render(){
        // check for valid selector
        if (outputRef !== null) {
            // add the reports to the given order
            [...reports]
                .sort(comparators[sortingMethod])
                .forEach(([id, r]) => outputRef.appendChild(r.element));
        }
    }

    return {
        report,
        setStatus,
        remove,
        sort,
        output
    }

    function el(type, content, attributes){
        const result = document.createElement(type);

        if (attributes !== undefined) {
            Object.assign(result, attributes);
        }
        if (Array.isArray(content)) {
            content.forEach(append);
        }else{
            append(content);
        }

        function append(node){
            if (typeof node === "string") {
                node = document.createTextNode(node);
            }

            result.appendChild(node);
        }

        return result;
    }
}