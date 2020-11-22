import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { DetailsEventoComponent } from './views/eventos/details-evento/details-evento.component';
import { EventosComponent } from "./views/eventos/eventos.component";
import { NovoEventoComponent } from './views/eventos/novo/novo-evento.component';

const routes: Routes = [
  { path: '', component: EventosComponent },
  { path: 'eventos/novo', component: NovoEventoComponent },
  { path: 'eventos/details/:id', component: DetailsEventoComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
