import { IAppearance, IBiography, ICharacters, IConnections, IHero, IImage, IPowerstats, IWork } from './ihero';

export class Hero implements IHero {
    name: string;
    img: string;
}

export class Powerstats implements IPowerstats
{
    intelligence: string;
    strength: string;
    speed: string;
    durability: string;
    power: string;
    combat: string;
}

export class Biography implements IBiography
{
    fullName: string;
    alterEgos: string;
    aliases: string[];
    placeOfBirth: string;
    firstAppearance: string;
    publisher: string;
    alignment: string;
}

export class Appearance implements IAppearance
{
    gender: string;
    race: string;
    height: string[];
    weight: string[];
    eyeColor: string;
    hairColor: string;
}

export class Work implements IWork
{
    occupation: string;
    base: string;
}

export class Connections implements IConnections
{
    groupAffiliation: string;
    relatives: string;
}

export class Image implements IImage
{
    url: string;
}

export class Characters implements ICharacters
{
    response: string;
    id: string;
    name: string;
    powerstats: Powerstats;
    biography: Biography;
    appearance: Appearance;
    work: Work;
    connections: Connections;
    image: Image;

    constructor()
    {
        this.powerstats = new Powerstats();
        this.biography = new Biography();
        this.appearance = new Appearance();
        this.work = new Work();
        this.connections = new Connections();
        this.image = new Image();
    }
}
