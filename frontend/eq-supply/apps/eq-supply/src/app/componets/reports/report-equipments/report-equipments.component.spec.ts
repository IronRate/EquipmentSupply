import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ReportEquipmentsComponent } from './report-equipments.component';

describe('ReportEquipmentsComponent', () => {
  let component: ReportEquipmentsComponent;
  let fixture: ComponentFixture<ReportEquipmentsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ReportEquipmentsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ReportEquipmentsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
