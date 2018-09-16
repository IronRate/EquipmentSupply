import { OnDestroy } from '@angular/core/src/metadata/lifecycle_hooks';
import { ReportsService, IEquipmentReportItem } from './../../../services/backend/reports.service';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { MatInput, MatAutocompleteSelectedEvent } from '@angular/material';
import { ProvidersRepository } from './../../../services/backend/providers.servise';
import { Component, OnInit, ViewChild } from '@angular/core';
import { Subject } from 'rxjs/Subject';
import { Observable } from 'rxjs/Observable';
import { IProviderItem } from '../../../services/backend/providers.servise';

@Component({
  selector: 'app-report-equipments',
  templateUrl: './report-equipments.component.html',
  styleUrls: ['./report-equipments.component.css']
})
export class ReportEquipmentsComponent implements OnInit, OnDestroy {
  public form: FormGroup;
  public filteredProviders: Observable<IProviderItem[]>;
  public data: IEquipmentReportItem[];

  private ngUnsubscribe: Subject<void> = new Subject();
  constructor(
    private fb: FormBuilder,
    private providers: ProvidersRepository,
    private reports: ReportsService
  ) {}

  ngOnInit() {
    this.createForm();
  }

  ngOnDestroy(){
    this.ngUnsubscribe.next();
    this.ngUnsubscribe.complete();
  }

  searchProviders($event) {
    this.filteredProviders = this.providers.find($event);
  }

  displayFnProvider(provider?: IProviderItem): string | undefined {
    return provider ? provider.name : undefined;
  }

  providerSelected($event: MatAutocompleteSelectedEvent) {
    this.fetch();
  }

  fetch() {
    this.reports
      .getEquipmentsReport(this.form.value.provider.id)
      .takeUntil(this.ngUnsubscribe)
      .subscribe(x => {
        this.data = x;
      });
  }

  private createForm() {
    this.form = this.fb.group({
      provider: [null, [Validators.required]]
    });

    this.form.controls.provider.valueChanges
      .debounceTime(500)
      .subscribe(newValue => {
        this.searchProviders(newValue);
      });
  }
}
