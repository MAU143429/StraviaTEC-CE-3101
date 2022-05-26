import { Component, OnInit } from '@angular/core';
import { Challenges } from 'src/app/interface/challenges';
import { Mychallenges } from 'src/app/interface/mychallenges';

@Component({
  selector: 'app-challenges',
  templateUrl: './challenges.component.html',
  styleUrls: ['./challenges.component.css']
})
export class ChallengesComponent implements OnInit {

  mychallenges:Mychallenges[]| undefined;
  challenges: Challenges[]| undefined;

  constructor() { }

  ngOnInit(): void {
  }

}
 