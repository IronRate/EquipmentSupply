import { ErrorAnalyzerService } from './../../services/error-analyzer.service';
import { IProviderItem } from './../../services/backend/providers.servise';
import { Component, OnInit, OnDestroy } from '@angular/core';
import { ProvidersRepository } from '../../services/backend/providers.servise';
import 'rxjs/add/operator/takeUntil';
import { Subject, Observable } from 'rxjs';
import { RowNode } from 'ag-grid';
import { MatDialog, MatSnackBar } from '@angular/material';
import { ProviderEditDialogComponent } from '../provider-edit-dialog/provider-edit-dialog.component';
import { MessageBox } from '../message-box/message-box.component';

@Component({
  selector: 'app-providers',
  templateUrl: './providers.component.html',
  styleUrls: ['./providers.component.css']
})
export class ProvidersComponent implements OnInit, OnDestroy {
  private ngUnsubscribe: Subject<void> = new Subject();
  public currentRow: RowNode;
  public data: IProviderItem[];

  constructor(
    private providers: ProvidersRepository,
    private dialog: MatDialog,
    private messageBox: MessageBox,
    private errorAnalyzer: ErrorAnalyzerService,
    private snackBar: MatSnackBar
  ) {}

  ngOnInit() {
    this.fetch();
  }

  ngOnDestroy() {
    this.ngUnsubscribe.next();
    this.ngUnsubscribe.complete();
  }

  fetch() {
    this.providers
      .getAll()
      .takeUntil(this.ngUnsubscribe)
      .subscribe({
        next: x => (this.data = x),
        error: ex => {
          this.errorHandler(ex);
        }
      });
  }

  addHandler() {
    this.dialog
      .open(ProviderEditDialogComponent, { width: '50%' })
      .afterClosed()
      .takeUntil(this.ngUnsubscribe)
      .subscribe((x: IProviderItem) => {
        if (x) this.saveProviderItem(x);
      });
  }

  removeHandler() {
    this.messageBox
      .confirm('Удвление', 'Вы действительно хотите удалить поставщика')
      .subscribe(() => {
        this.removeProviderItem(this.currentRow.data);
      });
  }

  editHandler() {
    this.dialog
      .open(ProviderEditDialogComponent, {
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

  private saveProviderItem(x: IProviderItem) {
    let obs: Observable<object>;
    if (x.id) {
      obs = this.providers.patch(x);
    } else {
      obs = this.providers.add(x);
    }
    obs.takeUntil(this.ngUnsubscribe).subscribe({
      next: () => this.fetch(),
      error: ex => {
        this.errorHandler(ex);
      }
    });
  }

  private removeProviderItem(x: IProviderItem) {
    this.providers
      .remove(x.id)
      .takeUntil(this.ngUnsubscribe)
      .subscribe({
        next: () => this.fetch(),
        error: ex => {
          this.errorHandler(ex);
        }
      });
  }

  private errorHandler(ex) {
    if (ex) {
      const error = this.errorAnalyzer.get(ex, true);
      this.snackBar.open(error.message, 'Ошибка', { duration: 5000 });
    }
  }
}
