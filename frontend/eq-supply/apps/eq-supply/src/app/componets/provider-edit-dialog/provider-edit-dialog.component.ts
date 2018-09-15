import { IProviderItem } from './../../services/backend/providers.servise';
import { Component, OnInit, Inject } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { MAT_DIALOG_DATA } from '@angular/material';

@Component({
  selector: 'app-provider-edit-dialog',
  templateUrl: './provider-edit-dialog.component.html',
  styleUrls: ['./provider-edit-dialog.component.css']
})
export class ProviderEditDialogComponent implements OnInit {
  public form: FormGroup;

  constructor(
    private fb: FormBuilder,
    @Inject(MAT_DIALOG_DATA) private data: IProviderItem
  ) {}

  ngOnInit() {
    this.createForm();
    if (this.data) {
      this.form.patchValue(this.data);
    }
  }

  createForm() {
    this.form = this.fb.group({
      id: null,
      name: [null, [Validators.required]],
      email: [
        null,
        [Validators.required, Validators.pattern(/^.*@.*\..{2,}/g)]
      ],
      address: [null, [Validators.required]],
      phone: [null, [Validators.required]]
    });
  }
}
