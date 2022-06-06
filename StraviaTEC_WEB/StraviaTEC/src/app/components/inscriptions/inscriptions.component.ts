import { Component, OnInit } from '@angular/core';
import { ActivityService } from 'src/app/service/activity.service';
import { CreateGroup } from 'src/app/model/create-group';
import { AdminInscriptions } from 'src/app/interface/admin-inscriptions';
import { NgbModal, ModalDismissReasons } from '@ng-bootstrap/ng-bootstrap';
import { Inscription } from 'src/app/model/inscription';
import { Router } from '@angular/router';
@Component({
  selector: 'app-inscriptions',
  templateUrl: './inscriptions.component.html',
  styleUrls: ['./inscriptions.component.css'],
})
export class InscriptionsComponent implements OnInit {
  closeResult = '';
  newGroup: CreateGroup = new CreateGroup();
  newInscription: Inscription = new Inscription();
  inscriptions: AdminInscriptions[] | undefined;
  voucher: string = '';

  constructor(
    private service: ActivityService,
    private router: Router,
    private modalService: NgbModal
  ) {}

  /**
   *  Este metodo permite hacer el display de un template en este caso el POP UP
   * @param content el template a mostrar
   */
  open(content: any, voucherlink: string) {
    this.voucher = voucherlink;
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
      .getAdminInscriptions()
      .subscribe((inscriptions) => (this.inscriptions = inscriptions));
  }

  /**
   * Metodo para añadir un nuevo grupo
   * @param newGroup contiene la informacion del grupo
   *  */
  addGroup(newGroup: CreateGroup) {
    this.service.addGroup(newGroup).subscribe((data) => {
      if (data) {
        this.router.navigate(['/incriptions']);
      }
    });
  }

  /**
   * Metodo para añadir un nuevo grupo
   * @param newGroup contiene la informacion del grupo
   *  */
  updateInscription(inumber: number) {
    this.newInscription.id = inumber;
    this.service.updateInscription(this.newInscription).subscribe((data) => {
      if (data) {
        this.router.navigate(['/incriptions']);
      }
    });
  }
}
