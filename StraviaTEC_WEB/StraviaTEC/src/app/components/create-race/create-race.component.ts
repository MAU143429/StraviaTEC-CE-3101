import { Component, OnInit } from '@angular/core';

export interface Categories{
  position: number;
  category: string;
}
export interface Accounts{
  position: number;
  b_account: string;
}

export interface Sponsors{
  position: number;
  sponsor: string;
}
const CATEGORY_DATA: Categories[] = [
  {position: 1, category: 'Junior'},
  {position: 2, category: 'Sub-23'},
  {position: 3, category: 'Open'},
  {position: 4, category: 'Elite'},
  {position: 5, category: 'Master A'},
  {position: 6, category: 'Master B'},
  {position: 7, category: 'Master C'},
];

const BANK_DATA: Accounts[] = [
  {position: 1, b_account: '6737NUID93HDH378'},
  {position: 2, b_account: '128786DSHUKJ3B7J'},
  {position: 3, b_account: '32556JBFIFN8BN34'},
];

const SPONSOR_DATA: Sponsors[] = [
  {position: 1, sponsor: 'Powerade'},
  {position: 2, sponsor: 'NutriTEC'},
  {position: 3, sponsor: 'Vitalike'},
];



@Component({
  selector: 'app-create-race',
  templateUrl: './create-race.component.html',
  styleUrls: ['./create-race.component.css']
})
export class CreateRaceComponent implements OnInit {


  displayedColumns: string[] = ['position', 'b_account'];
  displayedColumns2: string[] = ['position', 'category'];
  displayedColumns3: string[] = ['position', 'sponsor'];
  dataSource = BANK_DATA;
  dataSource2 = CATEGORY_DATA;
  dataSource3 = SPONSOR_DATA;

  constructor() { }

  ngOnInit(): void {
  }

}
