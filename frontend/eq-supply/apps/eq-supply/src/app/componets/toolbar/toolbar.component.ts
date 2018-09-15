import { Component, OnInit, Output, Input } from '@angular/core';
import { Subject } from 'rxjs';

@Component({
  selector: 'app-toolbar',
  templateUrl: './toolbar.component.html',
  styleUrls: ['./toolbar.component.css']
})
export class ToolbarComponent implements OnInit {
  @Output() refresh: Subject<void> = new Subject();
  @Output() add: Subject<void> = new Subject();
  @Output() edit: Subject<void> = new Subject();
  @Output() remove: Subject<void> = new Subject();
  @Input() row:any;

  constructor() {}

  ngOnInit() {}
}
