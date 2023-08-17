import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-FipeConsulta',
  templateUrl: './FipeConsulta.component.html',
  styleUrls: ['./FipeConsulta.component.scss']
})
export class FipeConsultaComponent implements OnInit {

  showPlaca: boolean = true;
  showResposta: boolean = false;

  constructor() { }

  ngOnInit() {
  }

  alterCampos(){
    this.showPlaca = !this.showPlaca;
  }

}
