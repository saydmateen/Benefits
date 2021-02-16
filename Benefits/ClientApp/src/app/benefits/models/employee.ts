import { Person } from "./person";

export interface Employee {
  employeeId?: number;
  salary: number;
  benefitsCost: number;
  dependents: Person[];
}
