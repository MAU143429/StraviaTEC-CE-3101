import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AdminChallenge } from 'src/app/interface/admin-challenge';
import { AdminRace } from 'src/app/interface/admin-race';
import { AdminGroups } from 'src/app/interface/admin-groups';
import { ActivityService } from 'src/app/service/activity.service';

@Component({
  selector: 'app-admin-dashboard',
  templateUrl: './admin-dashboard.component.html',
  styleUrls: ['./admin-dashboard.component.css'],
})
export class AdminDashboardComponent implements OnInit {
  races: AdminRace[] | undefined;
  challenges: AdminChallenge[] | undefined;
  groups: AdminGroups[] | undefined;

  constructor(private service: ActivityService, private router: Router) {}

  ngOnInit(): void {
    this.service.getAdminRaces().subscribe((races) => (this.races = races));
    this.service
      .getAdminChallenges()
      .subscribe((challenges) => (this.challenges = challenges));
    this.service.getAdminGroups().subscribe((groups) => (this.groups = groups));
  }
}
