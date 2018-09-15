import {
  SuppliesRepository,
  ISupplyItem
} from './../../services/backend/supplies.service';
import { Component, OnInit, OnDestroy } from '@angular/core';
import { Subject, Observable } from 'rxjs';
import 'rxjs/add/operator/takeUntil';
import { RowNode } from 'ag-grid';
import { SupplyEditDialogComponent } from '../supply-edit-dialog/supply-edit-dialog.component';
import { MatDialog } from '@angular/material';

@Component({
  selector: 'app-supplies',
  templateUrl: './supplies.component.html',
  styleUrls: ['./supplies.component.css']
})
export class SuppliesComponent implements OnInit, OnDestroy {
  public data: ISupplyItem[];
  public currentRow:RowNode;
  private ngUnsubscribe: Subject<void> = new Subject();
  constructor(private supplies: SuppliesRepository,private dialog:MatDialog) {}

  ngOnInit() {
    this.fetch();
  }

  ngOnDestroy() {
    this.ngUnsubscribe.next();
    this.ngUnsubscribe.complete();
  }

  fetch() {
    this.supplies
      .getAll()
      .takeUntil(this.ngUnsubscribe)
      .subscribe({
        next: x => {
          this.data = x;
        }
      });
  }

  addHandler() {
    this.dialog
      .open(SupplyEditDialogComponent, { width: '50%' })
      .afterClosed()
      .takeUntil(this.ngUnsubscribe)
      .subscribe((x: ISupplyItem) => {
        if (x) this.saveProviderItem(x);
      });
  }

  removeHandler() {
    this.removeProviderItem(this.currentRow.data);
  }

  editHandler() {
    this.dialog
      .open(SupplyEditDialogComponent, {
        width: '50%',
        data: this.currentRow.data
      })
      .afterClosed()
      .takeUntil(this.ngUnsubscribe)
      .subscribe(x => {
        if (x) this.saveProviderItem(x);
      });
  }

  rowSelectHandler($event: RowNode) {
    this.currentRow = $event;
  }

  private saveProviderItem(x: ISupplyItem) {
    let obs: Observable<object>;
    if (x.id) {
      obs = this.supplies.patch(x);
    } else {
      obs = this.supplies.add(x);
    }
    obs.takeUntil(this.ngUnsubscribe).subscribe({ next: () => this.fetch() });
  }

  private removeProviderItem(x: ISupplyItem) {
    this.supplies
      .remove(x.id)
      .takeUntil(this.ngUnsubscribe)
      .subscribe({ next: () => this.fetch() });
  }


}
