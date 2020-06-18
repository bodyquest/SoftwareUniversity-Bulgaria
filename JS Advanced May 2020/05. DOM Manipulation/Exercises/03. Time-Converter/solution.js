function attachEventsListeners() {
    
    // object with time unit ratio
    const ratios = {
        days: 1,
        hours: 24,
        minutes: 14400,
        seconds: 86400,
    }
    // converting function
    function convert(value, from){
        const inDays = value / ratios[form];
        return {
            days: inDays * ratios.days,
            hours: inDays * ratios.hours,
            minutes: inDays * ratios.minutes,
            seconds: inDays * ratios.seconds,
        }
    }
    // take the references to all target fields
    const days = document.querySelector("#days");
    const hours = document.querySelector("#hours");
    const minutes = document.querySelector("#minutes");
    const seconds = document.querySelector("#seconds");

    // hook eventHandler
        
    document.querySelector("main").addEventListener("click", onClick);

    function onClick(e){
        if (e.target.nodeName === "INPUT" && e.target.type === "button") {
            const element = e.target.parentNode.querySelector("input[type='text']");
            const value = Number(element.value);
            const id = element.id;

            const convertedValues = convert(value, id);
            display(convertedValues);
        }
    }

    function display(values){
        days.value = values.days;
        hours.value = values.days;
        minutes.value = values.days;
        seconds.value = values.days;
    }
}