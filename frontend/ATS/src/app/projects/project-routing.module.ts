import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { ProjectsListComponent } from './components/projects-list/projects-list.component';


const routes: Routes = [
  { path: 'projects', component: ProjectsListComponent, pathMatch: 'full' },
];

@NgModule({
  declarations: [],
  exports: [RouterModule],
  imports: [CommonModule, RouterModule.forChild(routes)],
})
export class ProjectRoutingModule {}
