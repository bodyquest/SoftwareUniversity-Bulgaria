const appId = "C37FA95F-0D6A-9940-FF9B-AAABADC18D00";
const apiKey = "438AA7CE-7E50-4CA0-B6E7-6EEE19783B2E";

function host(endpoint){
    return `https://api.backendless.com/${appId}/${apiKey}/data/${endpoint}`;
}

export async function getStudents(){

    const response = await fetch(host("students"));
    const data = await response.json();
    
    return data;
}

export async function createStudent(student){
    const response = await fetch(host("students"), {
        method: "POST",
        body: JSON.stringify(student),
        headers: {
            "Content-Type": "application/json" 
        }
    });

    const data = await response.json();
    return data;
}