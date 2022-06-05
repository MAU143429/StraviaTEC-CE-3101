import { Component, OnInit } from '@angular/core';
import {NgbModal, ModalDismissReasons} from '@ng-bootstrap/ng-bootstrap';
import { startWith, debounceTime, distinctUntilChanged, switchMap, map } from 'rxjs/operators';
import { Router } from '@angular/router';
import {FormControl} from '@angular/forms';
import { ActivityService } from 'src/app/service/activity.service';
import { InternalServicesService } from 'src/app/service/internal-services.service';

export interface Activities{
  position: number;
  type: string;
  distance: string;
}


@Component({
  selector: 'app-create-challenge',
  templateUrl: './create-challenge.component.html',
  styleUrls: ['./create-challenge.component.css']
})
export class CreateChallengeComponent implements OnInit {

  activityControl = new FormControl();
  displayedColumns: string[] = ['position', 'type','distance'];
  filteredOptions: any;
  dataSource: Activities[] = [];
  t_activities: number = 1;

  constructor(private modalService: NgbModal,private internal: ActivityService, private service: ActivityService, private router: Router) {
    this.filteredOptions = this.activityControl.valueChanges.pipe(
      startWith(''),
      debounceTime(400),
      distinctUntilChanged(),
      switchMap(val => {
            return this.filter(val || '')
       })
    )
   }
  ngOnInit(): void {
  }

  addActivity(newActivity:Activities) {
    this.dataSource.push({position: this.t_activities, type: newActivity.type, distance: newActivity.distance});
    this.internal.addActivity(newActivity).subscribe( data => (this.dataSource = data));
  }

  /**
  * Este metodo nos permite realizar las recomendaciones de Actividades en base a lo escrito por parte usuario y lo que se consulta con el GET al API
  * @param val El valor ingresado en el input por el usuario
  * @returns Las recomendaciones que mas se acercan a lo escrito por el user
  */
   filter(val: string): any {
    console.log(this.service.getSports())
  return this.service.getSports()
    .pipe(
      map(response => response.filter(option => {
        return option.name.toLowerCase().indexOf(val.toLowerCase()) === 0
      }))
    )
  }

}
