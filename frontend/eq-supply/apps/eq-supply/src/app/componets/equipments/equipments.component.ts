import { EquipmentEditDialogComponent } from './../equipment-edit-dialog/equipment-edit-dialog.component';
import { EquipmentsRepository, IEquipmentItem } from './../../services/backend/equipment.service';
import { Component, OnInit, OnDestroy } from '@angular/core';
import { Subject, Observable } from 'rxjs';
import { MatDialog } from '@angular/material';
import { RowNode } from 'ag-grid';

@Component({
  selector: 'app-equipments',
  templateUrl: './equipments.component.html',
  styleUrls: ['./equipments.component.css']
})
export class EquipmentsComponent implements OnInit, OnDestroy {
  private ngUnsubscribe: Subject<void> = new Subject();
  public currentRow:RowNode;

  constructor(
    private equipments: EquipmentsRepository,
    private dialog: MatDialog
  ) {}

  ngOnInit() {}

  ngOnDestroy() {
    this.ngUnsubscribe.next();
    this.ngUnsubscribe.complete();
  }

  fetch() {
    this.equipments
      .getAll()
      .takeUntil(this.ngUnsubscribe)
      .subscribe({
        next: x => {}
      });
  }

  addHandler() {
    this.dialog
      .open(EquipmentEditDialogComponent, { width: '50%' })
      .afterClosed()
      .takeUntil(this.ngUnsubscribe)
      .subscribe((x: IEquipmentItem) => {
        this.saveProviderItem(x);
      });
  }

  removeHandler() {
    this.removeProviderItem(this.currentRow.data);
  }

  editHandler() {
    this.dialog
      .open(EquipmentEditDialogComponent, { width: '50%' })
      .afterClosed()
      .takeUntil(this.ngUnsubscribe)
      .subscribe(x => {
        this.saveProviderItem(x);
      });
  }

  rowSelectHandler($event: RowNode) {
    this.currentRow = $event;
  }

  private saveProviderItem(x: IEquipmentItem) {
    let obs: Observable<object>;
    if (x.id) {
      obs = this.equipments.patch(x);
    } else {
      obs = this.equipments.add(x);
    }
    obs.takeUntil(this.ngUnsubscribe).subscribe();
  }

  private removeProviderItem(x: IEquipmentItem) {
    this.equipments
      .remove(x.id)
      .takeUntil(this.ngUnsubscribe)
      .subscribe();
  }
}
