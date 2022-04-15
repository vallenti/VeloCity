import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BikesNewComponent } from './bikes-new.component';

describe('BikesNewComponent', () => {
  let component: BikesNewComponent;
  let fixture: ComponentFixture<BikesNewComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ BikesNewComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(BikesNewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
