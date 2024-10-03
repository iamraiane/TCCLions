import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable, tap } from 'rxjs';
import { TipoDespesa } from './expense-types.models';
import { HttpClient } from '@angular/common/http';
import { ApplicationSettingsService } from '../../../../core/settings/application-settings.service';
import { ExpensesTypesEndpoints } from './expense-types.endpoints';

@Injectable({
  providedIn: 'root'
})
export class ExpenseTypesService {
  private readonly apiUrl = this._appSettings.apiUrl;
  private _expenseTypes: BehaviorSubject<TipoDespesa[]> = new BehaviorSubject<TipoDespesa[]>([]);
  
  constructor(private _httpCliente: HttpClient, private _appSettings: ApplicationSettingsService) { }

  get expenseType$(): Observable<TipoDespesa[]> {
    return this._expenseTypes.asObservable();
  }

  getAll(): Observable<TipoDespesa[]> {
    return this._httpCliente.get<TipoDespesa[]>(ExpensesTypesEndpoints.endpoints['getAll'](this.apiUrl)).pipe(
      tap(
        response => this._expenseTypes.next(response)
      )
    );
  }
}