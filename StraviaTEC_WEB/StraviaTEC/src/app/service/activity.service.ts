import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Sport } from 'src/app/interface/sport';
import { Category } from 'src/app/interface/category';
import { Sponsor } from 'src/app/interface/sponsor';
import { AdminChallenge } from 'src/app/interface/admin-challenge';
import { AdminGroups } from 'src/app/interface/admin-groups';
import { AdminRace } from 'src/app/interface/admin-race';
import { AdminInscriptions } from 'src/app/interface/admin-inscriptions';
import { Activity } from 'src/app/interface/activity';
import { Groups } from 'src/app/interface/groups';
import { Races } from 'src/app/interface/races';
import { Challenges } from 'src/app/interface/challenges';
import { Mychallenges } from 'src/app/interface/mychallenges';
import { Mygroups } from 'src/app/interface/mygroups';
import { Inscription } from 'src/app/model/inscription';
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
   * @param race la informacion de la carrera
   */
  addRace(race: any): Observable<any> {
    race.username = localStorage.getItem('current_username');
    console.table(race);
    return this.httpclient.post(this.url + '/Race', race);
  }

  /** POST PARA REGISTRAR UN RETO
   *  Este post permite registrar un reto
   * @param race la informacion del reto
   */
  addChallenge(challenge: any): Observable<any> {
    challenge.username = localStorage.getItem('current_username');
    console.table(challenge);
    return this.httpclient.post(this.url + '/Challenge', challenge);
  }

  /** POST PARA REGISTRAR UN GRUPO
   *  Este post permite registrar un grupo.
   * @param activity la informacion del grupo
   */
  addGroup(group: any): Observable<any> {
    group.username = localStorage.getItem('current_username');
    console.table(group);
    return this.httpclient.post(this.url + '/Group', group);
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

  /** GET DE LISTA DE CHALLENGES DEL ADMIN
   * Este metodo permite traer todos los retos que pertenecen al administrador
   * @return la lista de los retos
   */
  getAdminChallenges(): Observable<AdminChallenge[]> {
    return this.httpclient.get<AdminChallenge[]>(
      this.url +
        '/Challenge/Organizer/' +
        localStorage.getItem('current_username')
    );
  }

  /** GET DE LISTA DE CHALLENGES DEL Usuario
   * Este metodo permite traer todos los retos que pertenecen al usuario
   * @return la lista de los retos
   */
  getUserChallenges(): Observable<Mychallenges[]> {
    return this.httpclient.get<Mychallenges[]>(
      this.url + '/Challenge/user/' + localStorage.getItem('current_username')
    );
  }

  /** GET DE LISTA DE CARERRAS DEL ADMIN
   * Este metodo permite traer todas las carreras que pertenecen al administrador
   * @return la lista de las carreras
   */
  getAdminRaces(): Observable<AdminRace[]> {
    return this.httpclient.get<AdminRace[]>(
      this.url + '/Race/Organizer/' + localStorage.getItem('current_username')
    );
  }

  /** GET DE LISTA DE GRUPOS EN LOS QUE ESTA EL USUARIO
   * Este metodo permite traer todas los grupos que pertenecen al usuario
   * @return la lista de los grupos
   */
  getMyGroups(): Observable<[]> {
    return this.httpclient.get<[]>(
      this.url + '/Group/User/' + localStorage.getItem('current_username')
    );
  }

  /** GET DE LISTA DE GRUPOS CREADOS POR EL ADMIN
   * Este metodo permite traer todas los grupos que pertenecen al administrador
   * @return la lista de las carreras
   */
  getAdminGroups(): Observable<AdminGroups[]> {
    return this.httpclient.get<AdminGroups[]>(
      this.url + '/Group/Organizer/' + localStorage.getItem('current_username')
    );
  }

  /** GET DE LISTA DE INSCRIPCIONES PENDIENTES
   * Este metodo permite traer todas las inscripciones pendientes de aceptacion
   * @return la lista de las carreras
   */
  getAdminInscriptions(): Observable<AdminInscriptions[]> {
    return this.httpclient.get<AdminInscriptions[]>(
      this.url +
        '/Inscription/Organizer/' +
        localStorage.getItem('current_username')
    );
  }

  /** GET DE LAS ACTIVIDADES DE LOS AMIGOS
   * Este metodo permite traer todas las actividades de los amigos del usuario
   * @return la lista actividades
   */
  getFriendsActivities(): Observable<Activity[]> {
    return this.httpclient.get<Activity[]>(
      this.url + '/User/Friends' + localStorage.getItem('current_username')
    );
  }

  /** GET DE LAS ACTIVIDADES DEL USUARIO
   * Este metodo permite traer todas las actividades del usuario
   * @return la lista actividades
   */
  getMyActivities(): Observable<Activity[]> {
    return this.httpclient.get<Activity[]>(
      this.url + '/Activity/' + localStorage.getItem('current_username')
    );
  }

  /** GET DE TODAS LAS CARRERAS DE LA APP
   * Este metodo permite traer todas las carreras de la app
   * @return la lista de carreras
   */
  getAllRaces(): Observable<Races[]> {
    return this.httpclient.get<Races[]>(this.url + '/Races/All');
  }

  /** GET DE TODOS LOS GRUPOS DE LA APP
   * Este metodo permite traer todas los grupos de la app
   * @return la lista de grupos
   */
  getAllGroups(): Observable<Groups[]> {
    return this.httpclient.get<Groups[]>(this.url + '/Group/All');
  }

  /** GET DE TODOS LOS RETOS DE LA APP
   * Este metodo permite traer todos los retos de la app
   * @return la lista de retos
   */
  getAllChallenges(): Observable<Challenges[]> {
    return this.httpclient.get<Challenges[]>(
      this.url +
        '/Challenge/user/all/' +
        localStorage.getItem('current_username')
    );
  }

  /** PUT PARA PODER ACTUALIZAR EL ESTADO DE INSCRIPCION
   * Este metodo permite aceptar la inscripcion de un usuario
   * @return info del numero de inscripcion
   */
  updateInscription(inumber: Inscription): Observable<any> {
    return this.httpclient.put(this.url + '/Inscription/', inumber);
  }
}
