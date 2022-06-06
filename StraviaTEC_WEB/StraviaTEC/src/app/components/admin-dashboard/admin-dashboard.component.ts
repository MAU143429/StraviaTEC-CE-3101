import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AdminChallenge } from 'src/app/interface/admin-challenge';
import { AdminRace } from 'src/app/interface/admin-race';
import { AdminGroups } from 'src/app/interface/admin-groups';
import { ActivityService } from 'src/app/service/activity.service';
import { Activities } from 'src/app/interface/activities';
import { NgbModal, ModalDismissReasons } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-admin-dashboard',
  templateUrl: './admin-dashboard.component.html',
  styleUrls: ['./admin-dashboard.component.css'],
})
export class AdminDashboardComponent implements OnInit {
  closeResult = '';
  races: AdminRace[] | undefined;
  challenges: AdminChallenge[] | undefined;
  activities: Activities[] | undefined;
  groups: AdminGroups[] | undefined;
  mapid: number = 0;
  challengeid: number = 0;

  constructor(
    private modalService: NgbModal,
    private service: ActivityService,
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
   *  Este metodo permite hacer el display de un template en este caso el POP UP
   * @param content2 el template a mostrar
   */
  open2(content2: any, id: number) {
    this.challengeid = id;
    this.service
      .getChallengesActivities(this.challengeid)
      .subscribe((cactivity) => (this.activities = cactivity));
    this.modalService
      .open(content2, { ariaLabelledBy: 'modal-basic-title' })
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
    this.service.getAdminRaces().subscribe((races) => (this.races = races));
    this.service
      .getAdminChallenges()
      .subscribe((challenges) => (this.challenges = challenges));
    this.service.getAdminGroups().subscribe((groups) => (this.groups = groups));
  }
}
