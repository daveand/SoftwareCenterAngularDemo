import { Component, ViewChild } from '@angular/core';
import { MatSidenav } from '@angular/material/sidenav';

import { faCaretRight } from '@fortawesome/free-solid-svg-icons';
import { faCaretLeft } from '@fortawesome/free-solid-svg-icons';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  @ViewChild('sidenav', { static: false }) sidenav: MatSidenav;
  title = 'ClientApp';

  faCaretRight = faCaretRight;
  faCaretLeft = faCaretLeft;

  // tslint:disable-next-line: only-arrow-functions

  navOpen = false;

  open() {
    this.navOpen = false;
    this.sidenav.open();
  }

  close() {
    this.navOpen = true;
    this.sidenav.close();
  }

}
