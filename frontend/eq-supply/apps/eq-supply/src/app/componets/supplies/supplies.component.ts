import { SuppliesService } from './../../services/backend/supplies.service';
import { Component, OnInit, OnDestroy } from '@angular/core';
import { Subject } from 'rxjs';
import 'rxjs/add/operator/takeUntil';

@Component({
  selector: 'app-supplies',
  templateUrl: './supplies.component.html',
  styleUrls: ['./supplies.component.css']
})
export class SuppliesComponent implements OnInit,OnDestroy {

  private ngUnsubscribe:Subject<void>=new Subject();
  constructor(private supplies:SuppliesService) { }

  ngOnInit() {
  }

  ngOnDestroy() {
    this.ngUnsubscribe.next();
    this.ngUnsubscribe.complete();
  }

  fetch(){
    this.supplies.getAll()
    .takeUntil(this.ngUnsubscribe)
    .subscribe({
      next:x=>{

      }
    })
  }

}
