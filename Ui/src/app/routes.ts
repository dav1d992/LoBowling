import { Routes } from '@angular/router';
import { ScoreboardComponent } from './scoreboard/scoreboard.component';

export const appRoutes: Routes = [
  { path: 'scoreboard', component: ScoreboardComponent },
  { path: '**', component: ScoreboardComponent },
  { path: 'scoreboard', redirectTo: 'scoreboard', pathMatch: 'full' },
];
