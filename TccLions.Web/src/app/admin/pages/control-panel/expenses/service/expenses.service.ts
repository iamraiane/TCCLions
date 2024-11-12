import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ExpensesEndpoints } from '../expenses.endpoints';
import { BehaviorSubject, Observable, tap } from 'rxjs';
import { Expense } from '../expenses.models';
import { ApplicationSettingsService } from '../../../../../core/settings/application-settings.service';

@Injectable({
  providedIn: 'root'
})
export class ExpensesService {

  private apiUrl = this._settings.apiUrl;
  private readonly _expenses: BehaviorSubject<Expense[]> = new BehaviorSubject<Expense[]>([]);

  get expenses$(): Observable<Expense[]> {
    return this._expenses.asObservable();
  }

  constructor(private _httpClient: HttpClient, private _settings: ApplicationSettingsService) { }

  get(): Observable<Expense[]> {
    return this._httpClient.get<Expense[]>(ExpensesEndpoints.endpoints["get"](this.apiUrl)).pipe(
      tap(expenses => this._expenses.next(expenses))
    )
  }

  delete(id: string): Observable<void> {
    return this._httpClient.delete<void>(ExpensesEndpoints.endpoints["delete"](this.apiUrl, id)).pipe(
      tap(() => {
        let expenses = this._expenses.value;
        expenses = expenses.filter(expenses => expenses.id !== id);
        this._expenses.next(expenses);
      })
    );
  }

  create(expense: Expense): Observable<Expense> {
    return this._httpClient.post<Expense>(ExpensesEndpoints.endpoints["create"](this.apiUrl), expense).pipe(
      tap(() => {
        this.get().subscribe();
      })
    );
  }
}
