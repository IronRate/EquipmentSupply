import { Component, OnInit, ViewChild } from '@angular/core';
import { GridOptions } from 'ag-grid/dist/lib/entities/gridOptions';
import { MatPaginator } from '@angular/material';
import { AgGridNg2 } from 'ag-grid-angular';
import { RowNode } from 'ag-grid/dist/lib/entities/rowNode';


@Component({
  selector: 'app-equipments-grid',
  templateUrl: './equipments-grid.component.html',
  styleUrls: ['./equipments-grid.component.css']
})
export class EquipmentsGridComponent implements OnInit {
  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(AgGridNg2) agGrid: AgGridNg2;

  columnDefs: any[];
  gridOptions: GridOptions;
  private selectedGridRow: RowNode;

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
