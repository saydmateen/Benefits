import { TestBed } from "@angular/core/testing";
import { HttpClientTestingModule } from "@angular/common/http/testing";
import { BenefitsService } from "./benefits.service";
import { ApiService } from "src/app/core/api.service";

function getBaseUrl() {
  return "http://localhost";
}

describe("BenefitsService", () => {
  beforeEach(() =>
    TestBed.configureTestingModule({
      imports: [HttpClientTestingModule],
      providers: [{ provide: "BASE_URL", useFactory: getBaseUrl }],
    })
  );

  it("should be created", () => {
    const service: BenefitsService = TestBed.get(BenefitsService);
    expect(service).toBeTruthy();
  });
});
