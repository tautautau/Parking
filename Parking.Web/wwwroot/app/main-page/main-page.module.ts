import { NgModule }      from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { routing, appRoutingProviders } from './main-page.routes'
import { MainPageComponent }   from './main-page.component';
@NgModule({
  imports:      [ BrowserModule, routing ],
  declarations: [ MainPageComponent ],
  providers: [ appRoutingProviders ],
  bootstrap:    [ MainPageComponent ]
})
export class MainPageModule { }
