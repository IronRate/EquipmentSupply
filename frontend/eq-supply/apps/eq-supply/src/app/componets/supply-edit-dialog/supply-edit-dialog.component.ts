import {
  EquipmentsRepository,
  IEquipmentItem
} from './../../services/backend/equipment.service';
import {
  ProvidersRepository,
  IProviderItem
} from './../../services/backend/providers.servise';
import { ISupplyItem } from './../../services/backend/supplies.service';
import { Component, OnInit, Inject, ViewChild, OnDestroy } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA, MatInput } from '@angular/material';
import {
  FormBuilder,
  FormGroup,
  Validators,
  FormControl,
  FormArray
} from '@angular/forms';
import { Observable } from 'rxjs/Observable';
import { Subject } from 'rxjs';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/debounceTime';

@Component({
  selector: 'app-supply-edit-dialog',
  templateUrl: './supply-edit-dialog.component.html',
  styleUrls: ['./supply-edit-dialog.component.css']
})
export class SupplyEditDialogComponent implements OnInit, OnDestroy {
  public form: FormGroup;
  public filteredProviders: Observable<IProviderItem[]>;
  public filteredEquipments: Observable<IEquipmentItem[]>;

  private ngUnsubscribe: Subject<void> = new Subject();

  constructor(
    private fb: FormBuilder,
    @Inject(MAT_DIALOG_DATA) private data: ISupplyItem,
    private providers: ProvidersRepository,
    private equipments: EquipmentsRepository
  ) {}

  ngOnInit() {
    this.createForm();
  }

  ngOnDestroy() {
    this.ngUnsubscribe.next();
    this.ngUnsubscribe.complete();
  }

  createForm() {
    this.form = this.fb.group({
      id:[null],
      provider: [null, [Validators.required]],
      provideDate: [null, [Validators.required]],
      supplies: new FormArray([])
    });

    if (this.data) {
      this.form.patchValue({
        id:this.data.id,
        provider: this.data.provider,
        provideDate: this.data.provideDate
      });
      this.addHandler();
      const a=this.form.controls['supplies'];
      (<any>a).controls[0].patchValue({equipment:this.data.equipmentType,count:this.data.count})
    }else{
       this.addHandler();
    }

    this.form.controls.provider.valueChanges
      .debounceTime(500)
      .subscribe(newValue => {
        this.searchProviders(newValue);
      });
  }

  searchProviders($event) {
    this.filteredProviders = this.findProviders($event);
  }

  searchEquipments($event) {
    this.filteredEquipments = this.equipments.find($event);
  }

  addHandler() {
    const control = this.fb.group({
      equipment: [null, [Validators.required]],
      count: [0, [Validators.required, Validators.min(1)]]
    });
    (<FormArray>this.form.get('supplies')).push(control);
  }

  private findProviders(name: string) {
    return this.providers.find(name);
  }

  displayFnProvider(provider?: IProviderItem): string | undefined {
    return provider ? provider.name : undefined;
  }

  supplyRemoveHandler(i: number) {
    (<FormArray>this.form.get('supplies')).removeAt(i);
  }
}
