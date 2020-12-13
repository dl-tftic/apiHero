import { JsonPipe } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { IUser } from '../models/iuser';
import { UserService } from '../services/user.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit
{

  user: IUser;
  showIsConnected: boolean;
  form: FormGroup;

  constructor(private builder: FormBuilder, private router: Router, public userService: UserService) { }

  ngOnInit(): void
  {
    this.showIsConnected = this.userService.userIsConnected();
    this.form = this.builder.group(
                              {
                                lg_pseudo: ['', Validators.required],
                                lg_pwd: ['', Validators.required]
                              }
    );
  }

  login(): void
  {
    if (this.userService.currentUser !== null)
    {
        if (
              (this.form.get('lg_pseudo').value === this.userService.currentUser.pseudo)
              && (this.form.get('lg_pwd').value === this.userService.currentUser.pwd)
            )
            {
                this.showIsConnected = true;
                const user: IUser = this.userService.currentUser;
                user.connecte = true;
                localStorage.setItem('user', JSON.stringify(user));
                this.router.navigate(['acceuil']).then();
            }

    }
  }

  logout(): void
  {
    this.showIsConnected = false;
    const user: IUser = this.userService.currentUser;
    user.connecte = false;
    localStorage.setItem('user', JSON.stringify(user));
  }
}
