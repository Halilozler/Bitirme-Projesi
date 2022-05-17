import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DersSaatEkleComponent } from './ders-saat-ekle.component';

describe('DersSaatEkleComponent', () => {
  let component: DersSaatEkleComponent;
  let fixture: ComponentFixture<DersSaatEkleComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DersSaatEkleComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DersSaatEkleComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
