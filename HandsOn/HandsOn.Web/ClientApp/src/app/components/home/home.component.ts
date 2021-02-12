import { Component } from '@angular/core';
import { AbstractControl, FormBuilder, FormGroup } from '@angular/forms';
import { Employee } from '../../models/employee.model';
import { EmployeeService } from '../../services/employee.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent {
  searchForm: FormGroup;

  constructor(private employeeService: EmployeeService, private formBuilder: FormBuilder) {
    this.createSearchForm();
  }

  get performingSearch(): boolean {
    return this.employeeService.performingSearch;
  }

  get noResultsSearch(): boolean {
    return this.employeeService.noResultsSearch;
  }

  get employees(): Employee[] {
    return this.employeeService.employees;
  }

  get employeeId(): AbstractControl {
    return this.searchForm.get('employeeId');
  }

  setEmployeeId(value: string): void {
    this.searchForm.get('employeeId').setValue(value);
  }

  private createSearchForm() {
    this.searchForm = this.formBuilder.group({
      employeeId: ''
    });
  }

  getEmployeesClick(): void {
    this.employeeService.getEmployeesData(this.employeeId.value);
  }

  clearEmployeesClick(): void {
    this.employeeService.clearEmployeesData();
    this.setEmployeeId('');
  }
}
