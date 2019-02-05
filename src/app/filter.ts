import { Pipe, PipeTransform, Injectable } from '@angular/core';

@Pipe({
    name: 'filter'
})

export class FilterPipe implements PipeTransform {
    transform(items: any[],  searchText: string): any[] {        
        
        console.log(searchText)
        if (!items) {
            return items;
        } 
       
        if (searchText=="") {
            return items ;
        } 
        
        
        //return items.filter(item => item.includes(searchText));
       
        return  items.filter(item => 
            Object.keys(item).some(k => item[k] != null && 
            item[k].toString().toLowerCase()
            .includes(searchText.toLowerCase()))
            );
          
        
    }
}