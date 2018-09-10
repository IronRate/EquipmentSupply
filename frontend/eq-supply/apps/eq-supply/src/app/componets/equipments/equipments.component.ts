import { EquipmentsRepository } from './../../services/backend/equipment.service';
import { Component, OnInit, OnDestroy } from '@angular/core';
import { Subject } from 'rxjs';

@Component({
  selector: 'app-equipments',
  templateUrl: './equipments.component.html',
  styleUrls: ['./equipments.component.css']
})
export class EquipmentsComponent implements OnInit,OnDestroy {

private ngUnsubscribe:Subject<void>=new Subject();

  constructor(private equipments:EquipmentsRepository) { }

  ngOnInit() {
  }

  ngOnDestroy(){
    this.ngUnsubscribe.next();
    this.ngUnsubscribe.complete();
  }

  fetch(){
    this.equipments.getAll()
    .takeUntil(this.ngUnsubscribe)
    .subscribe({
      next:x=>{}
    })
  }

}
