import { IEquipmentItem } from './../../services/backend/equipment.service';
import { Component, OnInit, Inject } from '@angular/core';
import { Validators, FormBuilder, FormGroup } from '@angular/forms';
import { MAT_DIALOG_DATA } from '@angular/material';

@Component({
  selector: 'app-equipment-edit-dialog',
  templateUrl: './equipment-edit-dialog.component.html',
  styleUrls: ['./equipment-edit-dialog.component.css']
})
export class EquipmentEditDialogComponent implements OnInit {
  public form: FormGroup;

  constructor(
    private fb: FormBuilder,
    @Inject(MAT_DIALOG_DATA) private data: IEquipmentItem
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
      name: [null, [Validators.required]]
    });
  }
}
