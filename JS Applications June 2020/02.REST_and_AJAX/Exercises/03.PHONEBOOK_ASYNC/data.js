function host (endpoint) {

    if (endpoint === undefined) {
        return "http://localhost:7000/phonebook";
    }
    else{
        return `http://localhost:7000/phonebook/${endpoint}`;
    }
}

export async function getData() {
    const data = await(await fetch(host(""))).json();

    return data;
}

export async function createEntry(entry) {
    return (await fetch(host(), {
        method: "POST",
        body: JSON.stringify(entry)
    })).json();
}

export function deleteEntry(id) {
    return new Promise((resolve, reject) => {
        fetch(host(id), {
            method: "DELETE"
        }).then(data => {
            setTimeout(resolve, 800);
        }).catch(error => reject(error));
    });
}