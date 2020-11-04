import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { GeralConfig } from "../../shared/geral-config.enum";
import { Observable } from 'rxjs';
import { Evento } from './Evento';

@Injectable({
  providedIn: 'root'
})
export class EventosService {

  private eventos = "Eventos/";

  constructor(private httpclient: HttpClient) { }

  getEventos():Observable<Evento>{
    return this.httpclient.get<Evento>(GeralConfig.api+this.eventos)
  }
}
