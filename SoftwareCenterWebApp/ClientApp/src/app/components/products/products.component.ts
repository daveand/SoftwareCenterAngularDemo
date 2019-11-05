import { Component, OnInit, ViewChild, AfterViewInit } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { MatTableDataSource, MatSort, MatPaginator } from '@angular/material';

import { CustomerService } from '../../services/customer.service';
import { ProductService } from '../../services/product.service';

import { IssueService } from '../../services/issue.service';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Customer } from '../../models/customer.model';
import { Issue } from '../../models/issue.model';
import { Product } from '../../models/product.model';


@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.css']
})
export class ProductsComponent implements OnInit, AfterViewInit {

  products: Product[];
  displayedColumns = ['Title', 'Actions'];
  public dataSource = new MatTableDataSource<Product>();


  createForm: FormGroup;


  constructor(
    private snackBar: MatSnackBar,
    private productService: ProductService,
    private fb: FormBuilder,
    private router: Router) {
    this.createForm = this.fb.group({
      title: ['', Validators.required],
    });
  }

  fetchProducts() {
    this.productService
      .getProducts()
      .subscribe((data: Product[]) => {
        this.dataSource.data = data as Product[];
        console.log('Data requested...');
        console.log(this.dataSource.data);
      });
  }

  addProduct(title) {
    this.productService.addProduct(title).subscribe(() => {
      // this.router.navigate(['/issues']);
      this.snackBar.open('New product added!', 'Close');
      this.ngOnInit();
    });
  }


  detailProduct(id) {
    this.router.navigate([`/issuedetails/${id}`], { skipLocationChange: true });
  }

  editProduct(id) {
    this.router.navigate([`/edit/${id}`], { skipLocationChange: true });
  }

  deleteProduct(id) {
    this.productService
      .deleteProduct(id)
      .subscribe(() => {
        this.fetchProducts();
      });
  }

  @ViewChild(MatSort, { static: true }) sort: MatSort;
  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;

  ngOnInit() {
    this.fetchProducts();

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
