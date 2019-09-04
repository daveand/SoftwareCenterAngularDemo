import { Component, OnInit, Inject, ViewChild, AfterViewInit } from '@angular/core';
import { AdalService } from 'adal-angular4';
import { MatSnackBar } from '@angular/material/snack-bar';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { MatTableDataSource, MatSort, MatPaginator } from '@angular/material';
import { CustomerService } from '../../services/customer.service';
import { UsersService } from '../../services/users.service';
import { IssueService } from '../../services/issue.service';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Customer } from '../../models/customer.model';
import { Issue } from '../../models/issue.model';
import { User } from '../../models/user.model';
import { Product } from '../../models/product.model';
import { CustomersComponent } from '../../components/customers/customers.component';
import { ProductsComponent } from '../../components/products/products.component';
import { ProductService } from '../../services/product.service';
import { Location } from '@angular/common';


export interface DialogData {
  animal: string;
  name: string;
}

@Component({
  selector: 'app-issues',
  templateUrl: './issues.component.html',
  styleUrls: ['./issues.component.css']
})
export class IssuesComponent implements OnInit, AfterViewInit {
  issues: Issue[];
  displayedColumns = ['Title', 'User.Name', 'Customer.Name', 'Product.Title', 'Priority', 'Status', 'Actions'];
  public dataSource = new MatTableDataSource<Issue>();

  customers: Customer[];
  products: Product[];

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
    private productService: ProductService,
    private fb: FormBuilder,
    private router: Router,
    private location: Location) {
    this.createForm = this.fb.group({
      title: ['', Validators.required],
      userId: '',
      customerId: '',
      productId: '',
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

  fetchProducts() {
    this.productService
      .getProducts()
      .subscribe((data: Product[]) => {
        this.products = data;
        console.log('Products Data requested...');
        console.log(this.products);
      });
  }


  addIssue(title, userId, customerId, productId, description, priority) {
    const user = this.users.find(u => u.Id === userId);

    this.issueService.addIssue(title, user.Id, customerId, productId, description, priority).subscribe(() => {
      // this.router.navigate(['/issues']);
      this.snackBar.open('New issue added!', 'Close');
      this.ngOnInit();
    });
  }

  fetchIssues() {
    this.issueService
      .getIssues()
      .subscribe((data: Issue[]) => {
        this.dataSource.data = data as Issue[];
        console.log('Data requested...');
        console.log(this.dataSource.data);
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

  openCustomerDialog(): void {
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

  openProductDialog(): void {
    const dialogRef = this.dialog.open(ProductsComponent, {
      //width: '250px',
      //data: { name: this.name, animal: this.animal }
    });

    dialogRef.afterClosed().subscribe(result => {
      console.log('The dialog was closed');
      this.ngOnInit();
      //this.animal = result;
    });
  }

  @ViewChild(MatSort, { static: true }) sort: MatSort;
  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;

  ngOnInit() {
    this.fetchUsers();
    this.fetchCustomers();
    this.fetchIssues();
    this.fetchProducts();

  }

  ngAfterViewInit(): void {
    this.dataSource.sortingDataAccessor = (item, property) => {
      switch (property) {
        case 'Customer.Name': return item.Customer.Name;
        case 'User.Name': return item.User.Name;
        case 'Product.Title': return item.Product.Title;
        default: return item[property];
      }
    };
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
