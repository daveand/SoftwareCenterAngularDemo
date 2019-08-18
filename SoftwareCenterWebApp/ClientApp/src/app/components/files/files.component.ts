import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { FilesService } from '../../files.service';
import { faFolder } from '@fortawesome/free-regular-svg-icons';
import { faFile } from '@fortawesome/free-regular-svg-icons';

import { Files } from '../../files.model';


@Component({
  selector: 'app-files',
  templateUrl: './files.component.html',
  styleUrls: ['./files.component.css']
})
export class FilesComponent implements OnInit {
  faFolder = faFolder;
  faFile = faFile;

  filesObject: Files[];
  dirsObject: Files;

  files = [];
  dirs = [{name: 'Home', path: 'null'}];

  constructor(private filesService: FilesService, private router: Router) { }

  ngOnInit() {
    this.fetchFiles(null);
  }

  fetchFiles(dir) {
    console.log('getFiles ', dir);
    this.filesService
      .getFiles(dir)
      .subscribe((data: Files[]) => {
        this.filesObject = data;
        // data.forEach( (item) => {
        //   if (item.type === 'folder') {
        //     this.dirs.push(item.name);
        //   }
        //   if (item.type === 'file') {
        //     this.files.push(item.name);
        //   }

        // });
        // this.filesObject = data;
        // this.dirsObject = data;
        console.log('Data requested...');
        console.log(this.filesObject);
      });
  }

  downloadFile(file) {
    // console.log('download');
    this.filesService
      .downloadFile(file);
      // .subscribe( res => {
      //   // this.files = data.files;
      //   // this.dirs = data.directories;
      //   console.log('Download requested...');
      //   console.log(res);

      // });
  }


  getDir(dir) {
    this.fetchFiles(dir);
    this.dirs.push({name: dir, path: dir});
  }

  getFile(file) {
    this.downloadFile(file);
  }


}
