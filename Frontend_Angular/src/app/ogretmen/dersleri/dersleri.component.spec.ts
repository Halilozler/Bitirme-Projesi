import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DersleriComponent } from './dersleri.component';

describe('DersleriComponent', () => {
  let component: DersleriComponent;
  let fixture: ComponentFixture<DersleriComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DersleriComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DersleriComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
