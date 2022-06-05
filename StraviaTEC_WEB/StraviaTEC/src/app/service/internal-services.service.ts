import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';


export interface Categories{
  position: number;
  category: string;
}
export interface Accounts{
  position: number;
  b_account: string;
}

export interface Sponsors{
  position: number;
  sponsor: string;
}



@Injectable({
  providedIn: 'root'
})
export class InternalServicesService {


  tempSource: Accounts[] = [];
  tempSource2: Categories[] = [];
  tempSource3: Sponsors[] = [];

  t_sponsors: number = 1;
  t_categories: number = 1;
  t_accounts: number = 1;

  constructor() { }

   setCategories(newCategory:any){
    this.tempSource2.push({position: this.t_categories, category: newCategory});
  }

  getCategories(){
    return this.tempSource2
  }
}
