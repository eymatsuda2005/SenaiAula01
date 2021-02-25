import { Injectable } from '@angular/core';
import { ChildActivationEnd } from '@angular/router';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Cidade } from '../models/Cidade';
import {HttpClient} from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class CidadesService {
  baseURL = `${environment.mainUrlApi}cidade`;
  constructor(private http: HttpClient) { }
  getAll(): Observable<Cidade[]>{
    return this.http.get<Cidade[]>(this.baseURL)
  }

  getById(id: number): Observable<Cidade>{
    return this.http.get<Cidade>(`${this.baseURL}${id}`);
  }
   add(cidade: Cidade){
     return this.http.post(this.baseURL, cidade)
   }
   edit(cidade: Cidade){
     return this.http.put(`${this.baseURL}/${cidade.id}`, cidade);
   }
  
   delete(id:number){
     return this.http.delete(`${this.baseURL}/${id}`);
   }

}
