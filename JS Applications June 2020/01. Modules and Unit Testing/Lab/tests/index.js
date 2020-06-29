module.exports.sum = function (arr) {
    if (Array.isArray(arr)) {
        return NaN;
    }
    
    return arr.reduce((acc, curr) => acc + Number(curr), 0);
}
