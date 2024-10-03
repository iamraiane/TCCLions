import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { CommissionTypesEndpoints } from './commission-types.endpoints';
import { ApplicationSettingsService } from '../../../../core/settings/application-settings.service';
import { BehaviorSubject, Observable, tap } from 'rxjs';
import { TipoComissao } from './commission-types.models';

@Injectable({
  providedIn: 'root'
})
export class CommissionTypesService {
  private readonly apiUrl = this._appSettings.apiUrl;
  private _commissionTypes: BehaviorSubject<TipoComissao[]> = new BehaviorSubject<TipoComissao[]>([]);

  constructor(private _httpCliente: HttpClient, private _appSettings: ApplicationSettingsService) { }

  get commissionTypes$(): Observable<TipoComissao[]> {
    return this._commissionTypes.asObservable();
  }

  getAll(): Observable<TipoComissao[]> {
    return this._httpCliente.get<TipoComissao[]>(CommissionTypesEndpoints.endpoints['getAll'](this.apiUrl)).pipe(
      tap(
        response => this._commissionTypes.next(response)
      )
    );
  }
}
