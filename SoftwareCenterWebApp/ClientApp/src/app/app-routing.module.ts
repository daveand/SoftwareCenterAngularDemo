import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AdalService, AdalGuard } from '../../node_modules/adal-angular4';
import { AuthGuard } from './auth.guard';
import { HomeComponent } from './components/home/home.component';
import { IssuesEditComponent } from './components/issues/edit/edit.component';
import { IssuesComponent } from './components/issues/issues.component';
import { IssuedetailsComponent } from './components/issues/details/details.component';
import { FilesComponent } from './components/files/files.component';
import { CustomersComponent } from './components/customers/customers.component';


const routes: Routes = [
  { path: 'customers', component: CustomersComponent },
  { path: 'issues', component: IssuesComponent },
  { path: 'issuedetails/:id', component: IssuedetailsComponent },
  { path: 'Issues/edit/:id', component: IssuesEditComponent },
  { path: 'files', component: FilesComponent },
  { path: '', component: HomeComponent, canActivate: [AuthGuard] },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
