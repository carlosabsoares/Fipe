import { Component, OnInit } from '@angular/core';
//import { FipeService } from '../services/fipe-services.service';

@Component({
  selector: 'app-FipeConsulta',
  templateUrl: './FipeConsulta.component.html',
  styleUrls: ['./FipeConsulta.component.scss']
})
export class FipeConsultaComponent implements OnInit {

  showPlaca: boolean = true;
  showResposta: boolean = false;

  // constructor(private fipeService: FipeService,) { }
  constructor() { }

  ngOnInit() {
  }

  alterCampos(){
    this.showPlaca = !this.showPlaca;
  }

}
