function solve (arr, str) {
    let arrSort = arr;
 
    function sortArray () {
 
        if (str === 'asc') {
            arrSort = arrSort.sort((a,b) => a - b);
        }
        else if (str === 'desc') {
            arrSort = arrSort.sort((a,b) => b - a);
        }
        return arrSort;
    }
 
    return sortArray(str);
}