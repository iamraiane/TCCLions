import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ComissionsEndpoints } from '../comissions.endpoints';
import { BehaviorSubject, Observable, tap } from 'rxjs';
import { Comission, CreateCommission } from '../comissions.models';
import { ApplicationSettingsService } from '../../../../../core/settings/application-settings.service';

@Injectable({
  providedIn: 'root'
})
export class ComissionsService {

  private apiUrl = this._settings.apiUrl;
  private readonly _comissions: BehaviorSubject<Comission[]> = new BehaviorSubject<Comission[]>([]);

  get comissions$(): Observable<Comission[]> {
    return this._comissions.asObservable();
  }

  constructor(private _httpClient: HttpClient, private _settings: ApplicationSettingsService) { }

  get(memberName: string): Observable<Comission[]> {
    var params = new HttpParams();
    params = params.append('nomeDoMembro', memberName);

    return this._httpClient.get<Comission[]>(ComissionsEndpoints.endpoints["get"](this.apiUrl), { params: params }).pipe(
      tap(comissions => this._comissions.next(comissions))
    )
  }

  delete(id: string): Observable<void> {
    return this._httpClient.delete<void>(ComissionsEndpoints.endpoints["delete"](this.apiUrl, id)).pipe(
      tap(() => {
        let comissions = this._comissions.value;
        comissions = comissions.filter(comission => comission.id !== id);
        this._comissions.next(comissions);
      })
    );
  }

  create(request: CreateCommission): Observable<string> {
    return this._httpClient.post<string>(ComissionsEndpoints.endpoints["create"](this.apiUrl), request).pipe(
      tap(
        () => this.get('').subscribe(),
      )
    );
  }

  edit(request: any, commissionId: string): Observable<string> {
    return this._httpClient.put<string>(ComissionsEndpoints.endpoints["edit"](this.apiUrl, commissionId), request).pipe(
      tap(
        () => this.get('').subscribe(),
      )
    );
  }
}
