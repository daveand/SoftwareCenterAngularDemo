import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
//import { saveAs } from 'file-saver';

@Injectable({
  providedIn: 'root'
})
export class FilesService {

  url = 'http://localhost:3000/api';

  constructor(private http: HttpClient) { }

  getFiles(dir) {
    return this.http.get(`${this.url}/files/${dir}`);
  }

  downloadFile(file) {

    const url = `${this.url}/files/download/${file}`;


    this.http.get(url, {
      responseType: 'blob',
      headers: {
          'Content-Type': 'application/octet-stream; charset=utf-8'
        }
    }).subscribe( res => {
      console.log('File downloaded');
      console.log(res);

      const saveFile = (blobContent: Blob, fileName: string) => {
        const blob = new Blob([blobContent], { type: 'application/octet-stream' });
        //saveAs(blob, fileName);
      };
      saveFile(res, file);

      // window.open(window.URL.createObjectURL(res));
    });

  }

  // downloadFile(file) {
  //   console.log('download', file);
  //   return this.http.get(`${this.url}/files/download/${file}`);
  // }



}
