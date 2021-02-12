import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'contractName'
})
export class ContractNamePipe implements PipeTransform {

  transform(value: any, args?: any): any {
    if (value) {
      return value.split(/(?=[A-Z])/).join(' ');
    }
    else return '';
  }
}
