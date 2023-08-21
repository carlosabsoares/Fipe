/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { FipeServicesService } from './fipe.service';

describe('Service: FipeServices', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [FipeServicesService]
    });
  });

  it('should ...', inject([FipeServicesService], (service: FipeServicesService) => {
    expect(service).toBeTruthy();
  }));
});
