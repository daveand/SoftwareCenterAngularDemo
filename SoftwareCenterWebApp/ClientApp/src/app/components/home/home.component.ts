import { Component, OnInit, ViewChild, AfterViewInit, Inject } from '@angular/core';
import { HttpClient, HttpEventType, HttpParameterCodec } from '@angular/common/http';
import { AdalService } from 'adal-angular4';
import { FileService } from '../../services/file.service';
import { UsersService } from '../../services/users.service';
import { IssueService } from '../../services/issue.service';
import { Router } from '@angular/router';
import { Location } from '@angular/common';
import { MatTableDataSource, MatSort, MatPaginator } from '@angular/material';
import { saveAs } from 'file-saver';

import { Files } from '../../models/files.model';
import { FavFiles } from '../../models/favfile.model';
import { Issue } from '../../models/issue.model';
import { User } from '../../models/user.model';

declare var require: any;

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit, AfterViewInit {
  baseUrl;
  users: User[];
  issues: Issue[];
  openIssues: Issue[];

  constructor(
    private http: HttpClient,
    private usersService: UsersService,
    private adalService: AdalService,
    private fileService: FileService,
    private issueService: IssueService,
    private router: Router,
    private location: Location,
    @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl
  }

  issuesColumns = ['Title', 'User.Name', 'Customer.Name', 'Product.Title', 'Priority', 'Status', 'Actions'];
  public issuesSource = new MatTableDataSource<Issue>();


  favFileColumns = ['File.Customer.Name', 'File.Type', 'File.Product.Title', 'File.FileName', 'File.User.Name', 'File.Uploaded', 'Actions'];
  public favFileSource = new MatTableDataSource<FavFiles>();

  fileDownloadInitiated: boolean;


  fetchUsers() {
    this.usersService
      .getUsers()
      .subscribe((data: User[]) => {
        this.users = data;
        console.log('Users Data requested...');
        console.log(this.users);
        this.fetchFavFiles();
      });
  }

  fetchIssues() {
    this.issueService
      .getIssues()
      .subscribe((data: Issue[]) => {
        console.log(this.adalService.userInfo.userName)
        this.issuesSource.data = data.filter(d => d.User.Email === this.adalService.userInfo.userName) as Issue[];
        this.openIssues = data.filter(d => d.Status === 'Open') as Issue[];
        console.log('Data requested...');
        console.log(this.issuesSource.data);
        console.log('Open issues: ', this.openIssues);

      });
  }

  detailsIssue(id) {
    this.router.navigate([`/issuedetails/${id}`]);
  }

  editIssue(id) {
    this.router.navigate([`issues/edit/${id}`]);
  }

  fetchFavFiles() {
    const user = this.users.find(u => u.Email === this.adalService.userInfo.userName);
    console.log('user: ', user);
    this.fileService
      .getFavFiles(user.Id)
      .subscribe((data: FavFiles[]) => {
        this.favFileSource.data = data as FavFiles[];
        //this.dbFiles = data;
        console.log('Data requested...');
        console.log(this.favFileSource.data);
      });

  }

  deleteFavFile(id, fileName) {
    console.log('Remove FavFile: ', id, fileName);
    const user = this.users.find(u => u.Email === this.adalService.userInfo.userName);

    var del = confirm(`Are you sure want to remove ${fileName} from favourites?`);
    if (!del) return;
    this.fileService.deleteFavFile(id).subscribe(result => {
      if (result != null) {
        this.fetchFavFiles();
      }
    }, error => console.error(error));
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


  @ViewChild('issuesSort', { static: true }) issuesSort: MatSort;
  @ViewChild('favFileSort', { static: true }) favFileSort: MatSort;
  @ViewChild('issuesPaginator', { static: true }) issuesPaginator: MatPaginator;
  @ViewChild('favFilesPaginator', { static: true }) favFilesPaginator: MatPaginator;

  ngOnInit() {
    this.adalService.getUser();
    this.fetchUsers();
    this.fetchIssues();
  }

  ngAfterViewInit(): void {
    this.issuesSource.sortingDataAccessor = (item, property) => {
      switch (property) {
        case 'Customer.Name': return item.Customer.Name;
        case 'User.Name': return item.User.Name;
        case 'Product.Title': return item.Product.Title;
        default: return item[property];
      }
    };
    this.issuesSource.filterPredicate = (data: any, filter) => {
      const dataStr = JSON.stringify(data).toLowerCase();
      return dataStr.indexOf(filter) != -1;
    };
    this.issuesSource.sort = this.issuesSort;
    this.issuesSource.paginator = this.issuesPaginator;

    this.favFileSource.sortingDataAccessor = (item, property) => {
      switch (property) {
        case 'File.Customer.Name': return item.File.Customer.Name;
        case 'File.User.Name': return item.File.User.Name;
        case 'File.Product.Title': return item.File.Product.Title;
        default: return item[property];
      }
    };
    this.favFileSource.filterPredicate = (data: any, filter) => {
      const dataStr = JSON.stringify(data).toLowerCase();
      return dataStr.indexOf(filter) != -1;
    };
    this.favFileSource.sort = this.favFileSort;
    this.favFileSource.paginator = this.favFilesPaginator;
  }

  applyFavFilesFilter(filterValue: string) {
    this.favFileSource.filter = filterValue.trim().toLowerCase();
  }

  applyIssuesFilter(filterValue: string) {
    this.issuesSource.filter = filterValue.trim().toLowerCase();
  }



}
