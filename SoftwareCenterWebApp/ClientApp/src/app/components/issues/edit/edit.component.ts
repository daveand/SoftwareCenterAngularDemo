import { Component, OnInit, Inject, Output, EventEmitter } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material';
import { IssueService } from '../../../services/issue.service';
import { CustomerService } from '../../../services/customer.service';
import { UsersService } from '../../../services/users.service';
import { ProductService } from '../../../services/product.service';
import { FileService } from '../../../services/file.service';
import { HttpClient, HttpEventType, HttpParameterCodec } from '@angular/common/http';
import { Location } from '@angular/common';

import { Issue } from '../../../models/issue.model';
import { User } from '../../../models/user.model';
import { Customer } from '../../../models/customer.model';
import { Product } from '../../../models/product.model';
import { environment } from '../../../../environments/environment';

@Component({
  selector: 'app-issuesedit',
  templateUrl: './edit.component.html',
  styleUrls: ['./edit.component.css']
})
export class IssuesEditComponent implements OnInit {
  baseUrl;


  customers: Customer[];
  users: User[];
  products: Product[];

  id: string;
  issue: any = {};
  updateForm: FormGroup;
  priorities = ['Low', 'Medium', 'High', 'Critical'];
  statuses = ['Open', 'Validation', 'Closed'];
  selectedStatus = '';

  @Output() public onUploadFinished = new EventEmitter();

  types = environment.fileTypes;
  createFileForm: FormGroup;
  filesToUpload: Array<File> = [];
  fileUploadProgress: string = null;
  public fileName: string;
  public progress: number;
  public message: string;



  constructor(
    private location: Location,
    private http: HttpClient,
    private issueService: IssueService,
    private customerService: CustomerService,
    private usersService: UsersService,
    private productService: ProductService,
    private fileService: FileService,
    private router: Router,
    private route: ActivatedRoute,
    private snackBar: MatSnackBar,
    private fb: FormBuilder,
    private fbFile: FormBuilder,
    @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl
    this.createForm();
    this.createFileForm = this.fbFile.group({
      responsible: '',
      type: '',
      customerId: '',
      productId: '',
      files: []
    });
  }

  createForm() {
    this.updateForm = this.fb.group({
      title: ['', Validators.required],
      responsible: ['', Validators.required],
      customer: ['', Validators.required],
      product: ['', Validators.required],
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

  fetchProducts() {
    this.productService
      .getProducts()
      .subscribe((data: Product[]) => {
        this.products = data;
        console.log('Products Data requested...');
        console.log(this.products);
      });
  }

  ngOnInit() {
    this.fetchUsers();
    this.fetchCustomers();
    this.fetchProducts();
    this.route.params.subscribe(params => {
      this.id = params.id;
      this.issueService.getIssueById(this.id).subscribe(res => {
        this.issue = res;
        console.log('Issue to edit: ', this.issue);
        this.updateForm.get('title').setValue(this.issue.Title);
        this.updateForm.get('responsible').setValue(this.issue.User.Id);
        this.updateForm.get('customer').setValue(this.issue.Customer.Id);
        this.updateForm.get('product').setValue(this.issue.Product.Id);
        this.updateForm.get('description').setValue(this.issue.Description);
        this.updateForm.get('notes').setValue(this.issue.Notes);
        this.updateForm.get('remedy').setValue(this.issue.Remedy);
        this.updateForm.get('remedy').disable();
        this.updateForm.get('priority').setValue(this.issue.Priority);
        this.updateForm.get('status').setValue(this.issue.Status);
      });
    });
  }

  updateIssue(title, userId, customerId, productId, description, notes, remedy, priority, status) {
    if (!userId) {
      userId = this.issue.User.Id;
    }
    if (!customerId) {
      customerId = this.issue.Customer.Id;
    }
    if (!productId) {
      productId = this.issue.Product.Id;
    }
    if (!priority) {
      priority = this.issue.Priority;
    }
    if (!status) {
      status = this.issue.Status;
    }

    const agreementId = 1;
    const createdDate = this.issue.CreatedDate;


    this.issueService.updateIssue(this.id, title, userId, customerId, agreementId, productId, description, notes, remedy, createdDate, priority, status).subscribe(() => {
      this.snackBar.open('Issue updated successfully', 'OK', {
        duration: 3000
      });
      //this.router.navigate(['/issues']);
      this.location.back();
    });
  }

  // Upload file logic
  fileChangeEvent(fileInput: any) {
    this.filesToUpload = <Array<File>>fileInput.target.files;
  }

  startUpload(userId, productId) {
    const files: Array<File> = this.filesToUpload;
    console.log('files upload ', files, userId);

    const user = this.users.find(u => u.Id === userId);
    const customerId = this.issue.Customer.Id;
    const customer = this.customers.find(u => u.Id === customerId);
    const issueId = this.issue.Id;
    const type = 'Issue';

    let filesToUpload: File[] = files;
    const formData = new FormData();

    Array.from(filesToUpload).map((file, index) => {
      this.fileName = `${customer.Name}/${type}/${file.name}`
      return formData.append('file' + index, file, this.fileName);
    });

    this.onUploadFiles(formData);

    for (var i = 0, len = files.length; i < len; i++) {
      console.log(files[i].name);
      const fileName = files[i].name;
      const filePath = `${customer.Name}/${type}/${files[i].name}`;
      this.addFile(userId, type, customerId, productId, fileName, filePath, issueId);
    }

  }

  onUploadFiles(formData) {
    this.progress = 0;
    this.message = '';

    this.fileUploadProgress = '0%';

    return this.http.post(this.baseUrl + 'api/blob/insertfile', formData, { reportProgress: true, observe: 'events' })
      .subscribe(events => {
        if (events.type === HttpEventType.UploadProgress) {
          this.progress = Math.round(events.loaded / events.total * 100);
          console.log(this.fileUploadProgress);
        }
        else if (events.type === HttpEventType.Response) {
          this.message = 'Upload success.';
          this.onUploadFinished.emit(events.body);
          //this.showBlobs(null);
          //this.fetchFiles();
        }
      });

  }

  addFile(userId, type, customerId, productId, fileName, filePath, issueId) {
    this.fileService.addIssueFile(userId, type, customerId, productId, fileName, filePath, issueId).subscribe(() => {
      this.ngOnInit();
    });
  }

  goBack() {
    this.location.back();
  }



}
