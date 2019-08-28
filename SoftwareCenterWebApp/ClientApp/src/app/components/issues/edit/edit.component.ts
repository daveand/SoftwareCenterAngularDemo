import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material';
import { IssueService } from '../../../services/issue.service';
import { CustomerService } from '../../../services/customer.service';
import { UsersService } from '../../../services/users.service';

import { Issue } from '../../../models/issue.model';
import { User } from '../../../models/user.model';
import { Customer } from '../../../models/customer.model';

@Component({
  selector: 'app-issuesedit',
  templateUrl: './edit.component.html',
  styleUrls: ['./edit.component.css']
})
export class IssuesEditComponent implements OnInit {

  customers: Customer[];
  users: User[];

  id: string;
  issue: any = {};
  updateForm: FormGroup;
  priorities = ['Low', 'Medium', 'High', 'Critical'];
  statuses = ['Open', 'Validation', 'Closed'];
  selectedStatus = '';

  constructor(
    private issueService: IssueService,
    private customerService: CustomerService,
    private usersService: UsersService,
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
      notes: [''],
      remedy: [''],
      priority: ['', Validators.required],
      status: ['', Validators.required]
    });
  }

  changeStatus(status) {
    if (status === 'Closed') {
      this.updateForm.get('remedy').enable();
    } else {
      this.updateForm.get('remedy').disable();
    }
  }

  fetchCustomers() {
    this.customerService
      .getCustomers()
      .subscribe((data: Customer[]) => {
        this.customers = data;
        console.log('Data requested...');
        console.log(this.customers);
      });
  }

  fetchUsers() {
    this.usersService
      .getUsers()
      .subscribe((data: User[]) => {
        this.users = data;
        console.log('Users Data requested...');
        console.log(this.users);
      });
  }


  ngOnInit() {
    this.fetchUsers();
    this.fetchCustomers();
    this.route.params.subscribe(params => {
      this.id = params.id;
      this.issueService.getIssueById(this.id).subscribe(res => {
        this.issue = res;
        console.log('Issue to edit: ', this.issue);
        this.updateForm.get('title').setValue(this.issue.Title);
        this.updateForm.get('responsible').setValue(this.issue.User.Id);
        this.updateForm.get('customer').setValue(this.issue.Customer.Id);
        this.updateForm.get('description').setValue(this.issue.Description);
        this.updateForm.get('notes').setValue(this.issue.Notes);
        this.updateForm.get('remedy').setValue(this.issue.Remedy);
        this.updateForm.get('remedy').disable();
        this.updateForm.get('priority').setValue(this.issue.Priority);
        this.updateForm.get('status').setValue(this.issue.Status);
      });
    });
  }

  updateIssue(title, userId, customerId, description, notes, remedy, priority, status) {
    if (!userId) {
      userId = this.issue.User.Id;
    }
    if (!customerId) {
      customerId = this.issue.Customer.Id;
    }
    if (!priority) {
      priority = this.issue.Priority;
    }
    if (!status) {
      status = this.issue.Status;
    }

    const agreementId = 1;
    const productId = 1;
    const createdDate = this.issue.CreatedDate;


    this.issueService.updateIssue(this.id, title, userId, customerId, agreementId, productId, description, notes, remedy, createdDate, priority, status).subscribe(() => {
      this.snackBar.open('Issue updated successfully', 'OK', {
        duration: 3000
      });
      this.router.navigate(['/issues']);
    });
  }
}
