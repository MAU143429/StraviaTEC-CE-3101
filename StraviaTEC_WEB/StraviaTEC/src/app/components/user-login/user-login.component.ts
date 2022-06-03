import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Login } from 'src/app/model/login';
import { LoginInterface } from 'src/app/interface/login-interface';
import { CredentialsService } from 'src/app/service/credentials.service';

@Component({
  selector: 'app-user-login',
  templateUrl: './user-login.component.html',
  styleUrls: ['./user-login.component.css'],
})
export class UserLoginComponent implements OnInit {
  newLogin: Login = new Login();


  constructor(private service: CredentialsService, private router: Router) {}

  ngOnInit(): void {}

  /**
   * Este metodo permite crear un delay para esperar la respuesta del API
   * @param ms Cantidad de milisegundos que se desea parar la operacion para esperar la respuesta del API
   */
  async delay(ms: number) {
    await new Promise<void>((resolve) => setTimeout(() => resolve(), ms)).then(
      () => console.log('fired')
    );
  }

  /**
   * Metodo para consultar un nuevo inicio de sesion en web
   * @param newLogin Este parametro lleva las credenciales que se desean verificar
   *  */
  addNewLogin(newLogin: Login) {
    this.service.getLoginUser(newLogin).subscribe(
      (data) => {
        console.table(data)
        if (data) {
          localStorage.clear();
          localStorage.setItem("current_username" ,data.username)
          this.router.navigate(['/dashboard']);
        }
      }
    );
  }
}
