import { environment } from './../environments/environment';
import { AdalService } from 'adal-angular4';
import { Component, ViewChild, HostListener } from '@angular/core';
import { Router, NavigationStart } from '@angular/router';
import { UsersService } from './services/users.service';
import { User } from './models/user.model';
import { MatSidenav } from '@angular/material/sidenav';
import { faCaretRight } from '@fortawesome/free-solid-svg-icons';
import { faCaretLeft } from '@fortawesome/free-solid-svg-icons';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {

  constructor(
    private usersService: UsersService,
    private adalService: AdalService,
    private router: Router) {
    this.router = router;
    adalService.init(environment.authConfig);

  }

  users: User[];

  role: string;

  mobile: boolean;

  @HostListener("window:resize", [])
  onResize() {
    var width = window.innerWidth;
    if (width < 992) {
      this.mobile = true;
    } else {
      this.mobile = false;
    }
  }

  ngOnInit() {
    // Handle callback if this is a redirect from Azure
    //this.adalService.handleWindowCallback();
    //this.adalService.getUser();

    //if (this.adalService.userInfo.profile.groups == '06601050-563e-47b4-a0cc-13377f9ddfea') {
    //  this.role = 'Admin';
    //}
    //if (this.adalService.userInfo.profile.groups == '56b8f386-90bc-48e5-a430-52f02fd9a6ce') {
    //  this.role = 'SW Technician';
    //}
    //if (this.adalService.userInfo.profile.groups == 'fef123e3-d91f-4d63-88d8-0b07154df185') {
    //  this.role = 'Technician';
    //}


    //if (!this.adalService.userInfo.authenticated) {
    //  this.adalService.login(); //redirects to company AD url
    //} else if (this.adalService.userInfo.authenticated) {
    //  this.addUserToDb();
    //  console.log("Logged in");
    //  console.log(this.adalService.userInfo.profile.name);
    //  console.log(this.adalService.userInfo.userName);
    //  console.log(this.adalService.userInfo.profile.groups);
    //}

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
