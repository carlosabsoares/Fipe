import {
  AbstractControl,
  FormBuilder,
  FormControl,
  FormGroup,
} from '@angular/forms';
import { Component, OnInit, inject } from '@angular/core';
import { FipeService } from '../services/fipe.service';
import { Vehicle } from '../models/InfoVeiculo';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-FipeConsulta',
  templateUrl: './FipeConsulta.component.html',
  styleUrls: ['./FipeConsulta.component.scss'],
})
export class FipeConsultaComponent implements OnInit {
  form: FormGroup = new FormGroup({
    fipeCode: new FormControl(''),
    year: new FormControl(''),
    licensePlate: new FormControl(''),
  });
  searchType = 'fipe';
  submitted = false;
  newLicensePlate = '';
  searchResponse: Vehicle | null = null;

  private fipeService = inject(FipeService);

  constructor(private toastr: ToastrService,
              private formBuilder: FormBuilder) {}

  ngOnInit() {
    this.form = this.formBuilder.group({
      fipeCode: [''],
      year: [''],
      licensePlate: [''],
    });
  }

  get f(): { [key: string]: AbstractControl } {
    return this.form.controls;
  }

  setSearchType(searchType: string) {
    this.searchType = searchType;
    this.clearFields();
  }

  clearFields() {
    this.searchResponse = null;
    this.form.get('fipeCode')?.reset();
    this.form.get('year')?.reset();
    this.form.get('licensePlate')?.reset();
    this.newLicensePlate = '';
  }

  onSubmit() {
    console.log('onSubmit', this.form.value);
    const formValue = this.form.value;
    if (this.searchType === 'fipe') {
      this.fipeService
        .get(formValue.year, parseInt(formValue.fipeCode, 10))
        .subscribe((response) => {
          this.searchResponse = response;
        });
    } else {
      this.fipeService
        .getByLicensePlate(formValue.licensePlate)
        .subscribe((response) => {
          this.searchResponse = response;
        });
    }
  }

  attachVehiclePlate() {
    console.log('attachVehiclePlate', {
      searchResponse: this.searchResponse,
      newLicensePlate: this.newLicensePlate,
    });
    if (!this.searchResponse) return;

    const { anoModelo, codigoFipe } = this.searchResponse;
    this.fipeService
      .attachLicensePlate(this.form.value.fipeCode, anoModelo, this.newLicensePlate)
      .subscribe({
        next: (response) => {
          this.toastr.success('Informação', 'Cadastrado com sucesso.');
          this.clearFields();
        },
        error: (error) => {
          this.toastr.error('Informação', 'Erro ao cadastrar');
          this.clearFields();
        },
      });
  }
}
