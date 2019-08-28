import { Component, Inject, OnInit, Output, EventEmitter } from '@angular/core';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';

import { HttpClient, HttpEventType, HttpParameterCodec } from '@angular/common/http';
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
import { FileService } from '../../services/file.service';
import { Customer } from '../../models/customer.model';
import { Issue } from '../../models/issue.model';
import { User } from '../../models/user.model';
import { Files } from '../../models/files.model';
import { saveAs } from 'file-saver';
import { escapeRegExp } from '@angular/compiler/src/util';
import { environment } from '../../../environments/environment';
import { CustomersComponent } from '../../components/customers/customers.component';

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
  dbFiles: Files[];

  types = environment.fileTypes;

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
    public dialog: MatDialog,
    private adalService: AdalService,
    private customerService: CustomerService,
    private usersService: UsersService,
    private issueService: IssueService,
    private fileService: FileService,
    private fb: FormBuilder,
    private snackBar: MatSnackBar,
    @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl
    this.createForm = this.fb.group({
      responsible: '',
      type: '',
      customerId: '',
      files: []
    });
  }

  displayedColumns = ['customer', 'type', 'fileName', 'user', 'uploaded'];

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

  startUpload(userId, type, customerId) {
    const files: Array<File> = this.filesToUpload;
    console.log('files upload ', files, userId, customerId);

    const user = this.users.find(u => u.Id === userId);
    const customer = this.customers.find(u => u.Id === customerId);


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
      this.addFile(userId, type, customerId, fileName, filePath);
    }

  }

  ngOnInit() {
    this.fetchUsers();
    this.fetchCustomers();
    this.showBlobs(null);
    this.fetchFiles();
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
          this.fetchFiles();
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
    this.fileService.deleteFile(filePath).subscribe(result => {
      if (result != null) {
        this.http.get(this.baseUrl + 'api/blob/deletefile/' + filePath).subscribe(result => {
          console.log(result);
        });
        this.showBlobs(null);
        this.fetchFiles();
      }
    }, error => console.error(error));
  }

  fetchFiles() {
    this.fileService
      .getFiles()
      .subscribe((data: Files[]) => {
        this.dbFiles = data;
        console.log('Data requested...');
        console.log(this.dbFiles);
      });
  }

  addFile(userId, type, customerId, fileName, filePath) {
    this.fileService.addFile(userId, type, customerId, fileName, filePath).subscribe(() => {
      this.ngOnInit();
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



}
