import { Component, OnInit } from '@angular/core';
import { Customer } from '../../customer.model';
import { IssueService } from '../../issue.service';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-create',
  templateUrl: './create.component.html',
  styleUrls: ['./create.component.css']
})
export class CreateComponent implements OnInit {

  customers: Customer[];
  severeties = ['Low', 'Medium', 'High'];
  createForm: FormGroup;

  constructor(private issueService: IssueService, private fb: FormBuilder, private router: Router) {
    this.createForm = this.fb.group({
      title: ['', Validators.required],
      responsible: '',
      customer: '',
      description: '',
      severity: ''
    });
  }


  fetchCustomers() {
    this.issueService
      .getCustomers()
      .subscribe((data: Customer[]) => {
        this.customers = data;
        console.log('Data requested...');
        console.log(this.customers);
      });
  }

  addIssue(title, responsible, customer, description, severity) {
    console.log('issue:', title, responsible, customer, description, severity);
    this.issueService.addIssue(title, responsible, customer, description, severity).subscribe(() => {
      this.router.navigate(['/issues']);
    });
  }

  ngOnInit() {
    this.fetchCustomers();
  }

}
