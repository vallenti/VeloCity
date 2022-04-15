import { Pipe, PipeTransform } from "@angular/core";

@Pipe({
  name: 'currencyBGN'
})
export class CurrencyBGNPipe implements PipeTransform {
  transform(value: number) {
    return `${value.toFixed(2)} лв`;;
  }
}
