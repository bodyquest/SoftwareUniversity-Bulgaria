function solve (){
    // create object
    const argTypes = [];
    const index = {};
    
    // walk the arguments
    for (let arg of arguments) {
        const type = typeof arg;

        // count type count
        let argIndex = index[type];
        if (argIndex === undefined) {

            argIndex = argTypes.length;
            argTypes.push({
                type,
                count: 0
            });

            index[type] = argIndex;
        }

        argTypes[argIndex].count ++;
    };

    // print the count
    argTypes.sort((a, b) => b.count - a.count).forEach(e => console.log(`${e.type} = ${e.count}`));
    
}

solve("cat", 42, function() {console.log("Hello world!"); });