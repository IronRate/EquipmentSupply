
import { BackendRepository } from "../../classes/backend.service";
import { HttpClient, HttpParams } from "@angular/common/http";
import { Injectable } from "@angular/core";

export interface IProviderItem{
  id:string;
  name:string;
  address:string;
  email:string;
  phone:string;
}

/**Поставщики оборудования */
@Injectable()
export class ProvidersRepository extends BackendRepository<IProviderItem,string>{
  constructor(http:HttpClient){
    super(http,'/api/providers');
  }

  /**Поиск поствщика по имени */
  find(name:string){
    const p=new HttpParams().append('name',name);
    return this.http.get<IProviderItem[]>(this.url+'/find',{params:p})
  }
}
