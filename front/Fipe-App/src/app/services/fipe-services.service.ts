import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({providedIn: 'root'})
export class FipeServicesService {

constructor(private http: HttpClient) { }

  baseURL: string = "https://localhost:5001/v1/InfoVeiculo";

  getEventos(){
    return this.http.get(this.baseURL);
  }

}
