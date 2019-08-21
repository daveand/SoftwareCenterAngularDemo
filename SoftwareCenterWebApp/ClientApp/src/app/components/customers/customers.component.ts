import { Component, OnInit } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';

import { CustomerService } from '../../services/customer.service';
import { IssueService } from '../../services/issue.service';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Customer } from '../../models/customer.model';
import { Issue } from '../../models/issue.model';


@Component({
  selector: 'app-customers',
  templateUrl: './customers.component.html',
  styleUrls: ['./customers.component.css']
})
export class CustomersComponent implements OnInit {

  customers: Customer[];
  displayedColumns = ['name', 'actions'];


  createForm: FormGroup;


  constructor(
    private snackBar: MatSnackBar,
    private customerService: CustomerService,
    private fb: FormBuilder,
    private router: Router) {
    this.createForm = this.fb.group({
      name: ['', Validators.required],
    });
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

  addCustomer(name) {
    this.customerService.addCustomer(name).subscribe(() => {
      // this.router.navigate(['/issues']);
      this.snackBar.open('New customer added!', 'Close');
      this.ngOnInit();
    });
  }


  detailsCustomer(id) {
    this.router.navigate([`/issuedetails/${id}`], { skipLocationChange: true });
  }

  editCustomer(id) {
    this.router.navigate([`/edit/${id}`], { skipLocationChange: true });
  }

  deleteCustomer(id) {
    this.customerService
      .deleteCustomer(id)
      .subscribe(() => {
        this.fetchCustomers();
      });
  }

  ngOnInit() {
    this.fetchCustomers();

  }

}
