import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ApplicationSettingsService } from '../../../../../core/settings/application-settings.service';
import { CreateTipoDespesa, EditTipoDespesa, TipoDespesa } from '../expense-types.modals';
import { BehaviorSubject, Observable, tap } from 'rxjs';
import { ExpenseTypesEndpoints } from '../expense-types.endpoints';

@Injectable({
  providedIn: 'root'
})
export class ExpenseTypesService {
  private readonly apiUrl = this._appSettings.apiUrl;
  private _expenseTypes: BehaviorSubject<TipoDespesa[]> = new BehaviorSubject<TipoDespesa[]>([]);

  constructor(private _httpClient: HttpClient, private _appSettings: ApplicationSettingsService) { }

get expenseTypes$(): Observable<TipoDespesa[]> {
    return this._expenseTypes.asObservable();
  }

  getAll(): Observable<TipoDespesa[]> {
    return this._httpClient.get<TipoDespesa[]>(ExpenseTypesEndpoints.endpoints['getAll'](this.apiUrl)).pipe(
      tap(
        response => this._expenseTypes.next(response)
      )
    );
  }

  create(createexpenseType: CreateTipoDespesa): Observable<string> {
    return this._httpClient.post<string>(ExpenseTypesEndpoints.endpoints['create'](this.apiUrl), createexpenseType).pipe(
      tap(
        expenseTypeId => {
          const currentexpenseTypes = this._expenseTypes.value;
          this._expenseTypes.next([...currentexpenseTypes, { id: expenseTypeId, descricao: createexpenseType.descricao }]);
        }
      )
    );
  }

  delete(expenseTypeId: string) {
    let httpParams: HttpParams = new HttpParams();
    httpParams = httpParams.set('id', expenseTypeId);

    return this._httpClient.delete(ExpenseTypesEndpoints.endpoints['delete'](this.apiUrl, expenseTypeId), { params: httpParams }).pipe(
      tap(
        () => {
          const currentexpenseTypes = this._expenseTypes.value;
          const updatedexpenseTypes = currentexpenseTypes.filter(expenseType => expenseType.id !== expenseTypeId);
          this._expenseTypes.next(updatedexpenseTypes);
        }
      )
    );
  }

  edit(expenseTypeId: string, editexpenseType: EditTipoDespesa): Observable<void> {
    return this._httpClient.put<void>(ExpenseTypesEndpoints.endpoints['edit'](this.apiUrl, expenseTypeId), editexpenseType).pipe(
      tap(
        () => {
          const currentexpenseTypes = this._expenseTypes.value;
          const updatedexpenseTypes = currentexpenseTypes.map(expenseType => {
            if (expenseType.id === expenseTypeId) {
              return { ...expenseType, descricao: editexpenseType.descricao };
            }
            return expenseType;
          });
          this._expenseTypes.next(updatedexpenseTypes);
        }
      )
    );
  }
}
