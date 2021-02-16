import { TestBed } from "@angular/core/testing";

import { BenefitsService } from "./benefits.service";

describe("BenefitsService", () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it("should be created", () => {
    const service: BenefitsService = TestBed.get(BenefitsService);
    expect(service).toBeTruthy();
  });
});
