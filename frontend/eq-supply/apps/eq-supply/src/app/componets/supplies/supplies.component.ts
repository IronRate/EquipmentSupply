import { Router, ActivatedRoute, Params } from '@angular/router';
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
  public currentRow: RowNode;
  private ngUnsubscribe: Subject<void> = new Subject();
  public currentState: number;

  private filterDate: {
    dateFrom?: Date;
    dateTo?: Date;
  } = {};

  constructor(
    private supplies: SuppliesRepository,
    private dialog: MatDialog,
    private activatedRoute: ActivatedRoute
  ) {}

  ngOnInit() {
    //this.fetch();
    this.initRouter();
  }

  ngOnDestroy() {
    this.ngUnsubscribe.next();
    this.ngUnsubscribe.complete();
  }

  fetch() {
    let q: Observable<ISupplyItem[]>;
    q = this.supplies.getExtended(this.currentState == 1 ? false : true,this.filterDate.dateFrom,this.filterDate.dateTo);
    q.takeUntil(this.ngUnsubscribe).subscribe({
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

  filterChangedHandler(filter: any) {
    this.filterDate = filter.provideDate.value;
    this.fetch();
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

  private initRouter() {
    this.activatedRoute.params
      .takeUntil(this.ngUnsubscribe)
      .subscribe((params: Params) => {
        this.currentState =
          params['state'] || this.activatedRoute.snapshot.data.state;
        this.fetch();
      });
  }
}
