import { Component } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Employee } from './models/employee';
import { EmployeeService } from './services/employee.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})


export class AppComponent {
  title = 'EmployeeApp.UI';
  client_env_name:string = environment.env_name;
  server_env_name:string = "";
  employees: Employee[] = [];
  empToEdit?:Employee;
  constructor(private EmployeeService : EmployeeService){}
  ngOnInit():void {
    this.EmployeeService
      .getEmployees()
      .subscribe((result:Employee[]) => (this.employees=result));

  }
 
  addEmployee(){
    this.empToEdit=new Employee;
  }
  editEmployee(emp:Employee){
    this.empToEdit=emp;
  }

  deleteEmployee(emp:Employee){
    this.empToEdit = emp;
  }
  updateEmployeeList(emps:Employee[]){
    this.employees=emps;
  }
  
}
