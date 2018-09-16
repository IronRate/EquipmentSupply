import { OnDestroy } from '@angular/core/src/metadata/lifecycle_hooks';
import {
  ReportsService,
  IProviderReportItem
} from './../../../services/backend/reports.service';
import { Component, OnInit } from '@angular/core';
import { Subject } from 'rxjs/Subject';
import { ErrorAnalyzerService } from '../../../services/error-analyzer.service';
import { MatSnackBar } from '@angular/material';

@Component({
  selector: 'app-report-providers',
  templateUrl: './report-providers.component.html',
  styleUrls: ['./report-providers.component.css']
})
export class ReportProvidersComponent implements OnInit, OnDestroy {
  private ngUnsubscribe: Subject<void> = new Subject();
  public data: IProviderReportItem[];
  constructor(
    private reports: ReportsService,
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
    this.reports.getProvidersReport().subscribe({
      next: x => (this.data = x),
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
