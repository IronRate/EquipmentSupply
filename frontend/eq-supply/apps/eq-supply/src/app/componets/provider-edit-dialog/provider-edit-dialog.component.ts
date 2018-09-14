import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';

@Component({
  selector: 'app-provider-edit-dialog',
  templateUrl: './provider-edit-dialog.component.html',
  styleUrls: ['./provider-edit-dialog.component.css']
})
export class ProviderEditDialogComponent implements OnInit {
  public form: FormGroup;

  constructor(private fb: FormBuilder) {}

  ngOnInit() {
    this.createForm();
  }

  createForm() {
    this.form = this.fb.group({
      id: null,
      name:[null,[Validators.required]],
      email: [null,[Validators.required]],
      address: [null,[Validators.required]]
    });
  }
}
