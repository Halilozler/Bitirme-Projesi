import { ComponentFixture, TestBed } from '@angular/core/testing';

import { IptalpopupComponent } from './iptalpopup.component';

describe('IptalpopupComponent', () => {
  let component: IptalpopupComponent;
  let fixture: ComponentFixture<IptalpopupComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ IptalpopupComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(IptalpopupComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
