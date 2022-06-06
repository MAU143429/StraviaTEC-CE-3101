import { Component, OnInit } from '@angular/core';
import { Challenges } from 'src/app/interface/challenges';
import { Mychallenges } from 'src/app/interface/mychallenges';
import { ActivityService } from 'src/app/service/activity.service';
import { SearchesService } from 'src/app/service/searches.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-challenges',
  templateUrl: './challenges.component.html',
  styleUrls: ['./challenges.component.css'],
})
export class ChallengesComponent implements OnInit {
  mychallenges: Mychallenges[] | undefined;
  challenges: Challenges[] | undefined;

  constructor(
    private service: ActivityService,
    private service2: ActivityService,
    private router: Router
  ) {}

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
}
