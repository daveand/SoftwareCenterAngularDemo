import { Component, OnInit, Inject } from '@angular/core';
import { AdalService } from 'adal-angular4';
import { MatSnackBar } from '@angular/material/snack-bar';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';

import { CustomerService } from '../../services/customer.service';
import { UsersService } from '../../services/users.service';
import { IssueService } from '../../services/issue.service';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Customer } from '../../models/customer.model';
import { Issue } from '../../models/issue.model';
import { User } from '../../models/user.model';
import { CustomersComponent } from '../../components/customers/customers.component';


export interface DialogData {
  animal: string;
  name: string;
}

@Component({
  selector: 'app-issues',
  templateUrl: './issues.component.html',
  styleUrls: ['./issues.component.css']
})
export class IssuesComponent implements OnInit {
  issues: Issue[];
  displayedColumns = ['title', 'responsible', 'customer', 'priority', 'status', 'actions'];

  customers: Customer[];
  users: User[];
  priorities = ['Low', 'Medium', 'High', 'Critical'];

  createForm: FormGroup;


  constructor(
    private adalService: AdalService,
    public dialog: MatDialog,
    private snackBar: MatSnackBar,
    private customerService: CustomerService,
    private usersService: UsersService,
    private issueService: IssueService,
    private fb: FormBuilder,
    private router: Router) {
    this.createForm = this.fb.group({
      title: ['', Validators.required],
      responsible: '',
      customerId: '',
      description: '',
      priority: '',
    });
  }

  fetchCustomers() {
    this.customerService
      .getCustomers()
      .subscribe((data: Customer[]) => {
        this.customers = data;
        console.log('Customers Data requested...');
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

  addIssue(title, responsible, customerId, description, priority) {
    const user = this.users.find(u => u.Id === responsible);

    this.issueService.addIssue(title, user.Id, customerId, description, priority).subscribe(() => {
      // this.router.navigate(['/issues']);
      this.snackBar.open('New issue added!', 'Close');
      this.ngOnInit();
    });
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
    this.router.navigate([`/issuedetails/${id}`]);
  }

  editIssue(id) {
    this.router.navigate([`issues/edit/${id}`]);
  }

  deleteIssue(id) {
    this.issueService
      .deleteIssue(id)
      .subscribe(() => {
        this.fetchIssues();
      });
  }

  openDialog(): void {
    const dialogRef = this.dialog.open(CustomersComponent, {
      //width: '250px',
      //data: { name: this.name, animal: this.animal }
    });

    dialogRef.afterClosed().subscribe(result => {
      console.log('The dialog was closed');
      this.ngOnInit();
      //this.animal = result;
    });
  }

  ngOnInit() {
    this.fetchUsers();
    this.fetchCustomers();
    this.fetchIssues();

  }

}

@Component({
  selector: 'issues-create-dialog',
  templateUrl: 'issues-create-dialog.html',
})
export class IssuesCreateDialog {

  constructor(
    public dialogRef: MatDialogRef<IssuesCreateDialog>,
    @Inject(MAT_DIALOG_DATA) public data: DialogData) { }

  onNoClick(): void {
    this.dialogRef.close();
  }

}
