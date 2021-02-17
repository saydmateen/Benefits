export interface IPerson {
  personId?: number;
  firstName: string;
  lastName: string;
  age: number;
  relationship?: string;
}

export class Person implements IPerson {
  private _personId: number;
  private _firstName: string;
  private _lastName: string;
  private _age: number;
  private _relationShip: string;

  constructor() {
    this._firstName = "";
    this._lastName = "";
  }

  get personId(): number {
    return this._personId;
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

  get relationship(): string {
    return this._relationShip;
  }
  set relationship(value: string) {
    this._relationShip = value;
  }
}
