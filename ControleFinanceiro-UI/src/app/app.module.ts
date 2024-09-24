import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { TiposService } from './services/tipos.service';
import { CategoriasService } from './services/categorias.service';



@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [
    TiposService, 
    CategoriasService,
    HttpClientModule
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
