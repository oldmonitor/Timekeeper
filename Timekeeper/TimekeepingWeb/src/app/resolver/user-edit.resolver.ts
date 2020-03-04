import {Injectable} from '@angular/core';
import {Resolve, Router, ActivatedRouteSnapshot} from '@angular/router';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { UserService } from '../services/user.service';
import { User } from '../models/user';
import { AlertifyService } from '../services/alertify.service';
import { SecurityService } from '../services/security.service';

/*
Use resolver so load data before the user detail component loads
*/
@Injectable()
export class UserEditResolver implements Resolve<User> {
    constructor(private userService: UserService, private router: Router,
                private alertify: AlertifyService, private securityService: SecurityService) {}

      resolve(route: ActivatedRouteSnapshot): Observable<User> {
        return this.userService.getUser(this.securityService.decodedToken.nameid).pipe(
            catchError(error => {
                this.alertify.error('Problem retrieving data');
                this.router.navigate(['/team']);
                return of(null); // return observable of resolved null
            })
        );
    }
}
