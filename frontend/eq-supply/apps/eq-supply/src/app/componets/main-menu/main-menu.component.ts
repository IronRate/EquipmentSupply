import { OnDestroy } from '@angular/core/src/metadata/lifecycle_hooks';
import { ActivatedRoute, Params, Router, NavigationEnd } from '@angular/router';

import {
  Component,
  OnInit,
  Output,
  ChangeDetectionStrategy,
  ChangeDetectorRef
} from '@angular/core';
import { Subject } from 'rxjs';
import { filter } from 'rxjs/operators';
import {takeUntil} from 'rxjs/operator/takeUntil';

export interface IMenuItem {
  name: string;
  text: string;
  url?: string;
  icon?: string;
  items?: IMenuItem[];
  expanded?: boolean;
}

@Component({
  selector: 'app-main-menu',
  templateUrl: './main-menu.component.html',
  styleUrls: ['./main-menu.component.less']
})
export class MainMenuComponent implements OnInit, OnDestroy {
  constructor(private router: Router) {}

  @Output() itemClick: Subject<IMenuItem> = new Subject();
  items: Array<IMenuItem>;
  selectedItem: IMenuItem;
  private ngUnsubscribe: Subject<void> = new Subject();

  ngOnInit() {
    this.initMenu();
    this.selectedItem = this.items[0];

    this.router.events
      .takeUntil(this.ngUnsubscribe)
      //.filter(event => event instanceof NavigationEnd)
      .subscribe((event: NavigationEnd) => {
        const menuItem = this.findMenu(event.urlAfterRedirects);
        if (menuItem && menuItem.parent) {
          menuItem.parent.expanded = true;
          this.selectedItem = menuItem.item;
        }
      });
  }

  ngOnDestroy() {
    this.ngUnsubscribe.next();
    this.ngUnsubscribe.complete();
  }

  onMenuClick(menu: IMenuItem) {
    this.selectedItem = menu;
    this.itemClick.next(menu);
  }

  onOpen(item: IMenuItem) {
    if (this.selectedItem) {
      if (!item.items.some(x => x.name === this.selectedItem.name)) {
        this.onMenuClick(item.items[0]);
      }
    }
  }

  private findMenu(url: string, items = this.items) {
    if (items) {
      for (let i = 0; i <= items.length - 1; i++) {
        if (items[i].url === url) {
          return { item: items[i] };
        } else if (items[i].items) {
          const item = this.findMenu(url, items[i].items);
          if (item) return { ...item, parent: items[i] };
        }
      }
    }
  }

  private initMenu() {
    this.items = [
      {
        name: 'supplies',
        text: 'Поставки',
        url:'/supplies'
      },
      {
        name:'reports',
        text:'Отчеты',
        expanded:false,
      }
      ,{
        name:'directories',
        text:'Справочники',
        expanded:false,
        items:[
          {
            name:'providers',
            text:'Поставщики'
            ,url:'directories/providers'
          }
          ,{
            name:'equipments',
            text:'Оборудование'
            ,url:'directories/equipments'
          }
        ]
      }
    ];
  }
}
