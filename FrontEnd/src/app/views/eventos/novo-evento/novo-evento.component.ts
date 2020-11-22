import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router } from "@angular/router";
import { EventosService } from 'src/app/services/eventos.service';
import { Evento } from '../../../models/Evento';
import Swal from 'sweetalert2'

@Component({
  selector: 'app-novo-evento',
  templateUrl: './novo-evento.component.html',
  styleUrls: ['./novo-evento.component.css']
})
export class NovoEventoComponent implements OnInit {

  public formNovoEvento: FormGroup;
  
  private evento: Evento;

  private file: File;

  constructor(private fb: FormBuilder,
              private router: Router,
              private eventoService: EventosService) { }

  ngOnInit(): void {
    this.initForm(new Evento());
  }

  private initForm(evento: Evento){
    this.formNovoEvento = this.fb.group({
      local: [evento.local, [Validators.required, Validators.minLength(5)]],
      dataEvento: [evento.dataEvento, [Validators.required]],
      tema: [evento.tema, [Validators.required, Validators.minLength(3)]],
      qtdPessoas: [evento.qtdPessoas, [Validators.required, Validators.min(2)]],
      lote: [evento.lote, [Validators.required]],
      imagem: [evento.imagem],
    })
  }

  onFileChange(event){
    const reader = new FileReader();
    if(event.target.files && event.target.files.length){
      this.file = event.target.files;
      console.log(this.file);
      
    }
    
  }


  public onSubmit (){
    if(this.formNovoEvento.valid){
      this.evento = Object.assign({}, this.formNovoEvento.value);

      this.eventoService.postUpload(this.file).subscribe();

      const nomeFoto = this.evento.imagem.split("\\", 3);

      this.evento.imagem = nomeFoto[2];

      this.eventoService.postEvento(this.evento).subscribe(
        (data) => {
          Swal.fire({
            icon: 'success',
            title: 'Evento Salvo',
            showConfirmButton: false,
            timer: 1500
          })
        }, error => console.log(error)
        
      );
    }
    this.voltar();
  }

  public voltar(){
    this.router.navigate([''])
  }

}
