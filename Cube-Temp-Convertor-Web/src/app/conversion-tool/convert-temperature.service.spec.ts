import { TestBed } from '@angular/core/testing';

import { ConvertTemperatureService } from './convert-temperature.service';

describe('ConvertTemperatureService', () => {
  let service: ConvertTemperatureService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ConvertTemperatureService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
