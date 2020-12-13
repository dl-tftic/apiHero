import { Characters } from './hero';
import { ITeam } from './iteam';

export class Team implements ITeam
{
    public name: string;
    // tslint:disable-next-line: variable-name
    private _heroes: Characters[];
    // tslint:disable-next-line: no-inferrable-types
    private maxHeroes: number = 5;

    public get heroes(): Characters[] { return this._heroes; }
    public get leader(): Characters { return this._heroes[0] ?? null; }

    constructor(name: string, heroes?: Characters[])
    {
        this.name = name;
        if (heroes !== undefined)
        {
            if (this.heroes.length > this.maxHeroes)
            {
                throw new Error('Trop de membre dans cette équipe');
            }
            this._heroes = heroes;
        }
        else
        {
            this._heroes = [];
        }
    }

    public AddHero(hero: Characters): boolean
    {
        if (this.heroes.length < this.maxHeroes && !(this._heroes.includes(hero)))
        {
            this._heroes.push(hero);
            return true;
        }
        else { return false; }
    }
}
