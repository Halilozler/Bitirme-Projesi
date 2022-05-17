import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AOgretmenComponent } from './a-ogretmen.component';

describe('AOgretmenComponent', () => {
  let component: AOgretmenComponent;
  let fixture: ComponentFixture<AOgretmenComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AOgretmenComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AOgretmenComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
