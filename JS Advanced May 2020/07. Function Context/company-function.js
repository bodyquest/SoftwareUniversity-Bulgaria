   class Company {
      constructor(){
         this.departments = [
         ];
      };

      addEmployee(username, salary, position, department) {
         // validate params
         this._validateParam(username);
         this._validateParam(salary);
         this._validateParam(position);
         this._validateParam(department);
         
         // validate salary
         if (salary < 0) {
            throw new Error("Invalid input!");
         }
         
         // add to the array

         // find the reference to the dept. by name
         let currentD = this.departments.find(d => d.name === department);

         // if dept. does not exist, make it
         if (currentD === undefined) {
            currentD = {
               name: department,
               employees: []
            }

            this.departments.push(currentD);
         }

         // add the worker to the dept.
         currentD.employees.push({
            username,
            salary,
            position
         });

         return `New employee is hired. Name: ${username}. Position: ${position}`;
      };

      bestDepartment() {
         // sort by avg salary
         const departments = this.departments.map(d => {
            const dep = Object.assign({}, d);
            dep.averageSalary = d.employees.reduce((p, c, i, a) => p + c.salary, 0) / d.employees.length;
            return dep
         });
         
         departments.sort((a, b) => b.averageSalary - a.averageSalary)
         // take the first
         const best = departments[0];
         if (best !== undefined) {
            // sort the workers by salary and name
            best.employees.sort((a, b) => b.salary - a.salary || a.username.localeCompare(b.username));
            // return a string as per the problem
            const result = [
               `Best Department is: ${best.name}`,
               `Average salary: ${best.averageSalary.toFixed(2)}`
            ];

               best.employees.forEach(e => result.push(
                  `${e.username} ${e.salary} ${e.position}`
               ));

            return result.join("\n")
         }

      };

      _validateParam(param){
         if (param === "" || param === undefined || param === null) {
            throw new Error ("invalid input!");
         }
      }
   }

let c = new Company();
c.addEmployee("Stanimir", 2000, "engineer", "Construction");
c.addEmployee("Pesho", 1500, "electrical engineer", "Construction");
c.addEmployee("Slavi", 500, "dyer", "Construction");
c.addEmployee("Stan", 2000, "architect", "Construction");
c.addEmployee("Stanimir", 1200, "digital marketing manager", "Marketing");
c.addEmployee("Pesho", 1000, "graphical designer", "Marketing");
c.addEmployee("Gosho", 1350, "HR", "Human resources");
console.log(c.bestDepartment());
