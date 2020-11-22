import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from "@angular/router";
import { Evento } from 'src/app/models/Evento';
import { EventosService } from 'src/app/services/eventos.service';

@Component({
  selector: 'app-details-evento',
  templateUrl: './details-evento.component.html',
  styleUrls: ['./details-evento.component.css']
})
export class DetailsEventoComponent implements OnInit {

  public evento: Evento;
  constructor(private eventoService: EventosService,
              private route: ActivatedRoute) { }

  ngOnInit(): void {    
    this.eventoService.getById(this.route.snapshot.params['id']).subscribe(
      (data) => {
        this.evento = data
        console.log(this.evento);
        
      },
      (error) => console.log(error)
    )
  }

}
