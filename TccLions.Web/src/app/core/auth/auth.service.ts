import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { BehaviorSubject, Observable } from 'rxjs';
import { catchError, tap } from 'rxjs/operators';
import { ApplicationSettingsService } from '../settings/application-settings.service';
import { AuthResponse, MembroAuthResponse } from './auth.models';

@Injectable({
    providedIn: 'root'
})

export class AuthService {
    private readonly _membroSubject: BehaviorSubject<MembroAuthResponse | null> = new BehaviorSubject<MembroAuthResponse | null>(null);
    private apiUrl = this.appSettings.apiUrl;

    get membro$() {
        return this._membroSubject.asObservable();
    }

    constructor(private http: HttpClient, private router: Router, private appSettings: ApplicationSettingsService) { }

    login(username: string, password: string): Observable<AuthResponse> {
        return this.http.post<AuthResponse>(`${this.apiUrl}/api/auth/login`,
            {
                nome: username,
                senha: password
            }).pipe(
                tap(response => {
                    if (response.token)
                        localStorage.setItem('token', response.token);

                    this._membroSubject.next(response.membro);
                }), catchError(error => {
                    throw error;
                })
            );
    }

    logout() {
        localStorage.removeItem('token');
        this.router.navigate(['/login']);
    }

    isAuthenticated(): boolean {
        const token = localStorage.getItem('token');

        return !!token;
    }

    isAdmin(): boolean {
        var isAdmin = false
        this.membro$.subscribe(response => isAdmin = response?.permissoes.some(p => p.nome === 'Admin') ?? false)

        return isAdmin;
    }
}
