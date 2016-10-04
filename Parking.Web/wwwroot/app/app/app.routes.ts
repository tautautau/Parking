import { ModuleWithProviders } from '@angular/core'; 
import { Routes, RouterModule }  from '@angular/router';
// import { PageNotFoundComponent } from '../page-not-found/page-not-found.component'
const routes: Routes = [
    { path: '', redirectTo: 'main-page', pathMatch: 'full' },
    // lazy loading example
    { path: 'main-page', loadChildren: 'app/main-page/main-page.module#MainPageModule' },
    // loading component example
    // { path: '**', PageNotFoundComponent } black hole
];

export const appRoutingProviders: any[] = [

];

export const routing: ModuleWithProviders = RouterModule.forRoot(routes, { useHash: true });