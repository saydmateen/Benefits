import { Component, OnDestroy, OnInit } from "@angular/core";
import { Subscription } from "rxjs";
import { BenefitsService } from "../benefits-service/benefits.service";
import { Employee } from "../models/employee";
import { map } from "rxjs/operators";

@Component({
  selector: "app-employee-home",
  templateUrl: "./employee-home.component.html",
  styleUrls: ["./employee-home.component.css"],
})
export class EmployeeHomeComponent implements OnInit, OnDestroy {
  public employees: Employee[] = [];
  public _subs: Subscription = Subscription.EMPTY;

  constructor(private benefitsService: BenefitsService) {}

  ngOnInit() {
    this._subs = this.benefitsService
      .getEmployees()
      .pipe(map((x) => x as Employee[]))
      .subscribe((results) => {
        this.employees = results;
      });
  }

  ngOnDestroy() {
    this._subs.unsubscribe();
  }
}
