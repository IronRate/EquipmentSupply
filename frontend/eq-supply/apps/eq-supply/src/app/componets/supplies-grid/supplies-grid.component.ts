import { Component, OnInit, Input, Output } from '@angular/core';
import { ISupplyItem } from '../../services/backend/supplies.service';
import { Subject } from 'rxjs/Subject';
import { RowNode, GridOptions } from 'ag-grid';

@Component({
  selector: 'app-supplies-grid',
  templateUrl: './supplies-grid.component.html',
  styleUrls: ['./supplies-grid.component.css']
})
export class SuppliesGridComponent implements OnInit {
  @Input() data: ISupplyItem[];
  @Output() rowSelect: Subject<RowNode> = new Subject();

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
        headerName: 'Поставщик',
        suppressSizeToFit: true,
        field: 'provider.name',
        // cellRenderer: params => {
        //   return `<a>${params.value}</a>`;
        // },
        // filterFramework: AgTextFilterComponent,
        // filterParams: { placeholder: 'Организация' },
        suppressSorting: true
      },
      {
        headerName: 'Вид оборудования',
        field: 'equipmentType.name',
        width: 100,
        // filterFramework: AgTextFilterComponent,
        // filterParams: { placeholder: "ИНН", pattern: /^(\d{10}|00\d{10})&/, maxLength: 12, minLength: 10 },
        suppressSorting: true
      },
      {
        headerName: 'Количество',
        field: 'count',
        width: 100,
        //filterFramework: AgTextFilterComponent,
        //filterParams: { placeholder: 'Телефон' },
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
