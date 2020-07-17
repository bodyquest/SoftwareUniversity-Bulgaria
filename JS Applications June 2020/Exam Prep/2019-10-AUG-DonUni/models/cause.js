let db = firebase.firestore()

export default {
    create(data){
        return db.collection("causes").add(data);
    },
    getAll(){
        return db.collection("causes").get();
    },
    get(causeId){
        return db.collection("causes").doc(causeId).get();
    },
    close(causeId) {
        return db.collection("causes").doc(causeId).delete();
    },
    donate(causeId, data) {
        return db.collection("cause").doc(causeId).update(data);
    }
}; 