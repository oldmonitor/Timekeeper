import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { TeamComponent } from './components/team/team.component';
import { TimesheetComponent } from './components/timesheet/timesheet.component';
import { UserMessagesComponent } from './components/user-messages/user-messages.component';


export const appRoutes: Routes = [
  { path: 'home', component: HomeComponent },
  { path: 'team', component: TeamComponent },
  { path: 'timesheet', component: TimesheetComponent},
  { path: 'messages', component: UserMessagesComponent},
  { path: '**', redirectTo: 'home', pathMatch: 'full'}
];
