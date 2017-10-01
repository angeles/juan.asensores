import { ModuleWithProviders } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { UserComponent } from './Components/user.component';
import { PolicyComponent } from './Components/policy.component';
import { LoginComponent } from './Components/login.component';
import { AuthGuard } from './Guards/auth.guard';

const appRoutes: Routes = [
	{ path: '', redirectTo: 'user', pathMatch: 'full' },
	{ path: 'user', component: UserComponent, canActivate: [AuthGuard] },
	{ path: 'policy', component: PolicyComponent, canActivate: [AuthGuard] },
	{ path: 'auth', component: LoginComponent }
];

export const routing: ModuleWithProviders = RouterModule.forRoot(appRoutes);