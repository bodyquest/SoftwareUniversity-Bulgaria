const baseUrl = `https://fisher-game.firebaseio.com/catches`;

export async function listCatches(){

    const response = await fetch(baseUrl + ".json");
    const data = await response.json();
    
    return data;
}

export async function createCatch(fish){
    const response = await fetch((baseUrl + ".json"), {
        method: "POST",
        body: JSON.stringify(fish),
        headers: {
            "Content-Type": "application/json" 
        }
    });

    const data = await response.json();
    return data;
}

export async function updateCatch(id, fish){
    const response = await fetch((baseUrl + `/${id}.json`), {
        method: "PUT",
        body: JSON.stringify(fish),
        headers: {
            "Content-Type": "application/json" 
        }
    });

    const data = await response.json();
    return data;
}

export async function deleteCatch(id){

    const response = await fetch((baseUrl + `/${id}.json`), {
        method: "DELETE"
    });

    const data = await response.json();
    return data;
}