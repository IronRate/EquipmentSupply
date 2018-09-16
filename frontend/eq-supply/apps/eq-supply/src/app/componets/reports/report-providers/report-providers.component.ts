import { OnDestroy } from '@angular/core/src/metadata/lifecycle_hooks';
import {
  ReportsService,
  IProviderReportItem
} from './../../../services/backend/reports.service';
import { Component, OnInit } from '@angular/core';
import { Subject } from 'rxjs/Subject';

@Component({
  selector: 'app-report-providers',
  templateUrl: './report-providers.component.html',
  styleUrls: ['./report-providers.component.css']
})
export class ReportProvidersComponent implements OnInit, OnDestroy {
  private ngUnsubscribe: Subject<void> = new Subject();
  public data: IProviderReportItem[];
  constructor(private reports: ReportsService) {}

  ngOnInit() {
    this.fetch();
  }

  ngOnDestroy() {
    this.ngUnsubscribe.next();
    this.ngUnsubscribe.complete();
  }

  fetch() {
    this.reports.getProvidersReport().subscribe(x => {
      this.data = x;
    });
  }
}
