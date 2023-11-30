import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ConvertTemperatureFormComponent } from './convert-temperature-form.component';

describe('ConvertTemperatureFormComponent', () => {
  let component: ConvertTemperatureFormComponent;
  let fixture: ComponentFixture<ConvertTemperatureFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ConvertTemperatureFormComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ConvertTemperatureFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
