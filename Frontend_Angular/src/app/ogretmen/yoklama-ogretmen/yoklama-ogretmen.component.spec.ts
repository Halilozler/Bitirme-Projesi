import { ComponentFixture, TestBed } from '@angular/core/testing';

import { YoklamaOgretmenComponent } from './yoklama-ogretmen.component';

describe('YoklamaOgretmenComponent', () => {
  let component: YoklamaOgretmenComponent;
  let fixture: ComponentFixture<YoklamaOgretmenComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ YoklamaOgretmenComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(YoklamaOgretmenComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
