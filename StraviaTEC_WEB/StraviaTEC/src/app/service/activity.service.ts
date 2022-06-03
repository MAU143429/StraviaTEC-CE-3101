import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Sport } from 'src/app/interface/sport';
import { Category } from 'src/app/interface/category';
import { Sponsor } from 'src/app/interface/sponsor';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ActivityService {

  url = 'https://straviaapi.azurewebsites.net';

  constructor(private httpclient: HttpClient) { }


  /** POST PARA REGISTRAR ACTIVIDAD
   *  Este post permite registrar una actividad.
   * @param activity la informacion de la actividad
   */
   addActivity(activity: any): Observable<any> {
    activity.username =  localStorage.getItem('current_username');
    console.table(activity)
    return this.httpclient.post(this.url + '/Activity/User', activity);
  }

  /** GET DE TIPOS DE ACTIVIDAD
   * Este metodo permite traer los tipos de actividades admitidos
   * @return la lista de los deportes admitidos
   */
   getSports():Observable<Sport[]>{
    return this.httpclient.get<Sport[]>(this.url+'/Sport')
  }

  /** GET DE TIPOS DE CATEGORIA
 * Este metodo permite traer los tipos de categorias
 * @return la lista de las categorias
 */
    getCategories():Observable<Category[]>{
    return this.httpclient.get<Category[]>(this.url+'/Category')
  }

    /** GET DE LISTA DE PATROCINADORES
   * Este metodo permite traer todos los sponsors existentes
   * @return la lista de los sponsors existentes
   */
    getSponsors():Observable<Sponsor[]>{
    return this.httpclient.get<Sponsor[]>(this.url+'/Sponsor')
  }

}
