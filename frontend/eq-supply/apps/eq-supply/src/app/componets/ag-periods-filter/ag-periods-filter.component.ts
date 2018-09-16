import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Subject } from 'rxjs/Subject';
import { Observable } from 'rxjs/Observable';
import { RowNode, IDoesFilterPassParams } from 'ag-grid';
import { IFilterAngularComp } from 'ag-grid-angular';

@Component({
  selector: 'app-ag-periods-filter',
  templateUrl: './ag-periods-filter.component.html',
  styleUrls: ['./ag-periods-filter.component.css']
})
export class AgPeriodsFilterComponent implements OnInit, IFilterAngularComp {
  private params: any;
  private valueGetter: (rowNode: RowNode) => any;
  private _timer: Observable<number>;
  private ngUnsubscribe: Subject<void> = new Subject();
  public form: FormGroup;
  public text: string = '';
  public maxDate = new Date();

  constructor(private fb: FormBuilder) {}

  ngOnInit() {
    this.createForm();
  }

  agInit(params: any): void {
    this.params = params;
    this.valueGetter = params.valueGetter;
  }

  isFilterActive(): boolean {
    return this.text !== null && this.text !== undefined && this.text !== '';
  }

  doesFilterPass(params: IDoesFilterPassParams): boolean {
    return this.text
      .toLowerCase()
      .split(' ')
      .every(filterWord => {
        return (
          this.valueGetter(params.node)
            .toString()
            .toLowerCase()
            .indexOf(filterWord) >= 0
        );
      });
  }

  getModel(): any {
    return { value: this.form.value };
  }

  setModel(model: any): void {
    if (this.form) {
      if (model) this.form.patchValue(model);
      else this.form.reset();
    }
  }

  public clearHandler(){
    this.form.reset();
  }

  private createForm() {
    this.form = this.fb.group({
      dateFrom: [null],
      dateTo: [new Date()]
    });
    this.form.valueChanges
      .debounceTime(1000)
      .takeUntil(this.ngUnsubscribe)
      .subscribe(x => {
        this.params.filterChangedCallback();
      });
  }
}
