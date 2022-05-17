import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EkleDersComponent } from './ekle-ders.component';

describe('EkleDersComponent', () => {
  let component: EkleDersComponent;
  let fixture: ComponentFixture<EkleDersComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EkleDersComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(EkleDersComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
