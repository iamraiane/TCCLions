import { HttpClient, HttpParams } from '@angular/common/http';
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

  get(search: string, showDisabled: boolean) {
    var httpParams = new HttpParams();
    httpParams = httpParams.append('nomeDoMembro', search);
    httpParams = httpParams.append('mostrarDesabilitados', showDisabled);

    return this._httpClient.get<Member[]>(MembersEndpoints.endpoints['get'](this.apiUrl), { params: httpParams }).pipe(
      tap((members: any) => this._members.next(members))
    )
  }
}
