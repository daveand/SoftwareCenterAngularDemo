import { Component, OnInit } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';

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
export class ProductsComponent implements OnInit {

  products: Product[];
  displayedColumns = ['name', 'actions'];


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
        this.products = data;
        console.log('Data requested...');
        console.log(this.products);
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

  ngOnInit() {
    this.fetchProducts();

  }

}
