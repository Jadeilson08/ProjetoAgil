import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';

import { HttpClientModule } from "@angular/common/http";
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatSliderModule } from '@angular/material/slider';
import { MatToolbarModule } from '@angular/material/toolbar';
import { EventosComponent } from './views/eventos/eventos.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { EventosService } from './services/eventos.service';
import { HeaderComponent } from './views/commons/header/header.component';
import { NovoEventoComponent } from './views/eventos/novo/novo-evento.component';
import { DetailsEventoComponent } from './views/eventos/details-evento/details-evento.component';




@NgModule({
  declarations: [
    AppComponent,
    EventosComponent,
    HeaderComponent,
    NovoEventoComponent,
    DetailsEventoComponent,
    
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
    HttpClientModule,
    BrowserAnimationsModule,
    MatSliderModule,
    MatToolbarModule,
    NgbModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
