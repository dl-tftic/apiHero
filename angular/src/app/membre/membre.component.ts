import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Characters, Hero } from '../models/hero';
import { HeroMappers } from '../models/hero-mappers';
import { Team } from '../models/team';
import { HeroesService } from '../services/heroes.service';
import { UserService } from '../services/user.service';

@Component({
  selector: 'app-membre',
  templateUrl: './membre.component.html',
  styleUrls: ['./membre.component.scss']
})
export class MembreComponent implements OnInit
{

  heroes: Characters[];
  formSearch: FormGroup;
  userTeams: Team[];
  // tslint:disable-next-line: variable-name
  private _selectedTeam: string;

  constructor(private heroesService: HeroesService,
              private builder: FormBuilder,
              private userService: UserService) { }

  ngOnInit(): void {
    this.heroes = this.heroesService.getAllHeroes();
    this.formSearch = this.builder.group(
      {
        in_heroSearch: this.builder.control('', [Validators.required])
      }
      );
  }

  public get user(): UserService
  {
    return this.userService;
  }

  public getUserTeams(): Team[]
  {
    this.userTeams = this.userService.getTeams();
    return this.userService.getTeams();
  }

  public selectTeam(select: HTMLSelectElement): void
  {
    switch (select.value)
    {
      case 'doNothing':
              {
                this._selectedTeam = '';
                console.log('ne rien faire'); break;
              }
      case 'AddTeam':
              {
                // tslint:disable-next-line: prefer-const
                let tmName: string = prompt('Nom de l\'équipe');
                console.log('new team');
                this.userService.ajouterTeam(tmName);
                this.getUserTeams();
                this._selectedTeam = '';
                break;
              }
      default:
              {
                this._selectedTeam = select.value;
                console.log('select default');
                break;
              }
    }
  }

  AjouterHero(h: Hero): void
  {

  }

  public SearchHero(): void
  {
    console.log(this.formSearch);
    if (this.formSearch.valid)
    {
      // this.heroes = [];
      // this.heroes = this.heroesService.search(this.formSearch.get('in_heroSearch').value);
      // this.heroes = this.heroes.concat(this.heroesService.search(this.formSearch.get('in_heroSearch').value));
      // tslint:disable-next-line: max-line-length
      this.heroesService.getFromSearch(this.formSearch.get('in_heroSearch').value).subscribe(data => {this.heroes = HeroMappers.responseToCharacters(data) , console.log('data: ' + data.response); } );
      console.log(this.heroes);
    }
    else { console.log('formSearch invalid'); }
  }

  public refresh(): void
  {
    this.heroes = this.heroesService.refreshHeroes();
  }

  public drag(ev): void
  {
    ev.dataTransfer.setData('text', ev.target.id);
    // console.log('drag');
  }

  public drop(ev): void
  {
    console.log('drop');
    ev.preventDefault();
    // tslint:disable-next-line: prefer-const
    let data = ev.dataTransfer.getData('text');
    ev.target.value = data;
    // console.log(ev);
  }

  public allowDrop(ev): void
  {
    ev.preventDefault();
    // console.log(ev);
  }

}
