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
import { SearchComponent } from './components/search/search.component';
import { ProductsComponent } from './components/products/products.component';
import { KnowledgesComponent } from './components/knowledges/knowledges.component';
import { KnowledgeEditComponent } from './components/knowledges/edit/edit.component';
import { KnowledgedetailsComponent } from './components/knowledges/details/details.component';


const routes: Routes = [
  { path: 'knowledges', component: KnowledgesComponent },
  { path: 'knowledgedetails/:id', component: KnowledgedetailsComponent },
  { path: 'knowledges/edit/:id', component: KnowledgeEditComponent },
  { path: 'search', component: SearchComponent },
  { path: 'customers', component: CustomersComponent },
  { path: 'products', component: ProductsComponent },
  { path: 'issues', component: IssuesComponent },
  { path: 'issuedetails/:id', component: IssuedetailsComponent },
  { path: 'issues/edit/:id', component: IssuesEditComponent },
  { path: 'files', component: FilesComponent },
  { path: '', component: HomeComponent, canActivate: [AuthGuard] },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
