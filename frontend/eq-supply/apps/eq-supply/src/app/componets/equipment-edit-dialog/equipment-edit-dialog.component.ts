import { Component, OnInit } from '@angular/core';
import { Validators, FormBuilder, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-equipment-edit-dialog',
  templateUrl: './equipment-edit-dialog.component.html',
  styleUrls: ['./equipment-edit-dialog.component.css']
})
export class EquipmentEditDialogComponent implements OnInit {
  public form: FormGroup;

  constructor(private fb: FormBuilder) {}

  ngOnInit() {
    this.createForm();
  }

  createForm() {
    this.form = this.fb.group({
      id: null,
      name:[null,[Validators.required]],
    });
  }

}
