import { Component, Output, EventEmitter, Input } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Observable } from 'rxjs';
import { Applicant } from 'src/app/shared/models/applicants/applicant';
import { CreateApplicantComponent } from '../create-applicant/create-applicant.component';

@Component({
  selector: 'app-applicants-head',
  templateUrl: './applicants-head.component.html',
  styleUrls: ['./applicants-head.component.scss'],
})
export class ApplicantsHeadComponent {
  public searchValue = '';
  public isFollowedPage = false;

  @Output() public search = new EventEmitter<string>();
  @Output() public applicantCreated = new EventEmitter<Observable<Applicant>>();
  @Output() public togglePage = new EventEmitter<boolean>();

  constructor(private readonly dialog: MatDialog) {}

  public applySearchValue(): void {
    this.search.emit(this.searchValue);
  }

  public showApplicantsCreateDialog(): void {
    const dialogRef = this.dialog.open(CreateApplicantComponent, {
      width: '532px',
      height: '95vh',
      autoFocus: false,
    });

    this.applicantCreated.emit(dialogRef.afterClosed());
  }

  public toggleFollowedOrAll(isFollowedPage: boolean): void {
    this.isFollowedPage = isFollowedPage;
    this.togglePage.emit(isFollowedPage);
  }
}
