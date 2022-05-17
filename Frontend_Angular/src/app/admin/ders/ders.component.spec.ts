import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DersComponent } from './ders.component';

describe('DersComponent', () => {
  let component: DersComponent;
  let fixture: ComponentFixture<DersComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DersComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DersComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
