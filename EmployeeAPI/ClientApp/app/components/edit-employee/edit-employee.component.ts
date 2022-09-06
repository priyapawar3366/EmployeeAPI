import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Employee } from 'src/app/models/employee';
import { EmployeeService } from 'src/app/services/employee.service';

@Component({
  selector: 'app-edit-employee',
  templateUrl: './edit-employee.component.html',
  styleUrls: ['./edit-employee.component.css']
})
export class EditEmployeeComponent implements OnInit {
  @Input() emp?:Employee;
  @Output () empsupdated = new EventEmitter<Employee[]>();
  constructor(private empservice:EmployeeService) { 

  }

  ngOnInit(): void {
  }
  updateEmployee(emp:Employee){
      this.empservice.updateEmployee(emp).
      subscribe((emps:Employee[]) => this.empsupdated.emit(emps));
  }
  deleteEmployee(emp:Employee){
    this.empservice.deleteEmployee(emp).
    subscribe((emps:Employee[]) => this.empsupdated.emit(emps));
  }
  createEmployee(emp:Employee){
    this.empservice.createEmployee(emp).
    subscribe((emps:Employee[]) => this.empsupdated.emit(emps));
  }
}
