import { Component, OnInit } from '@angular/core';
import { CredentialsService } from 'src/app/service/credentials.service';
import { Register } from 'src/app/model/register';
import { Router } from '@angular/router';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  newRegister:Register = new Register

  constructor(private service:CredentialsService, private router:Router) { }

  ngOnInit(): void {
  }

  addNewRegister(newRegister:Register){
    this.service.addRegister(newRegister).subscribe(register=> console.log(register));
  }

}
