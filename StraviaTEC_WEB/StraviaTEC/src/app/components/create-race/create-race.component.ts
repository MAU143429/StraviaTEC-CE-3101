import { Component, OnInit,ElementRef, ViewChild } from '@angular/core';
import {NgbModal, ModalDismissReasons} from '@ng-bootstrap/ng-bootstrap';
import { startWith, debounceTime, distinctUntilChanged, switchMap, map } from 'rxjs/operators';
import { Router } from '@angular/router';
import {FormControl,AbstractControl, FormBuilder, FormGroup} from '@angular/forms';
import { ActivityService } from 'src/app/service/activity.service';
import { InternalServicesService } from 'src/app/service/internal-services.service';
import { CreateRace } from 'src/app/model/create-race';

export interface Options{
  position: number;
  data: string;
}


@Component({
  selector: 'app-create-race',
  templateUrl: './create-race.component.html',
  styleUrls: ['./create-race.component.css']
})
export class CreateRaceComponent implements OnInit {

  public userForm:FormGroup;
  newRace: CreateRace = new CreateRace();
  displayedColumns: string[] = ['position', 'data'];

  dataSource: Options[] = [];
  dataSource2: Options[] = [];
  dataSource3: Options[] = [];

  t_sponsors: number = 1;
  t_categories: number = 1;
  t_accounts: number = 1;

  activityControl = new FormControl();
  categoriesControl = new FormControl();
  sponsorsControl = new FormControl();
  filteredOptions: any;
  filteredOptions2: any;
  filteredOptions3: any;
  activityoption: any;
  categoryoption: any;
  sponsoroption: any;
  accountoption:string = '';

  constructor(private fb: FormBuilder,private modalService: NgbModal, private service: ActivityService,private internal: InternalServicesService, private router: Router) {

    this.userForm = this.fb.group({
      b_account: ''
    });

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
    this.dataSource2.push({position: this.t_categories, data: newCategory});
    this.internal.setCategories(newCategory).subscribe( data => (this.dataSource2 = data));
  }

  addSponsor(newSponsor:any) {
    this.dataSource3.push({position: this.t_sponsors, data: newSponsor});
    this.internal.setSponsors(newSponsor).subscribe( data => (this.dataSource3 = data));
  }

  addAccount() {
    this.dataSource.push({position: this.t_accounts, data: this.userForm.get('first_name')?.value});
    this.internal.setAccounts(this.accountoption).subscribe( data => (this.dataSource = data));
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


  getCategories(){
    const categories = '';

    for ( var data in this.dataSource2){
      console.log(data)
    }

  }


    /**
   * Metodo para añadir una nueva carrera
   * @param newRace contiene la informacion de la nueva carrera
   *  */
   addNewRace(newRace: CreateRace) {
    newRace.bank_accounts = this.dataSource
    newRace.categories = this.dataSource2
    newRace.sponsors = this.dataSource3
    this.service.addRace(newRace).subscribe(
      (data) => {
        console.table(data)
        if (data) {
          this.router.navigate(['/create-race']);
        }
      }
    );
  }

}
