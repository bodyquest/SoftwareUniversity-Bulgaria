
class Computer{
        constructor(ramMemory, cpuGhz, hddMemory){
            this.ramMemory = ramMemory;
            this.cpuGhz = cpuGhz;
            this.hddMemory = hddMemory;

            this.taskManager = [];
            this.installedPrograms = [];
        }

        installAProgram(name, requiredSpace){
            if (requiredSpace > this.hddMemory) {
                throw new Error("There is not enough space on the hard drive");
            }

            let program = {
                name,
                requiredSpace
            }

            this.installedPrograms.push(program);
            this.hddMemory -= requiredSpace;

            return program;
        }

        uninstallAProgram(name){
            let programIndex = this.installedPrograms.findIndex((p) => p.name === name);

            if (programIndex === -1) {
                throw new Error("Control panel is not responding");
            }

            let program = this.installedPrograms.splice(programIndex, 1);

            this.hddMemory += this.installedPrograms[programIndex].requiredSpace;

            return this.installedPrograms;
        }

        openAProgram(name){
            let programIndex = this.installedPrograms.findIndex((p) => p.name === name);

            if (programIndex === -1) {
                throw new Error(`The ${name} is not recognized`);
            }

            let openedProgramIndex = this.taskManager.findIndex((p) => p.name === name);
            if (openedProgramIndex > -1) {
                throw new Error(`The ${name} is already open`);
            }

            let program = this.installedPrograms[programIndex];

            let memoryUsage = (program.requiredSpace / this.ramMemory) * 1.5;
            let cpuUsage = (( program.requiredSpace / this.cpuGhz ) / 500) * 1.5

            if ((this.ramTotalUsage + memoryUsage) >= 100) {
                 throw new Error(`${name} caused out of memory exception`);
            }
            if ((this.cpuTotalUsage + cpuUsage) >= 100) {
                throw new Error(`${name} caused out of cpu exception`);
            }

            const openedProgram = {
                 name,
                 memoryUsage,
                 cpuUsage
            }

            this.taskManager.push(openedProgram);

            return openedProgram;
        }

        get ramTotalUsage(){
            return this.taskManager.reduce((acc, curr) => acc + curr.memoryUsage, 0)
        }
        get cpuTotalUsage(){
            return this.taskManager.reduce((acc, curr) => acc + curr.cpuUsage, 0)
        }

        taskManagerView(){
            if (this.taskManager.length === 0) {
                return "All running smooth so far";
            }

            return this.taskManager
            .map((p) => `Name - ${p.name} | Usage - CPU: ${p.cpuUsage.toFixed(0)}%, RAM: ${p.memoryUsage.toFixed(0)}%`).join("\n");
        }
}

let computer = new Computer(4096, 7.5, 250000);
computer.installAProgram("Word", 7300);
