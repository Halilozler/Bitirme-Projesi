import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AOgrenciComponent } from './a-ogrenci.component';

describe('AOgrenciComponent', () => {
  let component: AOgrenciComponent;
  let fixture: ComponentFixture<AOgrenciComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AOgrenciComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AOgrenciComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
