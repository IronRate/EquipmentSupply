import { ISupplyItem } from './supplies.service';
import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
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

  getExtended(isRemoved:boolean,dateFrom?:Date,dateTo?:Date){
    let params=new HttpParams().append('isRemoved',isRemoved.toString());
    if(dateFrom){
      params=params.append('dateFrom',dateFrom.toJSON());
    }
    if(dateTo){
      params=params.append('dateTo',dateTo.toJSON());
    }
    return this.http.get<ISupplyItem[]>(this.url, { params });
  }

  getLeaved() {
    let params = new HttpParams().append('isRemoved', 'false');
    return this.http.get<ISupplyItem[]>(this.url, { params });
  }

  getRemoved(){
    let params = new HttpParams().append('isRemoved', 'true');
    return this.http.get<ISupplyItem[]>(this.url, { params });
  }
}
