import { IProviderItem } from './providers.servise';
import { IEquipmentItem } from './equipment.service';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

export interface IEquipmentReportItem{
  equipmentType:IEquipmentItem,
  count:number
}

export interface IProviderReportItem{
  provider:IProviderItem,
  percentage:number;
}

@Injectable()
export class ReportsService{
  constructor(private httpClient:HttpClient){

  }

  getEquipmentsReport(providerId:number){
    return this.httpClient.get<IEquipmentReportItem[]>(`/api/reports/providers/${providerId}/equipments`);
  }

  getProvidersReport(){
    return this.httpClient.get<IProviderReportItem[]>(`/api/reports/providers`);
  }
}
