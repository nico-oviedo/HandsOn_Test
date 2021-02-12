import { Contract } from "./contract.model";
import { Role } from "./role.model";

export class Employee {
  id: number;
  name: string;
  role: Role;
  contract: Contract;
  annualSalary?: number;
}
