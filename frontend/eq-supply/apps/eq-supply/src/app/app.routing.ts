import { EquipmentsComponent } from './componets/equipments/equipments.component';
import { ProvidersComponent } from './componets/providers/providers.component';
import { ModuleWithProviders } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { SuppliesComponent } from './componets/supplies/supplies.component';
import { componentFactoryName } from '@angular/compiler';

export const routes: Routes = [
  {
    path: '',
    redirectTo: 'supplies',
    pathMatch: 'full'
  },
  {
    path: 'supplies',
    component: SuppliesComponent
  },
  {
    path:'directories/providers',
    component:ProvidersComponent
  },
  {
    path:'directories/equipments'
    ,component:EquipmentsComponent
  },
  {
    path: '**',
    redirectTo: 'dist',
    pathMatch: 'full'
  }
];

export const routing: ModuleWithProviders = RouterModule.forRoot(routes);
