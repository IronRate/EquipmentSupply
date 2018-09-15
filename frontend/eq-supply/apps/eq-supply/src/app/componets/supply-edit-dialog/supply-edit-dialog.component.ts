import { EquipmentsRepository } from './../../services/backend/equipment.service';
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
  FormControl
} from '@angular/forms';
import { Observable } from 'rxjs/Observable';
import { Subject } from 'rxjs';
import 'rxjs/add/operator/map';

@Component({
  selector: 'app-supply-edit-dialog',
  templateUrl: './supply-edit-dialog.component.html',
  styleUrls: ['./supply-edit-dialog.component.css']
})
export class SupplyEditDialogComponent implements OnInit, OnDestroy {
  public form: FormGroup;
  public filteredProviders: Observable<IProviderItem[]>;

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
      provider: [null, [Validators.required]]
    });
  }

  searchProviders($event) {
    this.filteredProviders = this.findProviders($event);
  }

  private findProviders(name:string) {
    return this.providers.find(name);
  }

  displayFnProvider(provider?: IProviderItem): string | undefined {
    return provider ? provider.name : undefined;
  }
}
