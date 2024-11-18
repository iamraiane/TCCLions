import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { CommissionTypesEndpoints } from './commission-types.endpoints';
import { ApplicationSettingsService } from '../../../../core/settings/application-settings.service';
import { BehaviorSubject, Observable, tap } from 'rxjs';
import { CreateCommissionType, EditCommissionType, TipoComissao } from './commission-types.models';

@Injectable({
  providedIn: 'root'
})
export class CommissionTypesService {
  private readonly apiUrl = this._appSettings.apiUrl;
  private _commissionTypes: BehaviorSubject<TipoComissao[]> = new BehaviorSubject<TipoComissao[]>([]);

  constructor(private _httpClient: HttpClient, private _appSettings: ApplicationSettingsService) { }

  get commissionTypes$(): Observable<TipoComissao[]> {
    return this._commissionTypes.asObservable();
  }

  getAll(): Observable<TipoComissao[]> {
    return this._httpClient.get<TipoComissao[]>(CommissionTypesEndpoints.endpoints['getAll'](this.apiUrl)).pipe(
      tap(
        response => this._commissionTypes.next(response)
      )
    );
  }

  create(createCommissionType: CreateCommissionType): Observable<string> {
    return this._httpClient.post<string>(CommissionTypesEndpoints.endpoints['create'](this.apiUrl), createCommissionType).pipe(
      tap(
        () => {
          this.getAll().subscribe();
        }
      )
    );
  }

  delete(commissionTypeId: string) {
    let httpParams: HttpParams = new HttpParams();
    httpParams = httpParams.set('id', commissionTypeId);

    return this._httpClient.delete(CommissionTypesEndpoints.endpoints['delete'](this.apiUrl, commissionTypeId), { params: httpParams }).pipe(
      tap(
        () => {
          const currentCommissionTypes = this._commissionTypes.value;
          const updatedCommissionTypes = currentCommissionTypes.filter(commissionType => commissionType.id !== commissionTypeId);
          this._commissionTypes.next(updatedCommissionTypes);
        }
      )
    );
  }

  edit(commissionTypeId: string, editCommissionType: EditCommissionType): Observable<void> {
    return this._httpClient.put<void>(CommissionTypesEndpoints.endpoints['edit'](this.apiUrl, commissionTypeId), editCommissionType).pipe(
      tap(
        () => {
          const currentCommissionTypes = this._commissionTypes.value;
          const updatedCommissionTypes = currentCommissionTypes.map(commissionType => {
            if (commissionType.id === commissionTypeId) {
              return { ...commissionType, descricao: editCommissionType.descricao };
            }
            return commissionType;
          });
          this._commissionTypes.next(updatedCommissionTypes);
        }
      )
    );
  }
}
