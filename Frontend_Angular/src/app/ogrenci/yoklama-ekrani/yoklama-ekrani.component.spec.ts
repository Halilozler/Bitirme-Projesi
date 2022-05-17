import { ComponentFixture, TestBed } from '@angular/core/testing';

import { YoklamaEkraniComponent } from './yoklama-ekrani.component';

describe('YoklamaEkraniComponent', () => {
  let component: YoklamaEkraniComponent;
  let fixture: ComponentFixture<YoklamaEkraniComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ YoklamaEkraniComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(YoklamaEkraniComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
