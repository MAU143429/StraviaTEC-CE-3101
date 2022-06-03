import { Component, OnInit } from '@angular/core';
import {NgbModal, ModalDismissReasons} from '@ng-bootstrap/ng-bootstrap';
import { startWith, debounceTime, distinctUntilChanged, switchMap, map } from 'rxjs/operators';
import { Router } from '@angular/router';
import {FormControl} from '@angular/forms';
import { Training } from 'src/app/model/training';
import { ActivityService } from 'src/app/service/activity.service';

@Component({
  selector: 'app-training',
  templateUrl: './training.component.html',
  styleUrls: ['./training.component.css']
})
export class TrainingComponent implements OnInit {

  newTraining: Training = new Training();
  activityControl = new FormControl();
  filteredOptions: any;


  constructor(private modalService: NgbModal, private service: ActivityService, private router: Router) {
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


  /**
   * Metodo para añadir una nueva entrenamiento
   * @param newTraining contiene la informacion del nuevo entrenamiento
   *  */
   addNewTraining(newTraining: Training) {
    this.service.addActivity(newTraining).subscribe(
      (data) => {
        console.table(data)
        if (data) {
          this.router.navigate(['/training']);
        }
      }
    );
  }


}
