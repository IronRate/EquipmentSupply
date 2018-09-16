import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ReportProvidersComponent } from './report-providers.component';

describe('ReportProvidersComponent', () => {
  let component: ReportProvidersComponent;
  let fixture: ComponentFixture<ReportProvidersComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ReportProvidersComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ReportProvidersComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
