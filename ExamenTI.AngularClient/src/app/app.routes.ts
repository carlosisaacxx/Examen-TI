import { Routes } from '@angular/router';

export const routes: Routes = [
    {
        path: '',
        loadChildren: () => import('./pages/auth/auth.routes').then(m => m.AUTH_ROUTES), /*No olvidar que AUTH_ROUTES es la llamada al constructor */
    },
    {
        path: 'dashboard',
        loadChildren: () => import('./pages/admin/admin.routes').then(m => m.ADMIN_ROUTES),
    }
];
