import { ComponentFixture, TestBed } from '@angular/core/testing';

import { YoklamaPopupComponent } from './yoklama-popup.component';

describe('YoklamaPopupComponent', () => {
  let component: YoklamaPopupComponent;
  let fixture: ComponentFixture<YoklamaPopupComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ YoklamaPopupComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(YoklamaPopupComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
