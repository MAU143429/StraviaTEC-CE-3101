import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-group',
  templateUrl: './group.component.html',
  styleUrls: ['./group.component.css']
})
export class GroupComponent implements OnInit {

  challenges = [{
    "c_name":"Reto Fuerta Fit",
    "no_challenge": "1254334",
    "activities":"6",
    "final_date":"12-06-2022",
  },]

  mychallenges = [{
    "c_name":"Reto Fuerta Fit",
    "no_challenge": "1254334",
    "activities":"6",
    "completed":"3",
    "avg":"50%",
    "final_date":"12-06-2022",
  },]

  constructor() { }

  ngOnInit(): void {
  }

}
  