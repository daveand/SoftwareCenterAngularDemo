import { Component, OnInit } from '@angular/core';
import { Customer } from '../../customer.model';
import { Router, ActivatedRoute } from '@angular/router';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material';
import { IssueService } from '../../issue.service';
import { Issue } from '../../issue.model';

@Component({
  selector: 'app-edit',
  templateUrl: './edit.component.html',
  styleUrls: ['./edit.component.css']
})
export class EditComponent implements OnInit {

  customers: Customer[];

  id: string;
  issue: any = {};
  updateForm: FormGroup;
  severeties = ['Low', 'Medium', 'High'];
  statuses = ['Open', 'In Progress', 'Closed'];

  constructor(
    private issueService: IssueService,
    private router: Router,
    private route: ActivatedRoute,
    private snackBar: MatSnackBar,
    private fb: FormBuilder) {
      this.createForm();
    }

  createForm() {
    this.updateForm = this.fb.group({
      title: ['', Validators.required],
      responsible: ['', Validators.required],
      customer: ['', Validators.required],
      description: ['', Validators.required],
      severity: ['', Validators.required],
      status: ['', Validators.required]
    });
  }

  fetchCustomers() {
    this.issueService
      .getCustomers()
      .subscribe((data: Customer[]) => {
        this.customers = data;
        console.log('Data requested...');
        console.log(this.customers);
      });
  }

  ngOnInit() {
    this.fetchCustomers();
    this.route.params.subscribe(params => {
      this.id = params.id;
      this.issueService.getIssueById(this.id).subscribe(res => {
        this.issue = res;
        this.updateForm.get('title').setValue(this.issue.title);
        this.updateForm.get('responsible').setValue(this.issue.responsible);
        this.updateForm.get('customer').setValue(this.issue.customer);
        this.updateForm.get('description').setValue(this.issue.description);
        this.updateForm.get('severity').setValue(this.issue.severity);
        this.updateForm.get('status').setValue(this.issue.status);
      });
    });
  }

  updateIssue(title, responsible, customer, description, severity, status) {
    if (!customer) {
      customer = this.issue.customer;
    }
    if (!severity) {
      severity = this.issue.severity;
    }
    if (!status) {
      status = this.issue.status;
    }
    console.log(customer);
    this.issueService.updateIssue(this.id, title, responsible, customer, description, severity, status).subscribe(() => {
      this.snackBar.open('Issue updated successfully', 'OK', {
        duration: 3000
      });
      this.router.navigate(['/issues']);
    });
  }
}
