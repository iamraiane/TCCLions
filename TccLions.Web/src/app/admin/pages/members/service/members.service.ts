import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { MembersEndpoints } from '../members.endpoints';
import { ApplicationSettingsService } from '../../../../core/settings/application-settings.service';
import { BehaviorSubject, tap } from 'rxjs';
import { Member } from '../members.models';

@Injectable({
  providedIn: 'root'
})
export class MembersService {
  private readonly apiUrl = this._applicationSettings.apiUrl;
  private _members: BehaviorSubject<Member[]> = new BehaviorSubject<Member[]>([]);

  get members$() {
    return this._members.asObservable();
  }

  constructor(private _httpClient: HttpClient, private _applicationSettings: ApplicationSettingsService) { }

  get() {
    return this._httpClient.get<Member[]>(MembersEndpoints.endpoints['get'](this.apiUrl)).pipe(
      tap((members: any) => this._members.next(members))
    )
  }
}
