import { Component, OnDestroy, OnInit } from "@angular/core";
import { ActivatedRoute } from "@angular/router";
import { Observable } from "rxjs";
import { map } from "rxjs/internal/operators/map";
import { Employee } from "../models/employee";
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

  public readonly relationshipType = [
    { key: "spouse", value: "Spouse" },
    { key: "child", value: "Child" },
    { key: "other", value: "Other" },
  ];

  constructor(route: ActivatedRoute) {
    this.id = parseInt(route.snapshot.paramMap.get("id"));
  }

  ngOnInit() {
    this.employee = new Employee();
    this.dependentNew = new Person();
  }

  addDependent() {
    this.employee.dependents.push(this.dependentNew);
  }

  ngOnDestroy() {}
}
