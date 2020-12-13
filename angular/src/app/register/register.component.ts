import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, ValidationErrors, ValidatorFn, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { IUser } from '../models/iuser';
import { confirmPasswordValidator, Validation } from './../models/validation';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {

  form: FormGroup;

  constructor(private builder: FormBuilder, private route: Router) { }

  ngOnInit(): void
  {
    this.form = this.builder.group(
      {
        Name: ['', [Validators.required]],
        FirstName: ['', [Validators.required]],
        Pseudo: ['', [Validators.required]],
        Password: ['', [Validators.required]],
        ConfirmPassword: ['', [Validators.required]]
      },
      {
        validators: confirmPasswordValidator
      }
      );
  }

  register(): void
  {
    console.log(this.form.value);
    if (this.form.valid)
    {
      localStorage.setItem('user', JSON.stringify(
                                  {
                                    firstname: this.form.get('FirstName').value,
                                    name: this.form.get('Name').value,
                                    pseudo: this.form.get('Pseudo').value,
                                    pwd: this.form.get('Password').value,
                                    connecte: true
                                  } as IUser));
      this.route.navigate(['acceuil']);
    }
  }

}

