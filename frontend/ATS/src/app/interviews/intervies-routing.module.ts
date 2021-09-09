import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [];

@NgModule({
  exports: [RouterModule],
  imports: [CommonModule, RouterModule.forChild(routes)],
})
export class InterviesRoutingModule { }
