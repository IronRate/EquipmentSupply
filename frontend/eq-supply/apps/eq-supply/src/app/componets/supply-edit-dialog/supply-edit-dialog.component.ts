import { ISupplyItem } from './../../services/backend/supplies.service';
import { Component, OnInit, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-supply-edit-dialog',
  templateUrl: './supply-edit-dialog.component.html',
  styleUrls: ['./supply-edit-dialog.component.css']
})
export class SupplyEditDialogComponent implements OnInit {
  public form: FormGroup;
  constructor(
    private fb: FormBuilder,
    @Inject(MAT_DIALOG_DATA) private data: ISupplyItem
  ) {}

  ngOnInit() {
    this.createForm();
  }

  createForm() {
    this.form = this.fb.group({
      provider: [null, [Validators.required]],
      supplies:this.fb.array(null);
    });
  }
}
