import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Sport } from 'src/app/interface/sport';
import { Category } from 'src/app/interface/category';
import { Sponsor } from 'src/app/interface/sponsor';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class ActivityService {
  url = 'https://straviaapi.azurewebsites.net';

  constructor(private httpclient: HttpClient) {}

  /** POST PARA REGISTRAR ACTIVIDAD
   *  Este post permite registrar una actividad.
   * @param activity la informacion de la actividad
   */
  addActivity(activity: any): Observable<any> {
    activity.username = localStorage.getItem('current_username');
    console.table(activity);
    return this.httpclient.post(this.url + '/Activity/User', activity);
  }

  /** POST PARA REGISTRAR GPX
   *  Este post permite registrar un gpx.
   * @param file el archivo gpx
   */
  addGPX(file: FormData): Observable<number> {
    return this.httpclient.post<number>(this.url + '/File', file, {
      headers: { ContentType: 'multipart/form-data' },
    });
  }

  /** GET DE GPX
   * Este metodo permite traer los gpx
   * @return la lista de los deportes admitidos
   */
  getGPX(id: number) {
    return this.httpclient.get(this.url + '/File/' + id);
  }

  /** POST PARA REGISTRAR UNA CARRERA
   *  Este post permite registrar una carrera.
   * @param activity la informacion de la carrera
   */
  addRace(race: any): Observable<any> {
    race.username = localStorage.getItem('current_username');
    console.table(race);
    return this.httpclient.post(this.url + '/Race', race);
  }

  /** GET DE TIPOS DE ACTIVIDAD
   * Este metodo permite traer los tipos de actividades admitidos
   * @return la lista de los deportes admitidos
   */
  getSports(): Observable<Sport[]> {
    return this.httpclient.get<Sport[]>(this.url + '/Sport');
  }

  /** GET DE TIPOS DE CATEGORIA
   * Este metodo permite traer los tipos de categorias
   * @return la lista de las categorias
   */
  getCategories(): Observable<Category[]> {
    return this.httpclient.get<Category[]>(this.url + '/Category');
  }

  /** GET DE LISTA DE PATROCINADORES
   * Este metodo permite traer todos los sponsors existentes
   * @return la lista de los sponsors existentes
   */
  getSponsors(): Observable<Sponsor[]> {
    return this.httpclient.get<Sponsor[]>(this.url + '/Sponsor');
  }
}
