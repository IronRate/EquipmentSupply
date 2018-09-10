import { Component, OnInit, OnDestroy } from '@angular/core';
import { ProvidersRepository } from '../../services/backend/providers.servise';
import 'rxjs/add/operator/takeUntil';
import { Subject } from 'rxjs';

@Component({
  selector: 'app-providers',
  templateUrl: './providers.component.html',
  styleUrls: ['./providers.component.css']
})
export class ProvidersComponent implements OnInit, OnDestroy {
  private ngUnsubsctibe: Subject<void> = new Subject();
  constructor(private providers: ProvidersRepository) {}

  ngOnInit() {}

  ngOnDestroy() {
    this.ngUnsubsctibe.next();
    this.ngUnsubsctibe.complete();
  }

  fetch() {
    this.providers
      .getAll()
      .takeUntil(this.ngUnsubsctibe)
      .subscribe({
        next: x => {}
      });
  }
}
