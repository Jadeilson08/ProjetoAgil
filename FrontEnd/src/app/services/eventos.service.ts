import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { GeralConfig } from "../shared/geral-config.enum";
import { Observable } from 'rxjs';
import { Evento } from '../models/Evento';

@Injectable({
  providedIn: 'root'
})
export class EventosService {

  private eventos = "eventos/";

  constructor(private httpclient: HttpClient) { 
  }

  getEventos():Observable<Evento>{
    return this.httpclient.get<Evento>(GeralConfig.api+this.eventos)
  }

  postEvento(evento: Evento) : Observable<Evento>{
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
      })
    };    
    return this.httpclient.post<Evento>(`${GeralConfig.api+this.eventos}save`, evento, httpOptions);
  }
  postUpload(file: File){
    const fileToUpload = <File>file[0];
    const formData = new FormData();
    formData.append('file', fileToUpload, fileToUpload.name);
    return this.httpclient.post(`${GeralConfig.api}${this.eventos}upload`, formData);
  }
}
