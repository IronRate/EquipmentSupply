import { AgPeriodsFilterComponent } from './../ag-periods-filter/ag-periods-filter.component';
import { DatePipe } from '@angular/common';
import { Component, OnInit, Input, Output } from '@angular/core';
import { ISupplyItem } from '../../services/backend/supplies.service';
import { Subject } from 'rxjs/Subject';
import { RowNode, GridOptions } from 'ag-grid';

@Component({
  selector: 'app-supplies-grid',
  templateUrl: './supplies-grid.component.html',
  styleUrls: ['./supplies-grid.component.css'],
  providers: [DatePipe]
})
export class SuppliesGridComponent implements OnInit {
  @Input() data: ISupplyItem[];
  @Output() rowSelect: Subject<RowNode> = new Subject();
  @Output() filterChanged: Subject<any> = new Subject();

  columnDefs: any[];
  gridOptions: GridOptions;
  private selectedGridRow: RowNode;

  constructor(private datePipe: DatePipe) {}

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
        headerName: 'Дата поставки',
        field: 'provideDate',
        cellRenderer: params => {
          return this.datePipe.transform(params.value, 'dd.MM.yyyy');
        },
        filterFramework: AgPeriodsFilterComponent
      },
      {
        headerName: 'Поставщик',
        suppressSizeToFit: true,
        field: 'provider.name',
        suppressSorting: true,
        suppressFilter: true
      },
      {
        headerName: 'Вид оборудования',
        field: 'equipmentType.name',
        width: 100,
        suppressSorting: true,
        suppressFilter: true
      },
      {
        headerName: 'Количество',
        field: 'count',
        width: 100,
        suppressSorting: true,
        suppressFilter: true
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
        const filter: any =
          this.gridOptions && this.gridOptions.api
            ? this.gridOptions.api.getFilterModel()
            : undefined;
        this.filterChanged.next(filter);
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
