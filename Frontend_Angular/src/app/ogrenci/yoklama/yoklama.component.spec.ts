import { ComponentFixture, TestBed } from '@angular/core/testing';

import { YoklamaComponent } from './yoklama.component';

describe('YoklamaComponent', () => {
  let component: YoklamaComponent;
  let fixture: ComponentFixture<YoklamaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ YoklamaComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(YoklamaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
