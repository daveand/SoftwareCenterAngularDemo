import { Component, OnInit } from '@angular/core';
import { Customer } from '../../customer.model';
import { Router, ActivatedRoute } from '@angular/router';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material';
import { IssueService } from '../../issue.service';

@Component({
  selector: 'app-issuedetails',
  templateUrl: './issuedetails.component.html',
  styleUrls: ['./issuedetails.component.css']
})
export class IssuedetailsComponent implements OnInit {

  customers: Customer[];
  id: string;
  issue: any = {};

  constructor(
    private issueService: IssueService,
    private router: Router,
    private route: ActivatedRoute) { }

  ngOnInit() {
    this.route.params.subscribe(params => {
      this.id = params.id;
      this.issueService.getIssueById(this.id).subscribe(res => {
        this.issue = res;
      });
    });
  }


}
