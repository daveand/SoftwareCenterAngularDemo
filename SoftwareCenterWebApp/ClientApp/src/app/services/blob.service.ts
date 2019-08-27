import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { saveAs } from 'file-saver';
declare var require: any;

@Injectable({
  providedIn: 'root'
})
export class BlobService {
  baseUrl;
  files: string[] = [];
  fileToUpload: FormData;
  fileUpload: any;
  fileUpoadInitiated: boolean;
  fileDownloadInitiated: boolean;

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
  }

  showBlobs() {
    this.http.get<string[]>(this.baseUrl + '/listfiles').subscribe(result => {
      this.files = result;
    }, error => console.error(error));
  }

  //addFile() {
  //  if (!this.fileUpoadInitiated) {
  //    document.getElementById('fileUpload').click();
  //  }
  //}

  //handleFileInput(files: any) {
  //  let formData: FormData = new FormData();
  //  formData.append("asset", files[0], files[0].name);
  //  this.fileToUpload = formData;
  //  this.onUploadFiles(null);
  //}

  uploadFile(file) {
    console.log('onUploadFiles: ', file)
      return this.http.post(this.baseUrl + '/insertfile', file)   
  }

  downloadFile(fileName: string) {
    this.fileDownloadInitiated = true;
    return this.http.get(this.baseUrl + '/downloadfile/' + fileName, { responseType: "blob" })
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
  deleteFile(fileName: string) {
    var del = confirm('Are you sure want to delete this file');
    if (!del) return;
    this.http.get(this.baseUrl + '/deletefile/' + fileName).subscribe(result => {
      if (result != null) {
        this.showBlobs();
      }
    }, error => console.error(error));
  }  

}
