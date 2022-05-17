import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GelecekDersComponent } from './gelecek-ders.component';

describe('GelecekDersComponent', () => {
  let component: GelecekDersComponent;
  let fixture: ComponentFixture<GelecekDersComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ GelecekDersComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(GelecekDersComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
