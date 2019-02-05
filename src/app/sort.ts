import { Pipe, PipeTransform } from '@angular/core';


@Pipe({
  name: 'sortingItems'
})
export class SortingItemsPipe implements PipeTransform {
  transform(items: any[], path: string, order: number): any[] {
       
    // Check if is not null
    if (!items || !path || !order) return items;

    return items.sort((a, b) => {
          return a[path] > b[path] ? 1 : - 1;
      
    })
  }

}