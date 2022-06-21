import { Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';

export const appRoutes: Routes = [
  { path: 'home', component: HomeComponent },
  { path: '**', component: HomeComponent },
  { path: 'home', redirectTo: 'home', pathMatch: 'full' }, //Denne skal være i bunden
];
