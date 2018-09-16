import { EquipmentsComponent } from './componets/equipments/equipments.component';
import { ProvidersComponent } from './componets/providers/providers.component';
import { ModuleWithProviders, Component } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { SuppliesComponent } from './componets/supplies/supplies.component';
import { componentFactoryName } from '@angular/compiler';
import { ReportEquipmentsComponent } from './componets/reports/report-equipments/report-equipments.component';
import { ReportProvidersComponent } from './componets/reports/report-providers/report-providers.component';

export const routes: Routes = [
  {
    path: '',
    redirectTo: 'supplies',
    pathMatch: 'full'
  },
  {
    path: 'supplies/:state',
    component: SuppliesComponent
  },
  {
    path: 'supplies/:state',
    component: SuppliesComponent
  },
  {
    path: 'directories/providers',
    component: ProvidersComponent
  },
  {
    path: 'directories/equipments',
    component: EquipmentsComponent
  },
  {
    path: 'reports/equipments',
    component:ReportEquipmentsComponent
  },
  {
    path: 'reports/providers',
    component: ReportProvidersComponent
  },
  {
    path: '**',
    redirectTo: 'dist',
    pathMatch: 'full'
  }
];

export const routing: ModuleWithProviders = RouterModule.forRoot(routes);
