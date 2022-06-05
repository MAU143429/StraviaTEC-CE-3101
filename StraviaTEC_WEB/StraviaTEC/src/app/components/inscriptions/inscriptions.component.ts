import { Component, OnInit } from '@angular/core';
import { ActivityService } from 'src/app/service/activity.service';
import { CreateGroup } from 'src/app/model/create-group';
import { Router } from '@angular/router';
@Component({
  selector: 'app-inscriptions',
  templateUrl: './inscriptions.component.html',
  styleUrls: ['./inscriptions.component.css'],
})
export class InscriptionsComponent implements OnInit {
  newGroup: CreateGroup = new CreateGroup();
  races: any[] | undefined;
  challenges: any[] | undefined;

  constructor(private service: ActivityService, private router: Router) {}

  ngOnInit(): void {}

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
}
