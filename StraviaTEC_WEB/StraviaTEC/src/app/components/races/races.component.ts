import { Component, OnInit } from '@angular/core';
import { ActivityService } from 'src/app/service/activity.service';
import { NgbModal, ModalDismissReasons } from '@ng-bootstrap/ng-bootstrap';
import { Myraces } from 'src/app/interface/myraces';
import { BAccounts } from 'src/app/interface/b-accounts';
import { Races } from 'src/app/interface/races';
import { Inscription } from 'src/app/model/inscription';
import { Router } from '@angular/router';

@Component({
  selector: 'app-races',
  templateUrl: './races.component.html',
  styleUrls: ['./races.component.css'],
})
export class RacesComponent implements OnInit {
  closeResult = '';
  mapid: number = 0;
  raceid: number = 0;
  myraces: Myraces[] | undefined;
  pendingraces: Myraces[] | undefined;
  accounts: BAccounts[] | undefined;
  races: Races[] | undefined;
  newInscription: Inscription = new Inscription();

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
    this.raceid = id;
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
    this.mapid = id;
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
    this.service
      .getRegisteredRaces()
      .subscribe((races) => (this.myraces = races));

    this.service
      .getPendingRaces()
      .subscribe((races) => (this.pendingraces = races));
  }

  /**
   * Metodo para traer todos las carreras
   *  */
  getAllRaces() {
    this.service.getAllRaces().subscribe((allraces) => (this.races = allraces));
  }

  /**
   * Metodo para traer las cuentas de banco asociadas a una carrera
   *  */
  getBA(raceid: number) {
    this.service.getRacesBA(raceid).subscribe((ba) => (this.accounts = ba));
  }

  /**
   * Metodo para traer las cuentas de banco asociadas a una carrera
   *  */
  addInscription(raceid: number) {
    this.newInscription.id = raceid;
    this.service.addInscription(this.newInscription).subscribe((data) => {
      if (data) {
        this.router.navigate(['/races']);
      }
    });
  }
}
