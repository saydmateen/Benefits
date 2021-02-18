import { async, ComponentFixture, TestBed } from "@angular/core/testing";
import { HttpClientTestingModule } from "@angular/common/http/testing";
import { EmployeeHomeComponent } from "./employee-home.component";
import { RouterTestingModule } from "@angular/router/testing";

function getBaseUrl() {
  return "http://localhost";
}

describe("EmployeeHomeComponent", () => {
  let component: EmployeeHomeComponent;
  let fixture: ComponentFixture<EmployeeHomeComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [EmployeeHomeComponent],
      imports: [HttpClientTestingModule, RouterTestingModule],
      providers: [{ provide: "BASE_URL", useFactory: getBaseUrl }],
    }).compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EmployeeHomeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it("should create", () => {
    expect(component).toBeTruthy();
  });
});
