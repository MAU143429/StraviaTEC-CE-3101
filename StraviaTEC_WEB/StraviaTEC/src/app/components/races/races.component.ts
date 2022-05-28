import { Component, OnInit } from '@angular/core';
import { Myraces } from 'src/app/interface/myraces';
import { Races } from 'src/app/interface/races';

@Component({
  selector: 'app-races',
  templateUrl: './races.component.html',
  styleUrls: ['./races.component.css']
})
export class RacesComponent implements OnInit {

  myraces:Myraces[]| undefined;
  racesdata: Races[]| undefined;

  races = [{
    "r_name" :"Reto Powerade",
    "no_race" : "543478",
    "type" : "Running",
    "a_date" : "string",
    "price" : "10000",
    "route": "maphere",
    "bank_account": "873872467"
  },]

  constructor() { }

  ngOnInit(): void {
  }

}
