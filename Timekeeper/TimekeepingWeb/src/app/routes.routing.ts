import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { TeamComponent } from './components/team/team.component';
import { TimesheetComponent } from './components/timesheet/timesheet.component';
import { UserMessagesComponent } from './components/user-messages/user-messages.component';
import { AuthGuard } from './guards/auth.guard';
import { ValueComponent } from './components/value/value.component';
import { UserDetailComponent } from './components/team/user-detail/user-detail.component';
import { UserDetailResolver } from './resolver/user-detail.resolver';
import { UserListResolver } from './resolver/user-list.resolver';

export const appRoutes: Routes = [
  {path: '', component: HomeComponent},
  {
      path: '',
      runGuardsAndResolvers: 'always',
      canActivate: [AuthGuard],
      children: [
        { path: 'team', component: TeamComponent, resolve: {users: UserListResolver}},
        { path: 'team/:id', component: UserDetailComponent, resolve: {user: UserDetailResolver}},
        { path: 'timesheet', component: TimesheetComponent},
        { path: 'messages', component: UserMessagesComponent},
        { path: 'values', component: ValueComponent},
      ]
  },
  { path: '**', redirectTo: '', pathMatch: 'full'}
];
