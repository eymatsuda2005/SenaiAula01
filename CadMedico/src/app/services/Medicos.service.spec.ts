/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { MedicosService } from './Medicos.service';

describe('Service: Medicos', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [MedicosService]
    });
  });

  it('should ...', inject([MedicosService], (service: MedicosService) => {
    expect(service).toBeTruthy();
  }));
});
