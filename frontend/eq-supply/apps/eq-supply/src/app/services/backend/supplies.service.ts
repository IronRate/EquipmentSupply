import { ISupplyItem } from './supplies.service';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BackendRepository } from '../../classes/backend.service';

/**Поставка */
export interface ISupplyItem {
  id: string;
  providerId: string;
  equpmentTypeId: string;
  provideDate: Date;
}

/**Поставки */
@Injectable()
export class SuppliesRepository extends BackendRepository<ISupplyItem, string> {
  constructor(http: HttpClient) {
    super(http, 'api/supplies');
  }
}
