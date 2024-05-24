import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import {  MatFormFieldModule  } from '@angular/material/form-field';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [MatFormFieldModule, FormsModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {

}
