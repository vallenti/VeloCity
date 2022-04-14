import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TripStartComponent } from './trip-start.component';

describe('TripStartComponent', () => {
  let component: TripStartComponent;
  let fixture: ComponentFixture<TripStartComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TripStartComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TripStartComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
