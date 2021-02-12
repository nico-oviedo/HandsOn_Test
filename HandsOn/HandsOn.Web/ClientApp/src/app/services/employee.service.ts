import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Employee } from '../models/employee.model';

@Injectable()
export class EmployeeService {
  private apiUrl: string = 'api/employee/';
  private loading: boolean;
  private noResults: boolean;
  private employeesData: Employee[];

  constructor(private httpClient: HttpClient) { }

  get employees(): Employee[] {
    return this.employeesData;
  }

  get performingSearch(): boolean {
    return this.loading;
  }

  get noResultsSearch(): boolean {
    return this.noResults;
  }

  public getEmployeesData(id: number): void {
    this.clearEmployeesData();
    this.loading = true;

    if (id) {
      this.getEmployee(id);
    }
    else {
      this.getEmployees();
    }
  }

  private getEmployee(id: number): void {
    this.httpClient.get<Employee>(this.apiUrl + id)
      .subscribe(data => {
        if (data) {
          this.employeesData.push(data);
        }
        else {
          this.noResults = true;
        }
        this.loading = false;
      }, error => console.error(error));
  }

  private getEmployees(): void {
    this.httpClient.get<Employee[]>(this.apiUrl)
      .subscribe(data => {
        if (data) {
          this.employeesData = data;
        }
        else {
          this.noResults = true;
        }
        this.loading = false;
      }, error => console.error(error));
  }

  public clearEmployeesData(): void {
    this.employeesData = null;
    this.employeesData = [];
    this.noResults = false;
  }
}
