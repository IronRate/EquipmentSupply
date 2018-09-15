import { BackendRepository } from '../../classes/backend.service';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';

export interface IEquipmentItem {
  id: string;
  name: string;
}

/**Типы оборудования*/
@Injectable()
export class EquipmentsRepository extends BackendRepository<
  IEquipmentItem,
  string
> {
  constructor(http: HttpClient) {
    super(http, '/api/equipments');
  }

  find(name: string) {
    let p = new HttpParams().append('name', name);
    return this.http.get<IEquipmentItem[]>(this.url + '/find', { params: p });
  }
}
