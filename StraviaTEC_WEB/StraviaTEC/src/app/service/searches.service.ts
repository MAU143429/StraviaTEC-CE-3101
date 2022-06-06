import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { NewFollower } from 'src/app/model/new-follower';

@Injectable({
  providedIn: 'root',
})
export class SearchesService {
  private userSearchName: any;

  url = 'https://straviaapi.azurewebsites.net';

  constructor(private httpclient: HttpClient) {}

  newSearch(search: any): Observable<any> {
    return this.httpclient.post(this.url + 'ENDPOINT AQUI!', search); // AGREGAR EL ENDPOINT CORRECTAMENTE
  }

  setUserSearchName(newName: any) {
    this.userSearchName = newName;
  }
  getUserName(): Observable<any> {
    return this.userSearchName;
  }

  /**----------------------------------------------------------------------------------------------------- */
  /** POST PARA PODER AGREGAR UN SEGUIDOR
   * Este metodo permite unirse a un seguidor
   * @return info del numero del seguidor
   */
  addFollower(newFollower: NewFollower): Observable<any> {
    return this.httpclient.post(
      this.url + '/Inscription/' + localStorage.getItem('current_username'),
      newFollower
    );
  }

  /**----------------------------------------------------------------------------------------------------- */
}
