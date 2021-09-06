import { Injectable } from '@angular/core';
import { HttpClientService } from 'src/app/shared/services/http-client.service';
import { CreateInterview } from '../models/create-interview.model';
import { Interview } from '../models/interview.model';

@Injectable({
  providedIn: 'root',
})
export class InterviewsService {
  public routePrefix = '/interviews';

  constructor(private httpService: HttpClientService) { }

  public getInterviews() {
    return this.httpService.getFullRequest<Interview[]>(`${this.routePrefix}`);
  }

  public getInterview(id: number) {
    return this.httpService.getFullRequest<Interview>(`${this.routePrefix}/${id}`);
  }

  public createInterview(post: CreateInterview) {
    return this.httpService.postFullRequest<CreateInterview>(`${this.routePrefix}`, post);
  }

  public deleteInterview(interview: Interview) {
    return this.httpService.deleteFullRequest<Interview>(`${this.routePrefix}/${interview.id}`);
  }

  public updateInterview(interview: Interview) {
    return this.httpService.putFullRequest<Interview>(`${this.routePrefix}`, interview);
  }
}
