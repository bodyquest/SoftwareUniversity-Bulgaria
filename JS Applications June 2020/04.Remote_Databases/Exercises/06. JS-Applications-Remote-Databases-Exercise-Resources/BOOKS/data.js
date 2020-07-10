const appId = "C37FA95F-0D6A-9940-FF9B-AAABADC18D00"
const apiKey = "438AA7CE-7E50-4CA0-B6E7-6EEE19783B2E";

function host(endpoint){
    return `https://api.backendless.com/${appId}/${apiKey}/data/${endpoint}`;
}

export async function getBooks(){

    const response = await fetch(host("books"));
    const data = await response.json();
    
    return data;
}

export async function createBook(book){
    const response = await fetch(host("books"), {
        method: "POST",
        body: JSON.stringify(book),
        headers: {
            "Content-Type": "application/json" 
        }
    });

    const data = await response.json();
    return data;
}

export async function updateBook(book){
    const id = book.objectId;
    const response = await fetch(host("books/" + id), {
        method: "PUT",
        body: JSON.stringify(book),
        headers: {
            "Content-Type": "application/json" 
        }
    });

    const data = await response.json();
    return data;
}

export async function deleteBook(id){

    const response = await fetch(host("books/" + id), {
        method: "DELETE"
    });

    const data = await response.json();
    return data;
}