import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {

  profiledata = [{
    "name":"Ariana",
    "last_name": "Solano Rodriguez",
    "birthdate":"12-06-1998",
    "nationality":"Canadian", 
    "age":"24",
    "followers": "243",
    "following":"87",
    "activities":"155",
    "image":"https://m.media-amazon.com/images/I/31LtVzDD8AL._SL500_.jpg",

  },]

  activitydata = [{
    "name" : "Ariana Solano",
    "no_activity":"72347634",
    "type": "Cycling",
    "time":"1:38 PM",
    "date":"24-05-2022",
    "duration":"54:00",
    "distance": "54 Km",
    "gpx":"src/assets/gpx/1.gpx",
  },]

  constructor() { }

  ngOnInit(): void {


  }

}
