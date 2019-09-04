import { Component, OnInit, ViewChild, AfterViewInit } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { MatTableDataSource, MatSort, MatPaginator } from '@angular/material';

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
export class CustomersComponent implements OnInit, AfterViewInit {

  customers: Customer[];
  displayedColumns = ['Name', 'Actions'];
  public dataSource = new MatTableDataSource<Customer>();


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
        this.dataSource.data = data as Customer[];
        console.log('Data requested...');
        console.log(this.dataSource.data);
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

  @ViewChild(MatSort, { static: true }) sort: MatSort;
  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;

  ngOnInit() {
    this.fetchCustomers();

  }

  ngAfterViewInit(): void {
    this.dataSource.filterPredicate = (data: any, filter) => {
      const dataStr = JSON.stringify(data).toLowerCase();
      return dataStr.indexOf(filter) != -1;
    };
    this.dataSource.sort = this.sort;
    this.dataSource.paginator = this.paginator;
  }

  applyFilter(filterValue: string) {
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }

}
