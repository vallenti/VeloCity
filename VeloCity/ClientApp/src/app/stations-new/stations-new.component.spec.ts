import { ComponentFixture, TestBed } from '@angular/core/testing';

import { StationsNewComponent } from './stations-new.component';

describe('StationsNewComponent', () => {
  let component: StationsNewComponent;
  let fixture: ComponentFixture<StationsNewComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ StationsNewComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(StationsNewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
