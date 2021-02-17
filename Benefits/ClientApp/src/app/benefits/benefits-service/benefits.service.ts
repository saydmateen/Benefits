import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { ApiService } from "src/app/core/api.service";
import { Employee } from "../models/employee";

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

  createEmployee(employee: Employee): Observable<Employee> {
    return this.apiService.sendRequest<Employee>(
      "benefits/employee",
      "POST",
      employee
    );
  }

  updateEmployee(employee: Employee): Observable<Employee> {
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

  getCostsPreview(employees: Employee[]) {
    return this.apiService.sendRequest<Employee[]>(
      "benefits/previewCosts",
      "POST",
      employees
    );
  }
}
