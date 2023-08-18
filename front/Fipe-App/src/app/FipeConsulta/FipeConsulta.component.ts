import { HttpClient } from '@angular/common/http';
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
  public fipe: any;

  // constructor(private fipeService: FipeService,) { }
  constructor(private http: HttpClient) { }

  ngOnInit() {
  }

  alterCampos(){
    this.showPlaca = !this.showPlaca;
  }

  getConsultaFipe(): void{
    this.http.post('https://localhost:5001/v1/InfoVeiculo/ConsultaFipeBrasilApi', null).subscribe(
      response => this.fipe = response,
      error =>  console.log(error)
    );


    this.showResposta = true;
  }

}
