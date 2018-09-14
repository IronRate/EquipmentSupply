import { Component, OnInit, ViewChild, Output } from '@angular/core';
import { GridOptions } from 'ag-grid/dist/lib/entities/gridOptions';
import { MatPaginator } from '@angular/material';
import { AgGridNg2 } from 'ag-grid-angular';
import { RowNode } from 'ag-grid/dist/lib/entities/rowNode';
import { DatePipe } from '@angular/common';
import { Subject } from 'rxjs/Subject';

@Component({
  selector: 'app-providers-grid',
  templateUrl: './providers-grid.component.html',
  styleUrls: ['./providers-grid.component.css']
})
export class ProvidersGridComponent implements OnInit {
  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(AgGridNg2) agGrid: AgGridNg2;

  columnDefs: any[];
  gridOptions: GridOptions;
  private selectedGridRow: RowNode;

  @Output() rowSelect:Subject<RowNode>=new Subject();

  constructor() {}

  ngOnInit() {
    this.initGrid();
  }

  private createColumnDefs() {
    const columnDefs = [
      {
        headerName: '№ п/п',
        field: 'id',
        width: 50,
        suppressFilter: true
      },
      {
        headerName: 'Наименование',
        suppressSizeToFit: true,
        field: 'name',
        cellRenderer: params => {
          return `<a>${params.value}</a>`;
        },
        // filterFramework: AgTextFilterComponent,
        // filterParams: { placeholder: 'Организация' },
        suppressSorting: true
      },
      {
        headerName: 'Адрес',
        field: 'address',
        width: 100,
        // filterFramework: AgTextFilterComponent,
        // filterParams: { placeholder: "ИНН", pattern: /^(\d{10}|00\d{10})&/, maxLength: 12, minLength: 10 },
        suppressSorting: true
      },
      {
        headerName: 'Телефон',
        field: 'phone',
        width: 100,
        //filterFramework: AgTextFilterComponent,
        filterParams: { placeholder: 'Телефон' },
        suppressSorting: true
      },
      {
        headerName: 'Email',
        field: 'notificationEmail',
        cellRenderer: params => {
          return `<a>${params.value}</a>`;
        },
        width: 100,
        //filterFramework: AgTextFilterComponent,
        filterParams: { placeholder: 'Email' },
        suppressSorting: true
      }
    ];
    return columnDefs;
  }

  private initGrid() {
    this.columnDefs = this.createColumnDefs();
    this.gridOptions = this.initGridOptions();
  }

  private initGridOptions() {
    return <GridOptions>{
      enableServerSideSorting: true,
      enableServerSideFilter: true,
      sortingOrder: ['desc', 'asc'],
      onGridReady: () => {
        this.gridOptions.api.sizeColumnsToFit();
        this.gridOptions.api.setSortModel([{ colId: 'id', sort: 'desc' }]);
      },
      onCellClicked: params => {
        this.rowSelect.next(params.node);
        // this.selectedGridRow = params.node;
        // switch (params.colDef.field) {
        //   case 'organization':
        //     this.itemOpen(this.selectedGridRow.data, 0);
        //     break;
        //   case 'stateName':
        //     this.itemOpen(this.selectedGridRow.data, 1);
        //     break;
        //   case 'notificationEmail':
        //     this.openEmailSender(this.selectedGridRow.data);
        //     break;
        // }
      },
      onSortChanged: params => {
        //this.fetch();
      },
      onFilterChanged: params => {
        //this.fetch();
      },
      getRowClass: params => {
        switch (params.data.state) {
          case 0:
            return 'certificate wait-documents';
          case 1:
            return 'certificate accepted';
          case 2:
            return 'certificate rejected';
          case 3:
            return 'certificate overdue';
          case 4:
            return 'certificate complete';
          case 5:
            return 'certificate bounded';
          case 6:
            return 'certificate debtour';
        }
      }
    };
  }
}
