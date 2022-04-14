import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TripCurrentComponent } from './trip-current.component';

describe('TripCurrentComponent', () => {
  let component: TripCurrentComponent;
  let fixture: ComponentFixture<TripCurrentComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TripCurrentComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TripCurrentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
