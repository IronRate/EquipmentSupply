import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { NxModule } from '@nrwl/nx';
import { MainMenuComponent } from './componets/main-menu/main-menu.component';
import { ProvidersComponent } from './componets/providers/providers.component';
import { SuppliesComponent } from './componets/supplies/supplies.component';
import { ProviderEditDialogComponent } from './componets/provider-edit-dialog/provider-edit-dialog.component';
import { SupplyEditDialogComponent } from './componets/supply-edit-dialog/supply-edit-dialog.component';
import { EquipmentsComponent } from './componets/equipments/equipments.component';
import { EquipmentEditDialogComponent } from './componets/equipment-edit-dialog/equipment-edit-dialog.component';

@NgModule({
  declarations: [AppComponent, MainMenuComponent, ProvidersComponent, SuppliesComponent, ProviderEditDialogComponent, SupplyEditDialogComponent, EquipmentsComponent, EquipmentEditDialogComponent],
  imports: [BrowserModule, NxModule.forRoot()],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule {}
