import { Component, OnInit } from '@angular/core';
import {NgbModal, ModalDismissReasons} from '@ng-bootstrap/ng-bootstrap';
import { startWith, debounceTime, distinctUntilChanged, switchMap, map } from 'rxjs/operators';
import { Router } from '@angular/router';
import {FormControl} from '@angular/forms';
import { ActivityService } from 'src/app/service/activity.service';

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

@Component({
  selector: 'app-create-race',
  templateUrl: './create-race.component.html',
  styleUrls: ['./create-race.component.css']
})
export class CreateRaceComponent implements OnInit {


  displayedColumns: string[] = ['position', 'b_account'];
  displayedColumns2: string[] = ['position', 'category'];
  displayedColumns3: string[] = ['position', 'sponsor'];


  dataSource: Accounts[] = [];
  dataSource2: Categories[] = [];
  dataSource3: Sponsors[] = [];

  t_sponsors: Number = 1;
  t_categories: Number = 1;
  t_accounts: Number = 1;

  activityControl = new FormControl();
  categoriesControl = new FormControl();
  sponsorsControl = new FormControl();
  filteredOptions: any;
  filteredOptions2: any;
  filteredOptions3: any;

  constructor(private modalService: NgbModal, private service: ActivityService, private router: Router) {
    this.filteredOptions = this.activityControl.valueChanges.pipe(
      startWith(''),
      debounceTime(400),
      distinctUntilChanged(),
      switchMap(val => {
            return this.filter(val || '')
       })
    )

    this.filteredOptions2 = this.categoriesControl.valueChanges.pipe(
      startWith(''),
      debounceTime(400),
      distinctUntilChanged(),
      switchMap(val => {
            return this.filter2(val || '')
       })
    )

    this.filteredOptions3 = this.sponsorsControl.valueChanges.pipe(
      startWith(''),
      debounceTime(400),
      distinctUntilChanged(),
      switchMap(val => {
            return this.filter3(val || '')
       })
    )

   }

  ngOnInit(): void {
  }

  addCategory(newCategory:any) {

    this.dataSource2.push({position: this.t_categories.valueOf(), category: newCategory})
    this.t_categories =+ 1;
  }






    /**
  * Este metodo nos permite realizar las recomendaciones de Actividades en base a lo escrito por parte usuario y lo que se consulta con el GET al API
  * @param val El valor ingresado en el input por el usuario
  * @returns Las recomendaciones que mas se acercan a lo escrito por el user
  */
     filter(val: string): any {
    return this.service.getSports()
      .pipe(
        map(response => response.filter(option => {
          return option.name.toLowerCase().indexOf(val.toLowerCase()) === 0
        }))
      )
    }

      /**
  * Este metodo nos permite realizar las recomendaciones de categorias en base a lo escrito por parte usuario y lo que se consulta con el GET al API
  * @param val El valor ingresado en el input por el usuario
  * @returns Las recomendaciones que mas se acercan a lo escrito por el user
  */
   filter2(val: string): any {
  return this.service.getCategories()
    .pipe(
      map(response => response.filter(option => {
        return option.name.toLowerCase().indexOf(val.toLowerCase()) === 0
      }))
    )
  }

    /**
  * Este metodo nos permite realizar las recomendaciones de Sponsors en base a lo escrito por parte usuario y lo que se consulta con el GET al API
  * @param val El valor ingresado en el input por el usuario
  * @returns Las recomendaciones que mas se acercan a lo escrito por el user
  */
     filter3(val: string): any {
    return this.service.getSponsors()
      .pipe(
        map(response => response.filter(option => {
          return option.tradename.toLowerCase().indexOf(val.toLowerCase()) === 0
        }))
      )
    }

}
