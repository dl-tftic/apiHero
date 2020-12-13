import { Component, OnInit } from '@angular/core';
import { IUser } from '../models/iuser';
import { UserService } from '../services/user.service';

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.scss']
})
export class MenuComponent implements OnInit {

  showRegister: boolean;

  constructor(public userService: UserService) { }

  ngOnInit(): void
  {
    try
    {
      this.showRegister = this.userService.currentUser.connecte;
    } catch (error)
    {
      console.error(error);
      this.showRegister = true;
    }
  }

}
