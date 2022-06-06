import { Component, OnInit } from '@angular/core';
import { Mygroups } from 'src/app/interface/mygroups';
import { Inscription } from 'src/app/model/inscription';
import { ActivityService } from 'src/app/service/activity.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-group',
  templateUrl: './group.component.html',
  styleUrls: ['./group.component.css'],
})
export class GroupComponent implements OnInit {
  mygroups: Mygroups[] | undefined;
  allgroups: Mygroups[] | undefined;
  newInscription: Inscription = new Inscription();

  constructor(private service: ActivityService, private router: Router) {}

  ngOnInit(): void {
    this.service
      .getMyGroups()
      .subscribe((mygroups) => (this.mygroups = mygroups));
  }

  /**
   * Metodo para traer todos los grupos
   *  */
  getAllGroups() {
    this.service
      .getAllGroups()
      .subscribe((allgroups) => (this.allgroups = allgroups));
  }

  /**
   * Metodo para unirse a un grupo
   *  */
  joinGroup(newgroupid: number) {
    this.newInscription.id = newgroupid;
    this.service.joinGroup(this.newInscription).subscribe((data) => {
      if (data) {
        this.router.navigate(['/groups']);
      }
    });
  }
}
