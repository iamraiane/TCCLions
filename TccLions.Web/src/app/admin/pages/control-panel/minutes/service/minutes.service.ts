import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable, tap } from 'rxjs';
import { ApplicationSettingsService } from '../../../../../core/settings/application-settings.service';
import { CreateMinute, Minute } from '../minutes.models';
import { MinutesEndpoints } from '../minutes.endpoints';

@Injectable({
  providedIn: 'root'
})
export class MinutesService {

  private apiUrl = this._settings.apiUrl;
  private readonly _minutes: BehaviorSubject<Minute[]> = new BehaviorSubject<Minute[]>([]);
  private _pagination: BehaviorSubject<{ count: number, pageIndex: number, pageSize: number }> = new BehaviorSubject<{ count: number, pageIndex: number, pageSize: number }>({ count: 0, pageIndex: 0, pageSize: 0 });

  get minutes$(): Observable<Minute[]> {
    return this._minutes.asObservable();
  }

  get pagination$() {
    return this._pagination.asObservable();
  }

  constructor(private _httpClient: HttpClient, private _settings: ApplicationSettingsService) { }

  get(): Observable<{ count: number, pageIndex: number, pageSize: number, dados: Minute[] }> {
    // var params = new HttpParams();
    // params = params.append('nomeDoMembro', memberName);

    return this._httpClient.get<{ count: number, pageIndex: number, pageSize: number, dados: Minute[] }>(MinutesEndpoints.endpoints["get"](this.apiUrl)).pipe(
      tap(minutes => {
        this._minutes.next(minutes.dados);
        this._pagination.next({ count: minutes.count, pageIndex: minutes.pageIndex, pageSize: minutes.pageSize });
      })
    )
  }

  delete(id: string): Observable<void> {
    return this._httpClient.delete<void>(MinutesEndpoints.endpoints["delete"](this.apiUrl, id)).pipe(
      tap(() => {
        let comissions = this._minutes.value;
        comissions = comissions.filter(comission => comission.id !== id);
        this._minutes.next(comissions);
      })
    );
  }

  create(request: CreateMinute): Observable<string> {
    return this._httpClient.post<string>(MinutesEndpoints.endpoints["create"](this.apiUrl), request).pipe(
      tap(
        () => this.get().subscribe(),
      )
    );
  }
}
