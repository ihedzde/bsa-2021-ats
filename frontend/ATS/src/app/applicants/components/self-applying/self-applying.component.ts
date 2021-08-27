import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';
import { ActivatedRoute } from '@angular/router';
import { FileType } from 'src/app/shared/enums/file-type.enum';
import { CreateApplicant } from 'src/app/shared/models/applicants/create-applicant';
import { Tag } from 'src/app/shared/models/tags/tag';
import { VacancyFull } from 'src/app/shared/models/vacancy/vacancy-full';
import { ApplicantsService } from 'src/app/shared/services/applicants.service';
import { NotificationService } from 'src/app/shared/services/notification.service';
import { VacancyCandidateService } from 'src/app/shared/services/vacancy-candidate.service';
import { VacancyDataService } from 'src/app/shared/services/vacancy-data.service';
import { applicantGroup } from '../../validators/applicant-validator';

@Component({
  selector: 'app-self-applying',
  templateUrl: './self-applying.component.html',
  styleUrls: ['./self-applying.component.scss'],
})
export class SelfApplyingComponent {
  public allowedCvFileType = FileType.Pdf;

  public vacancyId: string = '';
  public vacancy: VacancyFull = new VacancyFull();
  public applicant: CreateApplicant = new CreateApplicant();
  public emailFilled: boolean = false;
  public email: string = '';
  public applied: boolean = false;

  public validationGroup: FormGroup | undefined = undefined;
  public validationEmailGroup: FormGroup = new FormGroup({
    email: new FormControl('', [
      Validators.required,
      Validators.email,
      Validators.pattern('^\\S{1,}@\\S{3,}\\.[a-z]+'),
    ]),
  });

  constructor(
    private readonly vacancyService: VacancyDataService,
    private readonly applicantsService: ApplicantsService,
    private readonly vacancyCandidateService: VacancyCandidateService,
    private readonly notificationsService: NotificationService,
    private readonly route: ActivatedRoute) {
    this.validationEmailGroup.disable();

    this.route.params.subscribe(({ id }) => {
      this.vacancyId = id;
      this.vacancyService.getVacancyNoAuth(id).subscribe(vacancy => {
        this.vacancy = vacancy;
        this.validationEmailGroup.enable();
      },
      _ => {
        this.notificationsService
          .showErrorMessage('Unavailed to get vacancy apply form. Please, try later');
      });
    });

    this.validationGroup = applicantGroup;
  }

  public updateTags(tags: Tag[]): void {
    this.applicant.tags.tagDtos = tags;
  }

  public checkEmail() {
    this.applicantsService
      .getApplicantByEmail(this.validationEmailGroup.controls['email'].value)
      .subscribe(result => {
        if (result) {
          this.vacancyCandidateService
            .PostVacancyCandidateNoAuth(this.vacancyId, result.id)
            .subscribe(_ => this.applied = true);
        }
        else {
          this.emailFilled = true;
          this.validationGroup?.controls['email'].disable();
        }
      });
  }

  public uploadApplicantCv(files: File[]): void {
    this.applicant.cv = files[0];
  }

  public createApplicant(): void {
    this.applicantsService
      .addSelfAppliedApplicant(this.applicant, this.vacancyId)
      .subscribe(
        _ => {
          this.applied = true;
        },
      );
  }

}
