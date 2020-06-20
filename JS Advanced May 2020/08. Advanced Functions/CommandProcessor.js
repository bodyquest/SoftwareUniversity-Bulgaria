var  processor = (function (){
    let property = "";

    function append (input) {
        property += input;
    }

    function removeStart (num) {
        property =  property.substring(num);
    }

    function removeEnd (num) {
        if (property.length >= num) {
            property = property.substring(0, property.length - num);
        }
        
    }

    function print(){
        return console.log(property);
        ;
    }

    return {
        append,
        removeStart,
        removeEnd,
        print
    }

})();

processor.append("hello ");
processor.print();
processor.removeStart(2);
processor.print();