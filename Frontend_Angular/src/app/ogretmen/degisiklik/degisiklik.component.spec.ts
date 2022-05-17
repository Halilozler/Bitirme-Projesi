import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DegisiklikComponent } from './degisiklik.component';

describe('DegisiklikComponent', () => {
  let component: DegisiklikComponent;
  let fixture: ComponentFixture<DegisiklikComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DegisiklikComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DegisiklikComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
