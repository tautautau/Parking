import { ModuleWithProviders } from '@angular/core'; 
import { Routes, RouterModule }  from '@angular/router';
import { MainPageComponent } from './main-page.component';

const routes: Routes = [ 
    { path: '', component: MainPageComponent } 
];

export const appRoutingProviders: any[] = [

];

export const routing: ModuleWithProviders = RouterModule.forChild(routes);