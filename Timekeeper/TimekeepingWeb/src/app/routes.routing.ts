import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { TeamComponent } from './components/team/team.component';
import { TimesheetComponent } from './components/timesheet/timesheet.component';
import { UserMessagesComponent } from './components/user-messages/user-messages.component';
import { AuthGuard } from './guards/auth.guard';
import { ValueComponent } from './components/value/value.component';

export const appRoutes: Routes = [
  {path: '', component: HomeComponent},
  {
      path: '',
      runGuardsAndResolvers: 'always',
      canActivate: [AuthGuard],
      children: [
        { path: 'team', component: TeamComponent},
        { path: 'timesheet', component: TimesheetComponent},
        { path: 'messages', component: UserMessagesComponent},
        { path: 'values', component: ValueComponent},
      ]
  },
  { path: '**', redirectTo: '', pathMatch: 'full'}
];
