import { Component, OnInit } from '@angular/core';
import { SecurityService } from 'src/app/services/security.service';
import { AlertifyService } from 'src/app/services/alertify.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {

  // model for storing username and password
  model: any = {};
  constructor(public authService: SecurityService, private alertify: AlertifyService, private router: Router) { }

  ngOnInit() {
  }

  login() {
    this.authService.login(this.model).subscribe(next => {
      this.alertify.success('Logged in successfully');
    }, error => {
      console.error(error);
    }, () => {
      this.router.navigate(['/timesheet']);
    });
  }

  loggedIn() {
    return this.authService.loggedIn();
  }

  logout() {
    localStorage.removeItem('token');
    this.alertify.success('logged out');
    this.router.navigate(['/home']);
  }

}
