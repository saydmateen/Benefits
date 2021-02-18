import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { ApiService } from "src/app/core/api.service";
import { Employee, IEmployee } from "../models/employee";

@Injectable({
  providedIn: "root",
})
export class BenefitsService {
  constructor(private readonly apiService: ApiService) {}

  getAllEmployees(): Observable<Employee[]> {
    return this.apiService.sendRequest<Employee[]>(
      "benefits/employeesAll",
      "GET"
    );
  }

  getEmployee(id: number): Observable<Employee> {
    return this.apiService.sendRequest<Employee>(
      `benefits/employee/${id}`,
      "GET"
    );
  }

  createEmployee(employee: IEmployee): Observable<Employee> {
    return this.apiService.sendRequest<Employee>(
      "benefits/employee",
      "POST",
      employee
    );
  }

  updateEmployee(employee: IEmployee): Observable<Employee> {
    return this.apiService.sendRequest<Employee>(
      "benefits/employee",
      "PUT",
      employee
    );
  }

  deleteEmployee(id: number): Observable<Employee> {
    return this.apiService.sendRequest<Employee>(
      `benefits/employee/${id}`,
      "DELETE"
    );
  }
}
