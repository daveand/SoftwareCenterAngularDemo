import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { SearchService } from '../../services/search.service';
import { Filesearch } from '../../models/filesearch.model';
import { Files } from '../../models/files.model';


@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.css']
})
export class SearchComponent implements OnInit {

  createForm: FormGroup;
  displayedColumns = ['title', 'responsible', 'customer', 'priority', 'status', 'actions'];

  types = ['All', 'Files', 'Issues']
  files: any[];

  constructor(
    private fb: FormBuilder,
    private searchService: SearchService
  ) {
    this.createForm = this.fb.group({
      valueString: '',
      type: '',
    });
  }

  searchDb(valueString, type) {

    this.searchService.searchDb(valueString, type).subscribe((data: Filesearch[]) => {
      console.log(data);
      for (var i = 0, len = data.length; i < len; i++) {
        if (data[i].files.length !== 0) {
          console.log(data[i].files);

          this.files = data[i].files;
        }
      }

      console.log(this.files);

      // this.router.navigate(['/issues']);
      this.ngOnInit();
    });
  }

  ngOnInit() {
  }

}
