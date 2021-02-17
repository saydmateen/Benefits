import { BrowserModule } from "@angular/platform-browser";
import { NgModule } from "@angular/core";
import { FormsModule } from "@angular/forms";
import { HttpClientModule, HTTP_INTERCEPTORS } from "@angular/common/http";
import { RouterModule } from "@angular/router";

import { AppComponent } from "./app.component";
import { HomeComponent } from "./home/home.component";
import { SharedModule } from "./shared/shared.module";
import { CoreModule } from "./core/core.module";
import { BenefitsModule } from "./benefits/benefits.module";
import { EmployeeHomeComponent } from "./benefits/employee-home/employee-home.component";
import { EmployeeDetailComponent } from "./benefits/employee-detail/employee-detail.component";

@NgModule({
  declarations: [AppComponent, HomeComponent],
  imports: [
    BrowserModule.withServerTransition({ appId: "ng-cli-universal" }),
    HttpClientModule,
    CoreModule,
    FormsModule,
    SharedModule,
    BenefitsModule,
    RouterModule.forRoot([
      { path: "", component: HomeComponent, pathMatch: "full" },
      { path: "benefits", component: EmployeeHomeComponent },
      { path: "benefits/:id", component: EmployeeDetailComponent },
    ]),
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
