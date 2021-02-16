import { BrowserModule } from "@angular/platform-browser";
import { NgModule } from "@angular/core";
import { FormsModule } from "@angular/forms";
import { HttpClientModule, HTTP_INTERCEPTORS } from "@angular/common/http";
import { RouterModule } from "@angular/router";

import { AppComponent } from "./app.component";
import { HomeComponent } from "./home/home.component";
import { SharedModule } from "./shared/shared.module";
import { CoreModule } from "./core/core.module";

@NgModule({
  declarations: [AppComponent, HomeComponent],
  imports: [
    BrowserModule.withServerTransition({ appId: "ng-cli-universal" }),
    HttpClientModule,
    CoreModule,
    FormsModule,
    SharedModule,
    RouterModule.forRoot([
      { path: "", component: HomeComponent, pathMatch: "full" },
      {
        path: "benefits",
        loadChildren: () =>
          import("./benefits/benefits.module").then((m) => m.BenefitsModule),
      },
    ]),
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
