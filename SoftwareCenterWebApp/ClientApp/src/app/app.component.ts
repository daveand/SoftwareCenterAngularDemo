import { environment } from './../environments/environment';
import { AdalService } from 'adal-angular4';
import { Component, ViewChild } from '@angular/core';
import { Router } from '@angular/router';

import { MatSidenav } from '@angular/material/sidenav';
import { faCaretRight } from '@fortawesome/free-solid-svg-icons';
import { faCaretLeft } from '@fortawesome/free-solid-svg-icons';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {


  constructor(private adalService: AdalService, private router: Router ) {
    this.router = router;
    adalService.init(environment.authConfig);

  }

  ngOnInit() {
    // Handle callback if this is a redirect from Azure
    this.adalService.handleWindowCallback();
    this.adalService.getUser();

    if (!this.adalService.userInfo.authenticated) {
      this.adalService.login(); //redirects to company AD url
    } else if (this.adalService.userInfo.authenticated) {
      console.log("Logged in");
      console.log(this.adalService.userInfo.userName);
    } 
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
