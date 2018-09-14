import { HttpClient, HttpHeaders } from "@angular/common/http";



export abstract class BackendRepository<TEntity,TKey>{
  private _api:string;
  private _headers:HttpHeaders;

  constructor(protected http:HttpClient,apiAddress:string){
    this._api=apiAddress;
    this._headers = new HttpHeaders({'Content-Type': 'application/json'});
  }

  /**Вернет все записи */
  getAll() {
    return this.http.get<TEntity[]>(this._api);
  }


  getById(id: TKey) {
    return this.http.get<TEntity>(`${this._api}/${id}`);
  }

  /**Удалит поставку по идентификатору */
  remove(id:TKey){
    return this.http.delete(`${this._api}/${id}`);
  }

  /**Добавление поставки */
  add(item:TEntity){
    return this.http.post(this._api,item,{headers:this._headers});
  }

  /**редактирование поставки */
  patch(item:TEntity){
    return this.http.put(`${this._api}/${(<any>item).id}`,item,{headers:this._headers});
  }

}
