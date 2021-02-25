/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { CidadesService } from './Cidades.service';

describe('Service: Cidades', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [CidadesService]
    });
  });

  it('should ...', inject([CidadesService], (service: CidadesService) => {
    expect(service).toBeTruthy();
  }));
});
