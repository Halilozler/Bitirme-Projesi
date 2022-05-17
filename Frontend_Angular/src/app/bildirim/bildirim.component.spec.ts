import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BildirimComponent } from './bildirim.component';

describe('BildirimComponent', () => {
  let component: BildirimComponent;
  let fixture: ComponentFixture<BildirimComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ BildirimComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(BildirimComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
