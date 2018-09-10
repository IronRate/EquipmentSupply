import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SupplyEditDialogComponent } from './supply-edit-dialog.component';

describe('SupplyEditDialogComponent', () => {
  let component: SupplyEditDialogComponent;
  let fixture: ComponentFixture<SupplyEditDialogComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SupplyEditDialogComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SupplyEditDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
