import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { CreateComponent } from './components/create/create.component';
import { EditComponent } from './components/edit/edit.component';
import { ListComponent } from './components/list/list.component';
import { IssuesComponent } from './components/issues/issues.component';
import { IssuedetailsComponent } from './components/issuedetails/issuedetails.component';
import { FilesComponent } from './components/files/files.component';

const routes: Routes = [
  { path: 'issues', component: IssuesComponent },
  { path: 'issuedetails/:id', component: IssuedetailsComponent },
  { path: 'create', component: CreateComponent },
  { path: 'edit/:id', component: EditComponent },
  { path: 'list', component: ListComponent },
  { path: 'files', component: FilesComponent },
  { path: '', component: HomeComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
