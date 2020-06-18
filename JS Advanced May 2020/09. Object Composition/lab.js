// 1. Order Rectangles



/**
 * return acc.sort((a,b) => b.area() - a.area() || b.width - a.width);
 */

// 2. List Processor
function solution (commands){

    // const commandMap = {
    //     add: (acc, word) => acc.concat(word),
    //     remove: (acc, word) => acc.filter(i => i !== word),
    //     log: (acc) => {console.log(acc); return acc;}
    // }

    return commands.reduce(function(acc, currCommand) {
        // take first element and the others
        const [op, ...others] = currCommand.split(" ");
        const word = others.join(" ");

        if (op === "add") {
           return acc.concat(word)
        }
        else if(op === "remove"){
            return acc.filter(i => i !== word)
        }

        console.log(acc);
        return acc;
    }, []).join(",");
}

// 4. Cars
function solution2(commands){
    const commandMap = {
        create: (acc, name, _, inheritName) => {
            
            if (!inheritName) {
                acc[name] = {};
                return acc;
            }

            const parent = acc[inheritName];
            acc[name] = Object.create(parent);
            return acc;
        },
        set: (acc, name, propName, propValue) => {
            acc[name][propName] = propValue;
            return acc;
        },
        print: (acc, name) => {
                let itms = [];
                for (let i in acc[name]) {
                    itms.push(`${i} : ${acc[item][i]}`);
                }

                console.log(itms.join(", "));
                return acc;
        }
    }

    return commands.reduce((acc, currCommand) =>{
        const [op, v1, v2, v3] = currCommand.split(" ");
        return commandMap[op](acc, v1, v2, v3);
    }, {});
}

solution2(['create c1',
'create c2 inherit c1',
'set c1 color red',
'set c2 model new',
'print c1',
'print c2']
);