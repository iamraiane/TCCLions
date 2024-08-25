import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { MembersEndpoints } from '../members.endpoints';
import { ApplicationSettingsService } from '../../../../core/settings/application-settings.service';
import { BehaviorSubject, tap } from 'rxjs';
import { CreateMember, Member, MemberDetails } from '../members.models';

@Injectable({
  providedIn: 'root'
})
export class MembersService {
  private readonly apiUrl = this._applicationSettings.apiUrl;
  private _members: BehaviorSubject<Member[]> = new BehaviorSubject<Member[]>([]);
  private _pagination: BehaviorSubject<{ count: number, pageIndex: number, pageSize: number }> = new BehaviorSubject<{ count: number, pageIndex: number, pageSize: number }>({ count: 0, pageIndex: 0, pageSize: 0 });

  get members$() {
    return this._members.asObservable();
  }

  get pagination$() {
    return this._pagination.asObservable();
  }

  constructor(private _httpClient: HttpClient, private _applicationSettings: ApplicationSettingsService) { }

  get(search: string, showDisabled: boolean, pageSize: number, pageIndex: number) {
    var httpParams = new HttpParams();
    httpParams = httpParams.append('nomeDoMembro', search);
    httpParams = httpParams.append('mostrarDesabilitados', showDisabled);
    httpParams = httpParams.append('tamanhoDaPagina', pageSize);
    httpParams = httpParams.append('indiceDaPagina', pageIndex);

    return this._httpClient.get<Member[]>(MembersEndpoints.endpoints['get'](this.apiUrl), { params: httpParams }).pipe(
      tap((members: any) => {
        this._members.next(members.dados)
        this._pagination.next({ count: members.quantidade, pageIndex: members.indiceDaPagina, pageSize: members.tamanhoDaPagina })
      })
    )
  }

  getDetails(id: string) {
    return this._httpClient.get<MemberDetails>(MembersEndpoints.endpoints['getDetails'](this.apiUrl, id))
  }

  create(member: CreateMember) {
    return this._httpClient.post(MembersEndpoints.endpoints['create'](this.apiUrl), member)
  }

  update(id: string, member: MemberDetails) {
    return this._httpClient.put(MembersEndpoints.endpoints['update'](this.apiUrl, id), member)
  }

  delete(id: string) {
    return this._httpClient.delete(MembersEndpoints.endpoints['delete'](this.apiUrl, id))
  }

  disable(id: string) {
    return this._httpClient.post(MembersEndpoints.endpoints['disable'](this.apiUrl, id), null)
  }

  enable(id: string) {
    return this._httpClient.post(MembersEndpoints.endpoints['enable'](this.apiUrl, id), null)
  }
}
