import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { EventosComponent } from "./views/eventos/eventos.component";
import { NovoEventoComponent } from './views/eventos/novo-evento/novo-evento.component';

const routes: Routes = [
  { path: '', component: EventosComponent },
  { path: 'eventos/novo', component: NovoEventoComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
