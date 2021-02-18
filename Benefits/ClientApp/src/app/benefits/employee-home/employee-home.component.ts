import { Component, OnDestroy, OnInit } from "@angular/core";
import { Subscription } from "rxjs";
import { BenefitsService } from "../benefits-service/benefits.service";
import { Employee } from "../models/employee";
import { map } from "rxjs/operators";
import { Router } from "@angular/router";

@Component({
  selector: "app-employee-home",
  templateUrl: "./employee-home.component.html",
  styleUrls: ["./employee-home.component.css"],
})
export class EmployeeHomeComponent implements OnInit, OnDestroy {
  public employees: Employee[] = [];
  public _subs: Subscription[] = [];
  public benefitsTotal: number = 0;

  constructor(
    private benefitsService: BenefitsService,
    private routerService: Router
  ) {}

  ngOnInit() {
    this._subs.push(
      this.benefitsService
        .getAllEmployees()
        .pipe(map((x) => x as Employee[]))
        .subscribe((results) => {
          this.employees = results;
          this.employees.forEach((e) => {
            this.benefitsTotal += e.benefitsCost;
          });
        })
    );
  }

  ngOnDestroy() {
    this._subs.forEach((s) => s.unsubscribe());
  }

  onSelect(employee: Employee) {
    this.routerService.navigate(["/benefits/", employee.employeeId]);
  }

  createEmployee() {
    this.routerService.navigate(["/benefits/", 0]);
  }

  deleteEmployee(event: Event, index: number) {
    event.stopPropagation();
    this._subs.push(
      this.benefitsService
        .deleteEmployee(this.employees[index].employeeId)
        .subscribe((results) => {
          if (results) {
            this.employees.splice(index, 1);
            this.benefitsTotal = 0;
            this.employees.forEach((e) => {
              this.benefitsTotal += e.benefitsCost;
            });
          }
        })
    );
  }
}
