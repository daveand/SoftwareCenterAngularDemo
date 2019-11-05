import { Component, OnInit, ViewChild, AfterViewInit, Inject, ElementRef } from '@angular/core';
import { HttpClient, HttpEventType, HttpParameterCodec } from '@angular/common/http';
import { AdalService } from 'adal-angular4';
import { FileService } from '../../services/file.service';
import { UsersService } from '../../services/users.service';
import { IssueService } from '../../services/issue.service';
import { ProductService } from '../../services/product.service';
import { Router } from '@angular/router';
import { Location } from '@angular/common';
import { MatTableDataSource, MatSort, MatPaginator } from '@angular/material';
import { saveAs } from 'file-saver';
import { Chart } from 'chart.js';
import { Files } from '../../models/files.model';
import { FavFiles } from '../../models/favfile.model';
import { Issue } from '../../models/issue.model';
import { User } from '../../models/user.model';
import { Product } from '../../models/product.model';

declare var require: any;

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit, AfterViewInit {
  baseUrl;
  role: string;

  users: User[];
  products: Product[];
  issues: Issue[];
  openIssues: Issue[];

  issuesChartData = [];
  issuesByProductChartData = [];

  productList = [];

  constructor(
    private http: HttpClient,
    private usersService: UsersService,
    private adalService: AdalService,
    private fileService: FileService,
    private issueService: IssueService,
    private productService: ProductService,
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
        this.issues = data as Issue[];
        this.issuesSource.data = data.filter(d => d.User.Email === this.adalService.userInfo.userName) as Issue[];
        this.openIssues = this.issuesSource.data.filter(d => d.Status === 'Open') as Issue[];
        console.log('Data requested...');
        console.log(this.issuesSource.data);
        this.calculateIssues();
        this.fetchProducts();

      });
  }

  fetchProducts() {
    this.productService
      .getProducts()
      .subscribe((data: Product[]) => {
        this.products = data;
        console.log('Products Data requested...');
        console.log(this.products);
        this.calculateIssuesByProduct();
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

  @ViewChild('issuesChart', { static: true }) chartIssues: ElementRef;
  @ViewChild('issuesByProductChart', { static: true }) chartIssuesByProduct: ElementRef;
  @ViewChild('issuesSort', { static: true }) issuesSort: MatSort;
  @ViewChild('favFileSort', { static: true }) favFileSort: MatSort;
  @ViewChild('issuesPaginator', { static: true }) issuesPaginator: MatPaginator;
  @ViewChild('favFilesPaginator', { static: true }) favFilesPaginator: MatPaginator;

  ngOnInit() {
    this.adalService.getUser();
    if (this.adalService.userInfo.profile.groups == '06601050-563e-47b4-a0cc-13377f9ddfea') {
      this.role = 'Admin';
    }
    if (this.adalService.userInfo.profile.groups == '56b8f386-90bc-48e5-a430-52f02fd9a6ce') {
      this.role = 'SW Technician';
    }
    if (this.adalService.userInfo.profile.groups == 'fef123e3-d91f-4d63-88d8-0b07154df185') {
      this.role = 'Technician';
    }

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

  calculateIssues() {
    const openIssuesChart = this.issues.filter(d => d.Status === 'Open') as Issue[];
    const validationIssuesChart = this.issues.filter(d => d.Status === 'Validation') as Issue[];
    const closedIssuesChart = this.issues.filter(d => d.Status === 'Closed') as Issue[];

    this.issuesChartData.push(openIssuesChart.length, validationIssuesChart.length, closedIssuesChart.length)

    console.log('issuesData: ', this.issuesChartData);
    this.createIssuesChart();

  }

  calculateIssuesByProduct() {
    this.products.forEach(product => {
      this.productList.push(product.Title)
      const issue = this.issues.filter(d => d.Product.Title === product.Title) as Issue[];
      this.issuesByProductChartData.push(issue.length);
    })
    console.log(this.productList);
    console.log(this.issuesByProductChartData);
    this.createIssuesByProductChart()

  }

  createIssuesChart() {
    var ctx = this.chartIssues.nativeElement.getContext('2d');
    var issuesChart = new Chart(ctx, {
      type: 'doughnut',
      data: {
        labels: ['Open', 'Validation', 'Closed'],
        datasets: [{
          data: this.issuesChartData,
          backgroundColor: [
            'rgba(255, 99, 132, 0.2)',
            'rgba(54, 162, 235, 0.2)',
            'rgba(11, 253, 35, 0.2)'
          ],
          borderColor: [
            'rgba(255, 99, 132, 1)',
            'rgba(54, 162, 235, 1)',
            'rgba(11, 253, 35, 1)'
          ],
          borderWidth: 1
        }]
      },
      options: {
        animation: { animateRotate: true }
      }
    });
  }

  createIssuesByProductChart() {
    var ctx = this.chartIssuesByProduct.nativeElement.getContext('2d');
    var issuesByProductChart = new Chart(ctx, {
      type: 'polarArea',
      data: {
        labels: this.productList,
        datasets: [{
          data: this.issuesByProductChartData,
          backgroundColor: [
            'rgba(255, 99, 132, 0.2)',
            'rgba(54, 162, 235, 0.2)',
            'rgba(11, 253, 35, 0.2)'
          ],
          borderColor: [
            'rgba(255, 99, 132, 1)',
            'rgba(54, 162, 235, 1)',
            'rgba(11, 253, 35, 1)'
          ],
          borderWidth: 1
        }]
      },
      options: {
        animation: { animateRotate: true },
        legend: { display: true }
      }
    });
  }



}
