import { Component, OnInit } from '@angular/core';
import { NgbModal, ModalDismissReasons } from '@ng-bootstrap/ng-bootstrap';
import {
  startWith,
  debounceTime,
  distinctUntilChanged,
  switchMap,
  map,
} from 'rxjs/operators';
import { Router } from '@angular/router';
import {
  FormControl,
  AbstractControl,
  FormBuilder,
  FormGroup,
} from '@angular/forms';
import { ActivityService } from 'src/app/service/activity.service';
import { InternalServicesService } from 'src/app/service/internal-services.service';
import { CreateChallenge } from 'src/app/model/create-challenge';
export interface Activities {
  position: number;
  type: string;
  distance: number;
  altitude: number;
}

@Component({
  selector: 'app-create-challenge',
  templateUrl: './create-challenge.component.html',
  styleUrls: ['./create-challenge.component.css'],
})
export class CreateChallengeComponent implements OnInit {
  public userForm: FormGroup;
  activityControl = new FormControl();
  displayedColumns: string[] = ['position', 'type', 'distance', 'altitude'];
  filteredOptions: any;
  dataSource: Activities[] = [];
  newChallenge: CreateChallenge = new CreateChallenge();
  t_activities: number = 1;

  constructor(
    private fb: FormBuilder,
    private modalService: NgbModal,
    private internal: InternalServicesService,
    private service: ActivityService,
    private router: Router
  ) {
    this.filteredOptions = this.activityControl.valueChanges.pipe(
      startWith(''),
      debounceTime(400),
      distinctUntilChanged(),
      switchMap((val) => {
        return this.filter(val || '');
      })
    );

    this.userForm = this.fb.group({
      type: '',
      distance: '',
      altitude: '',
    });
  }

  ngOnInit(): void {}

  addActivity() {
    this.dataSource.push({
      position: this.t_activities,
      type: this.userForm.get('type')?.value,
      distance: this.userForm.get('distance')?.value,
      altitude: this.userForm.get('altitude')?.value,
    });

    console.table(this.dataSource);
    this.internal
      .setActivities({
        position: this.t_activities,
        type: this.userForm.get('type')?.value,
        distance: this.userForm.get('distance')?.value,
        altitude: this.userForm.get('altitude')?.value,
      })
      .subscribe((data) => (this.dataSource = data));
  }

  /**
   * Este metodo nos permite realizar las recomendaciones de Actividades en base a lo escrito por parte usuario y lo que se consulta con el GET al API
   * @param val El valor ingresado en el input por el usuario
   * @returns Las recomendaciones que mas se acercan a lo escrito por el user
   */
  filter(val: string): any {
    console.log(this.service.getSports());
    return this.service.getSports().pipe(
      map((response) =>
        response.filter((option) => {
          return option.name.toLowerCase().indexOf(val.toLowerCase()) === 0;
        })
      )
    );
  }

  getActivies(): any {
    var activities = '';
    var cont = 0;
    while (cont < this.dataSource.length) {
      activities =
        activities +
        this.dataSource[cont].type +
        ';' +
        this.dataSource[cont].distance +
        ';' +
        this.dataSource[cont].altitude +
        '/';
      cont = cont + 1;
    }
    return activities;
  }

  /**
   * Metodo para añadir una nueva carrera
   * @param newRace contiene la informacion de la nueva carrera
   *  */
  addNewChallenge(newChallenge: CreateChallenge) {
    newChallenge.activities = this.getActivies();
    console.table(this.newChallenge.activities);
    this.service.addChallenge(newChallenge).subscribe((data) => {
      console.table(data);
      if (data) {
        this.router.navigate(['/create-challenge']);
      }
    });
  }
}
