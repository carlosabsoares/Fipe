import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import type { Vehicle } from '../models/InfoVeiculo';
import { Observable } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class FipeService {
  constructor(private http: HttpClient) {}

  baseURL: string = 'https://localhost:5001';

  getVehicle() {
    return this.http.get(this.baseURL);
  }

  getByLicensePlate(licensePlate: string) {
    return this.http.get<Vehicle>(
      `${this.baseURL}/v1/InfoVeiculo/ConsultaPlaca?Placa=${licensePlate}`
    );
  }

  get(year: number, fipeCode: number) {
    return this.http.post<Vehicle>(
      `${this.baseURL}/v1/InfoVeiculo/ConsultaFipeBrasilApi`,
      {
        anoModelo: year,
        codigoFipe: fipeCode,
      }
    );
  }

  saveVehicle(vehicle: Vehicle) {
    return this.http.post(`${this.baseURL}/v1/InfoVeiculo`, vehicle);
  }

  attachLicensePlate(fipeCode: string, year: number, licensePlate: string) {
    return this.http.post(`${this.baseURL}/v1/InfoVeiculo/CadastraPlaca`, {
      codigoFipe: fipeCode,
      anoModelo: year,
      placa: licensePlate,
    });
  }
}
