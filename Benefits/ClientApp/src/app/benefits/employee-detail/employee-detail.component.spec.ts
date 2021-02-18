import { async, ComponentFixture, TestBed } from "@angular/core/testing";
import { HttpClientTestingModule } from "@angular/common/http/testing";
import { EmployeeDetailComponent } from "./employee-detail.component";
import { FormsModule } from "@angular/forms";
import { RouterTestingModule } from "@angular/router/testing";

function getBaseUrl() {
  return "http://localhost";
}

describe("EmployeeDetailComponent", () => {
  let component: EmployeeDetailComponent;
  let fixture: ComponentFixture<EmployeeDetailComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [EmployeeDetailComponent],
      imports: [HttpClientTestingModule, FormsModule, RouterTestingModule],
      providers: [{ provide: "BASE_URL", useFactory: getBaseUrl }],
    }).compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EmployeeDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it("should create", () => {
    expect(component).toBeTruthy();
  });
});
