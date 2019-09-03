import { Component, OnInit, ViewChild, AfterViewInit, Inject } from '@angular/core';
import { MatTableDataSource, MatSort, MatPaginator } from '@angular/material';
import { HttpClient, HttpEventType, HttpParameterCodec } from '@angular/common/http';

import { Customer } from '../../../models/customer.model';
import { Router, ActivatedRoute } from '@angular/router';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material';
import { IssueService } from '../../../services/issue.service';
import { FileService } from '../../../services/file.service';
import { Files } from '../../../models/files.model';

@Component({
  selector: 'app-issuedetails',
  templateUrl: './details.component.html',
  styleUrls: ['./details.component.css']
})
export class IssuedetailsComponent implements OnInit, AfterViewInit {
  baseUrl;

  customers: Customer[];
  id: string;
  issue: any = {};

  constructor(
    private http: HttpClient,
    private issueService: IssueService,
    private fileService: FileService,
    private router: Router,
    private route: ActivatedRoute,
    @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
  }

  displayedColumns = ['Customer.Name', 'Type', 'Product.Title', 'FileName', 'User.Name', 'Uploaded', 'Actions'];
  public dataSource = new MatTableDataSource<Files>();
  fileDownloadInitiated: boolean;


  fetchFilesByIssue() {
    this.fileService
      .getFilesByIssue(this.id)
      .subscribe((data: Files[]) => {
        this.dataSource.data = data as Files[];
        //this.dbFiles = data;
        console.log('Data requested...');
        console.log(this.dataSource.data);
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


  @ViewChild(MatSort, { static: true }) sort: MatSort;
  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;

  ngOnInit() {
    this.route.params.subscribe(params => {
      this.id = params.id;
      this.issueService.getIssueById(this.id).subscribe(res => {
        this.issue = res;
        console.log(this.issue);
      });
    });
    this.fetchFilesByIssue();
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
