import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SearchesService {

  private userSearchName:any;

  url = 'https://straviaapi.azurewebsites.net'

  constructor(private httpclient:HttpClient) { }

   newSearch(search:any):Observable<any>{
    return this.httpclient.post(this.url+'ENDPOINT AQUI!', search)                                                                            // AGREGAR EL ENDPOINT CORRECTAMENTE
  }

  setUserSearchName(newName:any) {
    this.userSearchName = newName

  }
  getUserName(): Observable<any>{
    return this.userSearchName;
  }

}
