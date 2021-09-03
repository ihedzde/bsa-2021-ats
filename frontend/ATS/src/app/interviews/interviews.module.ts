import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ChunkPipe, InterviewsPageComponent } from './interviews-page/interviews-page.component';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatTableModule } from '@angular/material/table';
import { MatSortModule } from '@angular/material/sort';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatIconModule } from '@angular/material/icon';
import { MatPaginatorModule } from '@angular/material/paginator';
import { SharedModule } from '../shared/shared.module';
import { MatDialogModule } from '@angular/material/dialog';
import { MatSelectModule } from '@angular/material/select';
import { ReactiveFormsModule } from '@angular/forms';



@NgModule({
  declarations: [
    InterviewsPageComponent,
    ChunkPipe,
  ],
  imports: [
    CommonModule,
    MatButtonModule,
    MatFormFieldModule,
    MatInputModule,
    MatTableModule,
    MatSortModule,
    MatToolbarModule,
    MatIconModule,
    MatPaginatorModule,
    SharedModule,
    MatDialogModule,
    MatSelectModule,
    ReactiveFormsModule,
  ],
  exports: [
    InterviewsPageComponent,
  ],
})
export class InterviewsModule { }
