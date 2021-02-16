import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { EmployeeDetailComponent } from "./employee-detail/employee-detail.component";
import { EmployeeHomeComponent } from "./employee-home/employee-home.component";

@NgModule({
  declarations: [EmployeeDetailComponent, EmployeeHomeComponent],
  imports: [CommonModule],
})
export class BenefitsModule {}
