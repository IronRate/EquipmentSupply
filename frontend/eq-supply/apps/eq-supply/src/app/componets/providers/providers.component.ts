import { IProviderItem } from './../../services/backend/providers.servise';
import { Component, OnInit, OnDestroy } from '@angular/core';
import { ProvidersRepository } from '../../services/backend/providers.servise';
import 'rxjs/add/operator/takeUntil';
import { Subject, Observable } from 'rxjs';
import { RowNode } from 'ag-grid';
import { MatDialog } from '@angular/material';
import { ProviderEditDialogComponent } from '../provider-edit-dialog/provider-edit-dialog.component';

@Component({
  selector: 'app-providers',
  templateUrl: './providers.component.html',
  styleUrls: ['./providers.component.css']
})
export class ProvidersComponent implements OnInit, OnDestroy {
  private ngUnsubsctibe: Subject<void> = new Subject();
  private currentRow: RowNode;

  constructor(
    private providers: ProvidersRepository,
    private dialog: MatDialog
  ) {}

  ngOnInit() {}

  ngOnDestroy() {
    this.ngUnsubsctibe.next();
    this.ngUnsubsctibe.complete();
  }

  fetch() {
    this.providers
      .getAll()
      .takeUntil(this.ngUnsubsctibe)
      .subscribe({
        next: x => {}
      });
  }

  addHandler() {
    this.dialog
      .open(ProviderEditDialogComponent, { width: '50%' })
      .afterClosed()
      .takeUntil(this.ngUnsubsctibe)
      .subscribe((x: IProviderItem) => {
        this.saveProviderItem(x);
      });
  }

  removeHandler() {
    this.removeProviderItem(this.currentRow.data);
  }

  editHandler() {
    this.dialog
      .open(ProviderEditDialogComponent, { width: '50%' })
      .afterClosed()
      .takeUntil(this.ngUnsubsctibe)
      .subscribe(x => {
        this.saveProviderItem(x);
      });
  }

  rowSelectHandler($event: RowNode) {
    this.currentRow = $event;
  }

  private saveProviderItem(x: IProviderItem) {
    let obs: Observable<object>;
    if (x.id) {
      obs = this.providers.patch(x);
    } else {
      obs = this.providers.add(x);
    }
    obs.takeUntil(this.ngUnsubsctibe).subscribe();
  }

  private removeProviderItem(x: IProviderItem) {
    this.providers
      .remove(x.id)
      .takeUntil(this.ngUnsubsctibe)
      .subscribe();
  }
}
