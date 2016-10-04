import { NgModule }      from '@angular/core'
import { routing, appRoutingProviders } from './main-page.routes'
import { MainPageComponent }   from './main-page.component';

@NgModule({
  imports:      [ routing ],
  declarations: [ MainPageComponent ],
  providers: [ appRoutingProviders ],
  bootstrap:    [ MainPageComponent ]
})
export class MainPageModule { }
