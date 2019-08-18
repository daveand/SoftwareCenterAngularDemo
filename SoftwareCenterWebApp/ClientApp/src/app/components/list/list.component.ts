import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { Issue } from '../../issue.model';
import { IssueService } from '../../issue.service';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.css']
})
export class ListComponent implements OnInit {

  issues: Issue[];
  displayedColumns = ['title', 'responsible', 'customer', 'severity', 'status', 'actions'];


  constructor(private issueService: IssueService, private router: Router) { }

  ngOnInit() {
    this.fetchIssues();
  }

  fetchIssues() {
    this.issueService
      .getIssues()
      .subscribe((data: Issue[]) => {
        this.issues = data;
        console.log('Data requested...');
        console.log(this.issues);
      });
  }

  detailsIssue(id) {
    this.router.navigate([`/issuedetails/${id}`], { skipLocationChange: true });
  }

  editIssue(id) {
    this.router.navigate([`/edit/${id}`], { skipLocationChange: true });
  }

  deleteIssue(id) {
    this.issueService
      .deleteIssue(id)
      .subscribe(() => {
        this.fetchIssues();
      });
  }

}
