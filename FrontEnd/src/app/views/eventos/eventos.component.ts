import { Component, OnInit } from '@angular/core';
import { Evento } from "../../models/Evento";
import { EventosService } from "../../services/eventos.service";

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.css']
})
export class EventosComponent implements OnInit {

  eventos: Evento;

  constructor(private eventoservice: EventosService) { }

  ngOnInit() {
    this.eventoservice.getEventos().subscribe(
      data => {
        this.eventos = data;
      },
      error =>{
        console.log(error);
      }
    )
  }
}
