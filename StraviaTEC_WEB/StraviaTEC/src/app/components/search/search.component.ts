import { Component, OnInit } from '@angular/core';
import { AthleteResults } from 'src/app/interface/athlete-results';
import { SearchesService } from 'src/app/service/searches.service';
import { NewFollower } from 'src/app/model/new-follower';
import { Router } from '@angular/router';

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.css'],
})
export class SearchComponent implements OnInit {
  resultsdata: AthleteResults[] | undefined;
  newFollower: NewFollower = new NewFollower();
  searchName: any;

  results = [
    {
      username: 'mvagu',
      name: 'Melany',
      last_name: 'Vargas Gutierrez',
      image: 'https://m.media-amazon.com/images/I/31LtVzDD8AL._SL500_.jpg',
      activities: '65',
      followers: '283',
    },
  ];

  constructor(private service: SearchesService, private router: Router) {}

  /**
   * Este metodo permite crear un delay para esperar la respuesta del API
   * @param ms Cantidad de milisegundos que se desea parar la operacion para esperar la respuesta del API
   */
  async delay(ms: number) {
    await new Promise<void>((resolve) => setTimeout(() => resolve(), ms)).then(
      () => console.log('fired')
    );
  }

  ngOnInit(): void {
    this.delay(100).then(() => {
      this.searchName = this.service.getUserName();
      this.service.setUserSearchName('');
    });
  }

  /**
   * Metodo para seguir a un nuevo usuario
   *  */
  addFollower(userID: string) {
    this.newFollower.username = userID;
    this.service.addFollower(this.newFollower).subscribe((data) => {
      if (data) {
        this.router.navigate(['/dashboard']);
      }
    });
  }
}
