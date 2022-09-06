import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Employee } from '../models/employee';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {
  private url="Employee";
  constructor(private http:HttpClient) { }

  public getEmployees() : Observable<Employee[]>{
  
    return this.http.get<Employee[]>(`${environment.apiUrl}/${this.url}`);
  }
  public updateEmployee(emp:Employee) : Observable<Employee[]>{
  
    return this.http.put<Employee[]>(`${environment.apiUrl}/${this.url}`,emp);
  }
  public createEmployee(emp:Employee) : Observable<Employee[]>{
  
    return this.http.post<Employee[]>(`${environment.apiUrl}/${this.url}`,emp);
  }

  public deleteEmployee(emp:Employee) : Observable<Employee[]>{
  
    return this.http.delete<Employee[]>(`${environment.apiUrl}/${this.url}/${emp.id}`);
  }
  
}
