import { HttpClient } from '@angular/common/http';
import { isSyntheticPropertyOrListener } from '@angular/compiler/src/render3/util';
import { Injectable } from '@angular/core';
import { IHero } from '../models/ihero';
import { Characters, Hero } from '../models/hero';
import { HeroMappers } from '../models/hero-mappers';
import { Subscribable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})

export class HeroesService
{

  // tslint:disable-next-line: variable-name
  private _url = 'https://superheroapi.com/api.php/';
  // tslint:disable-next-line: variable-name
  private _key = '10207990362752268';
  // tslint:disable-next-line: variable-name
  private _search = '/search/';
  // tslint:disable-next-line: variable-name
  private _id = '';
  // tslint:disable-next-line: variable-name
  private _powerstats = '/powerstats';
  // tslint:disable-next-line: variable-name
  private _biography = '/biography';
  // tslint:disable-next-line: variable-name
  private _appearance = '/appearance';
  // tslint:disable-next-line: variable-name
  private _work = '/work';
  // tslint:disable-next-line: variable-name
  private _connections = '/connections';
  // tslint:disable-next-line: variable-name
  private _image = '/image';
  // tslint:disable-next-line: variable-name no-inferrable-types
  private _charcaters_max: number = 731;
  // tslint:disable-next-line: variable-name
  private _searchHeroes: Characters[] = [];

  private get _urlEnv(): string { return environment.apiBaseUrl + environment.apiAccessToken; }

  heroes: Characters[] = [];

  constructor(private http: HttpClient)
  {
    this.initiateHeroes();
  }

  private initiateHeroes(): void
  {
    for (let i = 1; i <= 10; i++)
    {
      const finalUrl = this.getUrlById(ApiUrl.Id, i);
      this.http.get(finalUrl).subscribe((data) => this.heroes.push(HeroMappers.responseToCharacter(data)) );
      console.log(finalUrl);
    }
  }

  private getUrlById(choice: ApiUrl, id: number): string
  {
    // tslint:disable-next-line: prefer-const
    let url = this._urlEnv + '/';
    let endUrl = '';

    switch (choice)
    {
      case ApiUrl.Search : { endUrl = this._search; break; }
      case ApiUrl.Id : { endUrl = this._id; break; }
      case ApiUrl.Image : { endUrl = this._image; break; }
      case ApiUrl.PowerStats : { endUrl = this._powerstats; break; }
      case ApiUrl.Biography : { endUrl = this._biography; break; }
      case ApiUrl.Appearance : { endUrl = this._appearance; break; }
      case ApiUrl.Work : { endUrl = this._work; break; }
      case ApiUrl.Connetions : { endUrl = this._connections; break; }
    }

    return url + id.toString() + endUrl;
  }

  private getUrlByName(value: string): string
  {
    return this._url + this._key + this._search + value;
  }

  public refreshHeroes(): Characters[]
  {
    return this.heroes;
  }

  getAllHeroes(): Characters[]
  {
    return this.heroes;
  }

  public search(searchName: string): Characters[]
  {
    // tslint:disable-next-line: max-line-length
    this.getFromSearch(searchName).subscribe(data => {this._searchHeroes = HeroMappers.responseToCharacters(data) , console.log('data: ' + data.response); } );
    console.log(this._searchHeroes);
    return this._searchHeroes;
  }

  public getFromSearch(searchName: string): Subscribable<any>
  {
    const finalUrl = this.getUrlByName(searchName);
    return this.http.get(finalUrl);
  }
}

enum ApiUrl
{
  Search = 1,
  Id = 2,
  PowerStats = 3,
  Biography = 4,
  Appearance = 5,
  Work = 6,
  Connetions = 7,
  Image = 8
}
