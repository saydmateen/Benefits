import { Component, OnDestroy, OnInit } from "@angular/core";
import { ActivatedRoute, Router } from "@angular/router";
import { Subscription } from "rxjs";
import { map } from "rxjs/internal/operators/map";
import { BenefitsService } from "../benefits-service/benefits.service";
import { Employee, IEmployee } from "../models/employee";
import { Person } from "../models/person";

@Component({
  selector: "app-employee-detail",
  templateUrl: "./employee-detail.component.html",
  styleUrls: ["./employee-detail.component.css"],
})
export class EmployeeDetailComponent implements OnInit, OnDestroy {
  public employee: Employee;
  public dependentNew: Person;
  public readonly id: number;
  public _subs: Subscription[] = [];

  public readonly relationshipType = [
    { key: "", value: "" },
    { key: "spouse", value: "Spouse" },
    { key: "child", value: "Child" },
    { key: "other", value: "Other" },
  ];

  constructor(
    private benefitsService: BenefitsService,
    private routerService: Router,
    route: ActivatedRoute
  ) {
    this.id = parseInt(route.snapshot.paramMap.get("id"));
  }

  ngOnInit() {
    this.employee = new Employee();
    this.dependentNew = new Person();

    if (this.id > 0) {
      this._subs.push(
        this.benefitsService
          .getEmployee(this.id)
          .pipe(map((x) => x as Employee))
          .subscribe((results) => {
            this.employee = results;
          })
      );
    }
  }

  addDependent() {
    this.employee.dependents.push(this.dependentNew);
    this.dependentNew = new Person();
  }

  saveEmployee() {
    let employeeData: IEmployee = {
      employeeId: this.employee.employeeId,
      firstName: this.employee.firstName,
      lastName: this.employee.lastName,
      age: this.employee.age,
      dependents: this.employee.dependents.map((d) => {
        return {
          personId: d.personId,
          firstName: d.firstName,
          lastName: d.lastName,
          relationship: d.relationship,
          age: d.age,
        };
      }),
    };

    if (this.id > 0) {
      this._subs.push(
        this.benefitsService
          .updateEmployee(employeeData)
          .subscribe((results) => {
            if (results) {
              this.routerService.navigate(["/benefits"]);
            }
          })
      );
    } else {
      this._subs.push(
        this.benefitsService
          .createEmployee(employeeData)
          .subscribe((results) => {
            if (results) {
              this.routerService.navigate(["/benefits"]);
            }
          })
      );
    }
  }

  deleteEmployee(event: Event, index: number) {
    event.stopPropagation();
    this.employee.dependents.splice(index, 1);
  }

  ngOnDestroy() {
    this._subs.forEach((s) => s.unsubscribe());
  }
}
