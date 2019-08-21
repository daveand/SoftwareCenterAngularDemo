import { environment } from './../environments/environment';
import { AdalService } from 'adal-angular4';
import { Component, ViewChild } from '@angular/core';
import { Router, NavigationStart } from '@angular/router';
import { Event as NavigationEvent } from "@angular/router";
import { UsersService } from './services/users.service';
import { User } from './models/user.model';
import { filter } from "rxjs/operators";
import { MatSidenav } from '@angular/material/sidenav';
import { faCaretRight } from '@fortawesome/free-solid-svg-icons';
import { faCaretLeft } from '@fortawesome/free-solid-svg-icons';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {

  routes: any[];

  constructor(
    private usersService: UsersService,
    private adalService: AdalService,
    private router: Router) {

    this.router = router;
    adalService.init(environment.authConfig);


    router.events
      .pipe(
        filter(
          (event: NavigationEvent) => {

            return (event instanceof NavigationStart);

          }
        )
      )
      .subscribe(
        (event: NavigationStart) => {

          console.group("NavigationStart Event");
          console.log("navigation id:", event.id);
          console.log("route:", event.url);
          console.log("trigger:", event.navigationTrigger);

          // this.routes.push(event.url);

          if (event.restoredState) {

            console.warn(
              "restoring navigation id:",
              event.restoredState.navigationId
            );

          }

          console.groupEnd();

        }
      )
      ;
  }

  users: User[];

  role: string;

  ngOnInit() {
    // Handle callback if this is a redirect from Azure
    this.adalService.handleWindowCallback();
    this.adalService.getUser();

    if (this.adalService.userInfo.profile.groups == '06601050-563e-47b4-a0cc-13377f9ddfea') {
      this.role = 'Admin';
    }

    if (!this.adalService.userInfo.authenticated) {
      this.adalService.login(); //redirects to company AD url
    } else if (this.adalService.userInfo.authenticated) {
      this.addUserToDb();
      console.log("Logged in");
      console.log(this.adalService.userInfo.profile.name);
      console.log(this.adalService.userInfo.userName);
      console.log(this.adalService.userInfo.profile.groups);
    }

    } 


  addUserToDb() {
    this.usersService
      .getUsers()
      .subscribe((data: User[]) => {
        this.users = data;
        console.log('Users in DB:');
        console.log(data);

        let userAlreadyExist = this.users.find(user => user.Email === this.adalService.userInfo.userName);
        if (!userAlreadyExist) {
          var name = this.adalService.userInfo.profile.name;
          var email = this.adalService.userInfo.userName;
          var group = this.adalService.userInfo.profile.groups[0];
          console.log('User added to DB');
          this.usersService.addUser(name, email, group).subscribe(() => {
          });
        } else {
          console.log('User already in DB');
        }
      });
  }


  @ViewChild('sidenav', { static: false }) sidenav: MatSidenav;
  title = 'ClientApp';

  faCaretRight = faCaretRight;
  faCaretLeft = faCaretLeft;

  // tslint:disable-next-line: only-arrow-functions

  navOpen = false;

  logOut() {
    this.adalService.logOut();
  }

  open() {
    this.navOpen = false;
    this.sidenav.open();
  }

  close() {
    this.navOpen = true;
    this.sidenav.close();
  }

}
