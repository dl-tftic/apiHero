import { Injectable } from '@angular/core';
import { IUser } from '../models/iuser';
import { Team } from '../models/team';

@Injectable({
  providedIn: 'root'
})
export class UserService
{

  // tslint:disable-next-line: variable-name
  private _currentUser: IUser;

  constructor() { }

  get currentUser(): IUser
  {
    if (localStorage.getItem('user'))
    {
      this._currentUser = JSON.parse(localStorage.getItem('user'));
      return this._currentUser;
    }
    return null;
  }

  set currentUser(value: IUser)
  {
    this._currentUser = value;
  }

  userIsConnected(): boolean
  {
    if (this.currentUser !== null)
    {
      return this.currentUser.connecte;
    }
    return false;
  }

  getTeams(): Team[]
  {
    return this._currentUser.teams;
  }

  public ajouterTeam(name: string): void
  {
    if (this._currentUser.teams === undefined)
    {
      this._currentUser.teams = [];
    }
    if (!this._currentUser.teams.find(t => t.name === name))
    {
      this._currentUser.teams.push(new Team(name));
    }
    localStorage.setItem('user', JSON.stringify(this._currentUser));
  }
}
