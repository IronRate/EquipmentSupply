import { Component, OnInit } from '@angular/core';

interface MenuItem {
    link: string;
    name: string;
    icon?: string;
}


@Component({
    selector: 'nav-menu',
    templateUrl: './navmenu.component.html',
    styleUrls: ['./navmenu.component.css']
})
export class NavMenuComponent implements OnInit {
    public menuItems: MenuItem[];


    constructor() {

    }

    ngOnInit() {

        this.initMenu();
    }


    private initMenu() {
        this.menuItems = [
            {
                link: '/provides',
                name: 'Поставки'
            },
            {
                link: '/reports',
                name: 'Отчеты'
            },
            {
                link: '/equipments',
                name: 'Типы оборудования',
                icon: 'glyphicon'
            },
            {
                link: '/providers',
                name: 'Поставщики',
                icon: 'glyphicon'
            }
        ];
    }
}
