import { IPerson } from "./person";

export interface IEmployee {
  employeeId?: number;
  salary?: number;
  benefitsCost?: number;
  firstName: string;
  lastName: string;
  age: number;
  dependents: IPerson[];
}

export class Employee implements IPerson, IEmployee {
  private _employeeId?: number;
  private _firstName: string;
  private _lastName: string;
  private _age: number;
  private _salary: number;
  private _benefitsCost: number;
  private _dependents: IPerson[];

  constructor() {
    this._firstName = "";
    this._lastName = "";
    this._dependents = [];
  }

  get employeeId(): number {
    return this._employeeId;
  }

  get firstName(): string {
    return this._firstName;
  }
  set firstName(value: string) {
    this._firstName = value;
  }

  get lastName(): string {
    return this._lastName;
  }
  set lastName(value: string) {
    this._lastName = value;
  }

  get age(): number {
    return this._age;
  }
  set age(value: number) {
    this._age = value;
  }

  get salary(): number {
    return this._salary;
  }

  get benefitsCost(): number {
    return this._benefitsCost;
  }

  get dependents(): IPerson[] {
    return this._dependents;
  }

  set dependents(value: IPerson[]) {
    this._dependents = value;
  }
}
