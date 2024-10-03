import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ExpensesEndPoints } from '../expenses.endpoints';
import { BehaviorSubject, Observable , tap} from 'rxjs';
import { Expense } from '../despesas.models';
import { ApplicationSettingsService } from '../../../../../core/settings/application-settings.service';

@Injectable({
  providedIn: 'root'
})
export class ExpensesService {

  private apiUrl = this._settings.apiUrl;
  private readonly _comissions: BehaviorSubject<Expenses[]> = new BehaviorSubject<Expenses[]>([]);

  get expenses$(): Observable<Expense[]>{
    return this._expenses.asObservable();
  }

  constructor(private _httpClient: HttpClient, private _settings: ApplicationSettingsService) { }

  get (memberName: string): Observable<Expense[]> {
    var params = new HttpParams();
    params = params.append('nomeDoMembro', memberName);

    return this._httpClient.get<Expense[]>(ExpensesEndpoints.endpoints["get"](this.apiUrl), {params: params}).pipe(
      tap(expenses => this._expenses.next(expenses))
    )
  }

  delete(id: string): Observable<void>{
    return this._httpClient.delete<void>(ExpensesEndpoints.endpoints["delete"](this.apiUrl, id)).pipe(
      tap(() => {
        let expenses = this._expenses.value;
        expenses = expenses.filter(expenses => expenses.id !== id);
        this._expenses.next(expenses);
      })
    );
  }
}
