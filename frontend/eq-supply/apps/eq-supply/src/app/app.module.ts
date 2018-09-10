import { HttpClient, HttpHandler, HttpClientModule } from '@angular/common/http';
import { EquipmentsRepository } from './services/backend/equipment.service';
import { SuppliesRepository } from './services/backend/supplies.service';
import { routing } from './app.routing';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { AppComponent } from './app.component';
import { NxModule } from '@nrwl/nx';
import { MainMenuComponent } from './componets/main-menu/main-menu.component';
import { ProvidersComponent } from './componets/providers/providers.component';
import { SuppliesComponent } from './componets/supplies/supplies.component';
import { ProviderEditDialogComponent } from './componets/provider-edit-dialog/provider-edit-dialog.component';
import { SupplyEditDialogComponent } from './componets/supply-edit-dialog/supply-edit-dialog.component';
import { EquipmentsComponent } from './componets/equipments/equipments.component';
import { EquipmentEditDialogComponent } from './componets/equipment-edit-dialog/equipment-edit-dialog.component';

//angular-material
import {
  MatDialogModule,
  MatAutocompleteModule,
  MatCheckboxModule,
  MatButtonModule,
  MatCardModule,
  MatMenuModule,
  MatToolbarModule,
  MatIconModule,
  MatInputModule,
  MatDatepickerModule,
  MatNativeDateModule,
  MatProgressSpinnerModule,
  MatTableModule,
  MatExpansionModule,
  MatSelectModule,
  MatSnackBarModule,
  MatTooltipModule,
  MatChipsModule,
  MatListModule,
  MatSidenavModule,
  MatTabsModule,
  MatProgressBarModule,
  MatFormFieldModule,
  MatPaginatorModule,
  MatRadioModule,
  MatSlideToggleModule,
  MAT_DATE_LOCALE,
  MAT_PAGINATOR_INTL_PROVIDER,
  MatPaginatorIntl,
  MAT_DIALOG_DEFAULT_OPTIONS,
  MAT_SNACK_BAR_DATA,
  MAT_DATE_FORMATS,
  DateAdapter,
  MatAccordion
} from '@angular/material';

//ag-grid
import { AgGridModule } from 'ag-grid-angular/main';

import { FlexLayoutModule } from '@angular/flex-layout';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { NgxMaskModule } from 'ngx-mask';
import {
  MAT_MOMENT_DATE_FORMATS,
  MomentDateAdapter
} from '@angular/material-moment-adapter';
import { ProvidersRepository } from './services/backend/providers.servise';
import { ProvidersGridComponent } from './componets/providers-grid/providers-grid.component';
import { EquipmentsGridComponent } from './componets/equipments-grid/equipments-grid.component';

@NgModule({
  declarations: [
    AppComponent,
    MainMenuComponent,
    ProvidersComponent,
    SuppliesComponent,
    ProviderEditDialogComponent,
    SupplyEditDialogComponent,
    EquipmentsComponent,
    EquipmentEditDialogComponent,
    ProvidersGridComponent,
    EquipmentsGridComponent
  ],
  imports: [
    BrowserModule,
    NxModule.forRoot(),
    routing,
    BrowserModule,
    HttpClientModule,
    BrowserAnimationsModule,
    MatButtonModule,
    MatInputModule,
    MatFormFieldModule,
    MatListModule,
    MatProgressSpinnerModule,
    FlexLayoutModule,
    FormsModule,
    ReactiveFormsModule,
    MatDialogModule,
    MatToolbarModule,
    MatMenuModule,
    MatSlideToggleModule,
    MatCardModule,
    MatTooltipModule,
    MatTabsModule,
    MatSnackBarModule,
    MatDatepickerModule,
    MatNativeDateModule,
    MatPaginatorModule,
    MatExpansionModule,
    MatProgressBarModule,
    NgxMaskModule.forRoot(),
    AgGridModule.withComponents([])
  ],
  providers: [
    SuppliesRepository,
    EquipmentsRepository,
    ProvidersRepository,
    //AuthGuard,
    { provide: MAT_DATE_LOCALE, useValue: 'ru-RU' },
    {
      provide: DateAdapter,
      useClass: MomentDateAdapter,
      deps: [MAT_DATE_LOCALE]
    },
    { provide: MAT_DATE_FORMATS, useValue: MAT_MOMENT_DATE_FORMATS },
    //Loader,
    {
      provide: MatPaginatorIntl,
      useFactory: () => {
        const a = new MatPaginatorIntl();
        a.itemsPerPageLabel = 'Строк на страницу';
        a.nextPageLabel = 'Следующая страница';
        a.previousPageLabel = 'Предыдущая страница';
        a.firstPageLabel = 'Первая страница';
        return a;
      }
    },
    // ErrorService,
    // MessageBox,
    // DownloadBlobService,
    {
      provide: MAT_DIALOG_DEFAULT_OPTIONS,
      useValue: {
        hasBackdrop: true,
        closeOnNavigation: true,
        disableClose: true
      }
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule {}
