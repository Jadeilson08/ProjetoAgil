import { Component, OnInit } from '@angular/core';
import { Evento } from "./Evento";
import { EventosService } from "./eventos.service";

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.scss']
})
export class EventosComponent implements OnInit {

  eventos: Evento;

  constructor(private eventoservice: EventosService) { }

  ngOnInit() {
    this.eventoservice.getEventos().subscribe(
      data => {
        this.eventos = data;
        console.log(data);
        
      },
      error =>{
        console.log(error);
      }
    )
  }

}
