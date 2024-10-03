import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { BehaviorSubject, Observable } from 'rxjs';
import { tap } from 'rxjs/operators';
import { ApplicationSettingsService } from '../settings/application-settings.service';
import { AuthResponse, MembroAuthResponse } from './auth.models';
import { jwtDecode } from 'jwt-decode';

@Injectable({
    providedIn: 'root'
})

export class AuthService {
    private readonly _membroSubject: BehaviorSubject<MembroAuthResponse | null> = new BehaviorSubject<MembroAuthResponse | null>(null);
    private apiUrl = this.appSettings.apiUrl;

    get membro$() {
        return this._membroSubject.asObservable();
    }

    constructor(private http: HttpClient, private router: Router, private appSettings: ApplicationSettingsService) {
        this.loadMemberInfo();
    }

    login(username: string, password: string): Observable<AuthResponse> {
        return this.http.post<AuthResponse>(`${this.apiUrl}/api/v1/auth/login`,
            {
                nomeOuEmail: username,
                senha: password
            }).pipe(
                tap(response => {
                    if (response && response.token) {
                        localStorage.setItem('token', response.token);
                        this.loadMemberInfo();
                    }
                })
            );
    }

    getToken(): string | null {
        return localStorage.getItem('token');
    }

    logout() {
        localStorage.removeItem('token');
        this._membroSubject.next(null);
    }

    isAuthenticated(): boolean {
        const token = localStorage.getItem('token');

        return !!token;
    }

    private loadMemberInfo() {
        const token = this.getToken();

        if (token) {
            const tokenDecoded = jwtDecode(token);

            this._membroSubject.next({
                nome: tokenDecoded?.sub ?? '',
                permissoes: this.extractRoles(tokenDecoded)
            })
        }
    }

    private extractRoles(decodedToken: any): string[] {
        const rolesClaimType = 'http://schemas.microsoft.com/ws/2008/06/identity/claims/role';

        return decodedToken[rolesClaimType] ? [decodedToken[rolesClaimType]] : [];
    }

    public isTokenExpired(): boolean | void {
        const token = this.getToken()

        if (!token) {
            console.error("Token not found")
            return
        }

        const tokenDecodedExp = jwtDecode(token).exp;

        if (!tokenDecodedExp) {
            return
        }

        const expirationDate = tokenDecodedExp * 1000;
        const currentTime = Date.now();

        return expirationDate < currentTime;
    }
}
