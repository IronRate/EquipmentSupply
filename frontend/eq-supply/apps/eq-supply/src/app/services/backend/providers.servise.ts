
import { BackendRepository } from "../../classes/backend.service";
import { HttpClient } from "@angular/common/http";
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
}
