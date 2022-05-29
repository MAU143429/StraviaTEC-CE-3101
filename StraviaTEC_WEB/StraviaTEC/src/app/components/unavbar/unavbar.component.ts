import { Component, OnInit } from '@angular/core';
import { SearchesService } from 'src/app/service/searches.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-unavbar',
  templateUrl: './unavbar.component.html',
  styleUrls: ['./unavbar.component.css']
})
export class UnavbarComponent implements OnInit {

  username:any

  constructor(private service:SearchesService, private router:Router) { }

  ngOnInit(): void {
  }

  /**
   * Este metodo permite crear un delay para esperar la respuesta del API
   * @param ms Cantidad de milisegundos que se desea parar la operacion para esperar la respuesta del API
   */
  async delay(ms: number) {
    await new Promise<void>(resolve => setTimeout(()=>resolve(), ms)).then(()=>console.log("fired"));
  }

  newUserSearch(){
    this.service.setUserSearchName(this.username);

    this.delay(500).then(()=>{
      this.router.navigate(['/search']);
    });


  }


}
