import {
  Component,
  OnInit,
  AfterViewInit,
  Input,
  ElementRef,
  EventEmitter,
  Output,
} from '@angular/core';

import { NgbModal, ModalDismissReasons } from '@ng-bootstrap/ng-bootstrap';
import { ActivityService } from 'src/app/service/activity.service';
import { CredentialsService } from 'src/app/service/credentials.service';
import { Router } from '@angular/router';
import { Activity } from 'src/app/interface/activity';
import { LoginInterface } from 'src/app/interface/login-interface';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css'],
})
export class ProfileComponent implements OnInit {
  closeResult = '';
  profiledata: LoginInterface[] | undefined;
  activitydata: Activity[] | undefined;
  mapid: number = 0;

  profiledata1 = [
    {
      name: 'Ariana',
      lastname: 'Solano Rodriguez',
      birthdate: '12-06-1998',
      nationality: 'Canadian',
      age: '24',
      followers: 243,
      following: 87,
      activities: 155,
      image: 'https://m.media-amazon.com/images/I/31LtVzDD8AL._SL500_.jpg',
    },
  ];

  activitydata1 = [
    {
      name: 'Ariana',
      lastname: 'Solano',
      noactivity: '72347634',
      type: 'Cycling',
      time: '1:38 PM',
      date: '24-05-2022',
      duration: '76',
      distance: '85.39',
      altitude: '1.324',
      image: 'https://m.media-amazon.com/images/I/31LtVzDD8AL._SL500_.jpg',
      gpx: 17,
    },
  ];

  constructor(
    private modalService: NgbModal,
    private service: ActivityService,
    private service2: CredentialsService,
    private router: Router
  ) {}

  /**
   *  Este metodo permite hacer el display de un template en este caso el POP UP
   * @param content el template a mostrar
   */
  open(content: any, id: number) {
    this.mapid = id;
    this.modalService
      .open(content, { ariaLabelledBy: 'modal-basic-title' })
      .result.then(
        (result) => {
          this.closeResult = `Closed with: ${result}`;
        },
        (reason) => {
          this.closeResult = `Dismissed ${this.getDismissReason(reason)}`;
        }
      );
  }

  /**
   * Metodo que permite crear las acciones del boton exit del popup
   * @param reason
   * @returns
   */
  private getDismissReason(reason: any): string {
    if (reason === ModalDismissReasons.ESC) {
      return 'by pressing ESC';
    } else if (reason === ModalDismissReasons.BACKDROP_CLICK) {
      return 'by clicking on a backdrop';
    } else {
      return `with: ${reason}`;
    }
  }

  ngOnInit(): void {
    this.service
      .getMyActivities()
      .subscribe((activities) => (this.activitydata = activities));
    this.service2
      .getUserInfo()
      .subscribe((userInfo) => (this.profiledata = userInfo));
  }
}
