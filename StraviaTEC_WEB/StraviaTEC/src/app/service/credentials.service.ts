import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { LoginInterface } from '../interface/login-interface';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class CredentialsService {
  url = 'https://straviaapi.azurewebsites.net';

  constructor(private httpclient: HttpClient) {}

  /** POST PARA CREAR USUARIO
   *  Este post permite enviar la informacion para crear un usuario.
   * @param ingresa la informacion del deportista a registrar
   */
  addRegister(register: any): Observable<any> {
    console.log(register);
    return this.httpclient.post(this.url + '/User', register);
  }

  /**
   * Este metodo nos permite enviar las credenciales del usuario para que sean verificadas
   * y se permita el inicio de sesion.
   * @param login informacion con el username y contrasena para que estas sean verificadas
   * @returns un boolean con el resultado True = credenciales validas - False = credenciales invalidas
   */
  getLoginUser(login: {
    username: string;
    password: string;
  }): Observable<LoginInterface> {
    console.log(login);
    return this.httpclient.post<LoginInterface>(
      `${this.url}/user/login`,
      login
    );
  }

  /**
   * Este metodo nos permite enviar las credenciales del administrador para que sean verificadas
   * y se permita el inicio de sesion.
   * @param login info con las credenciales del admin
   * @returns un boolean con el resultado True = credenciales validas - False = credenciales invalidas
   */
  getLoginAdmin(login: {
    username: string;
    password: string;
  }): Observable<LoginInterface> {
    console.log(login);
    return this.httpclient.post<LoginInterface>(
      `${this.url}/organizer/login`,
      login
    );
  }

}
