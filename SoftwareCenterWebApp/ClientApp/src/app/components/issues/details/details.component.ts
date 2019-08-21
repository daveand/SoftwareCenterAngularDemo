import { Component, OnInit } from '@angular/core';
import { Customer } from '../../../models/customer.model';
import { Router, ActivatedRoute } from '@angular/router';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material';
import { IssueService } from '../../../services/issue.service';

@Component({
  selector: 'app-issuedetails',
  templateUrl: './details.component.html',
  styleUrls: ['./details.component.css']
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
        console.log(this.issue);
      });
    });
  }


}
