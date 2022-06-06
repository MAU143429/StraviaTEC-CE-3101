import { Component, OnInit } from '@angular/core';
import { Challenges } from 'src/app/interface/challenges';
import { Mychallenges } from 'src/app/interface/mychallenges';
import { Activities } from 'src/app/interface/activities';
import { ActivityService } from 'src/app/service/activity.service';
import { Inscription } from 'src/app/model/inscription';
import { SearchesService } from 'src/app/service/searches.service';
import { NgbModal, ModalDismissReasons } from '@ng-bootstrap/ng-bootstrap';
import { Router } from '@angular/router';

@Component({
  selector: 'app-challenges',
  templateUrl: './challenges.component.html',
  styleUrls: ['./challenges.component.css'],
})
export class ChallengesComponent implements OnInit {
  closeResult = '';
  activities: Activities[] | undefined;
  mychallenges: Mychallenges[] | undefined;
  challenges: Challenges[] | undefined;
  challengeid: number = 0;
  newInscription: Inscription = new Inscription();

  constructor(
    private modalService: NgbModal,
    private service: ActivityService,
    private service2: ActivityService,
    private router: Router
  ) {}

  /**
   *  Este metodo permite hacer el display de un template en este caso el POP UP
   * @param content2 el template a mostrar
   */
  open(content: any, id: number) {
    this.challengeid = id;
    this.service
      .getChallengesActivities(this.challengeid)
      .subscribe((cactivity) => (this.activities = cactivity));
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
      .getUserChallenges()
      .subscribe((challenges) => (this.mychallenges = challenges));
  }

  /**
   * Metodo para traer todos los retos
   *  */
  getAllChallenges() {
    this.service
      .getAllChallenges()
      .subscribe((allchallenges) => (this.challenges = allchallenges));
  }

  /**
   * Metodo para unirse a un reto
   *  */
  joinChallenge(newChallengeID: number) {
    this.newInscription.id = newChallengeID;
    this.service.joinChallenge(this.newInscription).subscribe((data) => {
      if (data) {
        this.router.navigate(['/groups']);
      }
    });
  }
}
