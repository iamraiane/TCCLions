import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormControl, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatDialogModule, MatDialogRef } from '@angular/material/dialog';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { provideTranslocoScope, TranslocoModule } from '@jsverse/transloco';
import { CreateMinute } from '../../minutes.models';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { provideNativeDateAdapter } from '@angular/material/core';
import { MinutesService } from '../../service/minutes.service';

@Component({
  selector: 'app-create-minute',
  standalone: true,
  imports: [MatDatepickerModule, MatDialogModule, MatButtonModule, MatSelectModule, CommonModule, MatIconModule, TranslocoModule, FormsModule, ReactiveFormsModule, MatFormFieldModule, MatInputModule],
  providers: [
    provideTranslocoScope({ scope: 'control-panel/minutes/modals/create-minute', alias: 'createMinute' }),
    provideNativeDateAdapter()
  ],
  templateUrl: './create-minute.component.html'
})
export class CreateMinuteComponent {
  readonly minuteGroup: FormGroup = new FormGroup({
    title: new FormControl<string>('', [Validators.required, Validators.maxLength(255)]),
    description: new FormControl<string>('', [Validators.required]),
    writtenOn: new FormControl<null | Date>(null, [Validators.required]),
  })

  constructor(private dialogRef: MatDialogRef<CreateMinuteComponent>, public service: MinutesService) { }

  submit() {
    if (this.minuteGroup.invalid) return

    const minute: CreateMinute = {
      titulo: this.minuteGroup.get('title')?.value,
      descricao: this.minuteGroup.get('description')?.value,
      dataEscrita: this.minuteGroup.get('writtenOn')?.value
    }

    this.service.create(minute).subscribe(
      {
        next: () => {
          this.dialogRef.close();
        }
      }
    )
  }
}
