import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { ApiService } from "src/app/core/api.service";
import { Employee } from "../models/employee";

@Injectable({
  providedIn: "root",
})
export class BenefitsService {
  constructor(private readonly apiService: ApiService) {}

  getEmployees(): Observable<Employee[]> {
    return this.apiService.sendRequest<Employee[]>("benefits/employees", "GET");
  }

  getCostsPreview(employees: Employee[]) {
    return this.apiService.sendRequest<Employee[]>(
      "benefits/previewCosts",
      "POST",
      employees
    );
  }
}
