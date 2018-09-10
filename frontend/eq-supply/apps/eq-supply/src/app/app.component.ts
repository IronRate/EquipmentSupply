import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { IMenuItem } from './componets/main-menu/main-menu.component';

@Component({
  selector: 'eq-supply-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  selectedMenuItem: IMenuItem;

  constructor( private router: Router){

  }

  onMenuClick(menu: IMenuItem) {
    this.selectedMenuItem = menu;
    this.router.navigate([menu.url]);
  }
}
