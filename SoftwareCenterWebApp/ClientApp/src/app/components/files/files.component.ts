import { Component, Inject, OnInit, Output, EventEmitter } from '@angular/core';
import { HttpClient, HttpEventType, HttpParameterCodec} from '@angular/common/http';
import { AdalService } from 'adal-angular4';
import { Router } from '@angular/router';
import { from, Observable } from 'rxjs';
import { combineAll, map } from 'rxjs/operators';
import { ISasToken } from '../../services/azureStorage';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { CustomerService } from '../../services/customer.service';
import { UsersService } from '../../services/users.service';
import { IssueService } from '../../services/issue.service';
import { Customer } from '../../models/customer.model';
import { Issue } from '../../models/issue.model';
import { User } from '../../models/user.model';
import { saveAs } from 'file-saver';
import { escapeRegExp } from '@angular/compiler/src/util';
declare var require: any;  

interface IUploadProgress {
  filename: string;
  progress: number;
}

@Component({
  selector: 'app-files',
  templateUrl: './files.component.html',
  styleUrls: ['./files.component.css']
})
export class FilesComponent implements OnInit {
  baseUrl;

  customers: Customer[];
  users: User[];

  createForm: FormGroup;

  filenames: any[];

  filesToUpload: Array<File> = [];
  responsible = '';
  customer = '';
  public progress: number;
  public message: string;
  public fileName: string;
  @Output() public onUploadFinished = new EventEmitter();

  constructor(
    private http: HttpClient,
    private adalService: AdalService,
    private customerService: CustomerService,
    private usersService: UsersService,
    private issueService: IssueService,
    private fb: FormBuilder,
    private snackBar: MatSnackBar,
    @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl
    this.createForm = this.fb.group({
      responsible: '',
      customerId: '',
      files: []
    });
  }

  files: string[] = [];
  fileToUpload: FormData;
  fileUpload: any;
  fileUpoadInitiated: boolean;
  fileDownloadInitiated: boolean;
  dirList: Array<{ name: string, path: string }> = [];
  filesList: Array<{ name: string, path: string, length: string }> = [];
  currentDir: string;

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

  fileChangeEvent(fileInput: any) {
    this.filesToUpload = <Array<File>>fileInput.target.files;
  }

  startUpload(responsible, customer) {
    const files: Array<File> = this.filesToUpload;
    console.log('files ', files, responsible, customer);
    this.responsible = responsible;
    this.customer = customer;

    let filesToUpload: File[] = files;
    const formData = new FormData();

    Array.from(filesToUpload).map((file, index) => {
      this.fileName = `${customer}/${file.name}`
      return formData.append('file' + index, file, this.fileName);
    });
    this.onUploadFiles(formData);
    
  }

  ngOnInit() {
    this.fetchUsers();
    this.fetchCustomers();
    this.showBlobs(null);
  }

  showBlobs(dir) {
    if (dir !== null) {
      dir = dir.split('/').join('^');
      console.log(dir);
    } 
    this.http.get<string[]>(this.baseUrl + `api/blob/listfiles/${dir}`).subscribe(result => {
      console.log('result: ', result);
      result.forEach(item => {
        if (item['directory'] !== null) {
          this.dirList.push(item['directory']);
        } else {
          this.filesList.push(item['file']);

        }
      });

      if (result[0]['directory'] !== null) {
        if (result[0]['directory'].parent === '') {
          this.currentDir = 'null';
        } else {
          this.currentDir = result[0]['directory'].parent;
        }
      } else {
        if (result[0]['file'].parent === '') {
          this.currentDir = 'null';
        } else {
          this.currentDir = result[0]['file'].parent;
        }
      }
      console.log('Current directory: ', this.currentDir);

      console.log('Files: ', this.filesList);
      console.log('Dirs: ', this.dirList);

    }, error => console.error(error));
    this.dirList = [];
    this.filesList = [];
  }

  addFile() {
    if (!this.fileUpoadInitiated) {
      document.getElementById('fileUpload').click();
    }
  }

  onUploadFiles(formData) {
    this.progress = 0;
    this.message = '';
    return this.http.post(this.baseUrl + 'api/blob/insertfile', formData, { reportProgress: true, observe: 'events' })
      .subscribe(event => {
        if (event.type === HttpEventType.UploadProgress)
          this.progress = Math.round(100 * event.loaded / event.total);
        else if (event.type === HttpEventType.Response) {
          this.message = 'Upload success.';
          this.onUploadFinished.emit(event.body);
          this.showBlobs(null);
        }
      });

  }

  downloadFile(filePath: string, fileName: string) {
    filePath = filePath.split('/').join('^');
    this.fileDownloadInitiated = true;
    return this.http.get(this.baseUrl + 'api/blob/downloadfile/' + filePath, { responseType: "blob" })
      .subscribe((result: any) => {
        if (result.type != 'text/plain') {
          var blob = new Blob([result]);
          let saveAs = require('file-saver');
          let file = fileName;
          saveAs(blob, file);
          this.fileDownloadInitiated = false;
        }
        else {
          this.fileDownloadInitiated = false;
          alert('File not found in Blob!');
        }
      }
      );
  }

  deleteFile(filePath: string, fileName: string) {
    console.log(filePath);
    filePath = filePath.split('/').join('^');

    console.log(filePath);

    var del = confirm('Are you sure want to delete ' + fileName + '?');
    if (!del) return;
    this.http.get(this.baseUrl + 'api/blob/deletefile/' + filePath).subscribe(result => {
      if (result != null) {
        this.showBlobs(null);
      }
    }, error => console.error(error));
  }  


}
