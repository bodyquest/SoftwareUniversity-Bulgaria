function solve (){
    // create object
    const argTypes = {};
    
    // walk the arguments
    for (let arg of arguments) {
        const type = typeof arg;
        console.log(`${type}: ${arg}`);
        // count type count
        if (argTypes[type] === undefined) {

            argTypes[type] = 0;
        }

        argTypes[type]++;
    };

    // print the count
    Object.entries(argTypes)
        .sort((a,b) => b[1] - a[1])
        .forEach(e => console.log(`${e[0]} = ${e[1]}`));
}

solve("cat", 42, function() {console.log("Hello world!"); });