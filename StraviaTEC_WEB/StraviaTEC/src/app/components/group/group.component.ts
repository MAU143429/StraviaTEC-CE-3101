import { Component, OnInit } from '@angular/core';
import { Mygroups } from 'src/app/interface/mygroups';
import { ActivityService } from 'src/app/service/activity.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-group',
  templateUrl: './group.component.html',
  styleUrls: ['./group.component.css'],
})
export class GroupComponent implements OnInit {
  mygroups: Mygroups[] | undefined;

  constructor(private service: ActivityService, private router: Router) {}

  ngOnInit(): void {
    this.service
      .getMyGroups()
      .subscribe((mygroups) => (this.mygroups = mygroups));
  }
}
