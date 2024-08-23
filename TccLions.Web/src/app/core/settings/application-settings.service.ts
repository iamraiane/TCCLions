import { Injectable } from "@angular/core";

@Injectable({
    providedIn: 'root'
})

export class ApplicationSettingsService {
    get apiUrl() {
        return "http://localhost:5012";
    }
}