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
import { UserEditComponent } from './components/team/user-edit/user-edit.component';
import { UserEditResolver } from './resolver/user-edit.resolver';
import { PreventUnsavedChanges } from './guards/prevent-unsaved.guard';

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
        { path: 'user/edit', component: UserEditComponent, resolve: {user: UserEditResolver}, canDeactivate: [PreventUnsavedChanges]},
      ]
  },
  { path: '**', redirectTo: '', pathMatch: 'full'}
];
