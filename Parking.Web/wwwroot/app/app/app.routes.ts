import { ModuleWithProviders } from '@angular/core'; 
import { Routes, RouterModule }  from '@angular/router';

const routes: Routes = [
    { path: '', redirectTo: 'main-page', pathMatch: 'full' },
    { path: 'main-page', loadChildren: 'app/main-page/main-page.module' },
    // { path: 'my-approvals', loadChildren: 'app/my-approvals/my-approvals.module#MyApprovalsModule' },
    // { path: 'secondary-approvals', loadChildren: 'app/secondary-approvals/secondary-approvals.module#SecondaryApprovalsModule' },
    // { path: 'categories', loadChildren: 'app/category/category.module#CategoryModule' },
    // { path: 'sub-categories', loadChildren: 'app/sub-category/sub-category.module#SubCategoryModule' },
    // { path: 'items', loadChildren: 'app/item/item.module#ItemModule' },
    // { path: 'executors', loadChildren: 'app/executor/executor.module#ExecutorModule' },
    // { path: 'additional-fields', loadChildren: 'app/additional-field/additional-field.module#AdditionalFieldModule' }, 
    // { path: 'bundles', loadChildren: 'app/bundle/bundle.module#BundleModule' }, 
    // { path: 'statuses', loadChildren: 'app/status/status.module#StatusModule' }, 
    // { path: 'all-items', loadChildren: 'app/all-items/all-items.module#AllItemsModule' } 
];

export const appRoutingProviders: any[] = [

];

export const routing: ModuleWithProviders = RouterModule.forRoot(routes);
//export const routing: ModuleWithProviders = RouterModule.forRoot(routes, { useHash: true });