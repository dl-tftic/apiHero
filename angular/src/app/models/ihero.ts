import { Appearance, Biography, Connections, Powerstats, Work, Image } from "./hero";

export interface IHero
{
    name: string;
    img: string;
}

export interface IPowerstats {
    intelligence: string;
    strength: string;
    speed: string;
    durability: string;
    power: string;
    combat: string;
}

export interface IBiography {
    fullName: string;
    alterEgos: string;
    aliases: string[];
    placeOfBirth: string;
    firstAppearance: string;
    publisher: string;
    alignment: string;
}

export interface IAppearance {
    gender: string;
    race: string;
    height: string[];
    weight: string[];
    eyeColor: string;
    hairColor: string;
}

export interface IWork {
    occupation: string;
    base: string;
}

export interface IConnections {
    groupAffiliation: string;
    relatives: string;
}

export interface IImage {
    url: string;
}

export interface ICharacters {
    response: string;
    id: string;
    name: string;
    powerstats: Powerstats;
    biography: Biography;
    appearance: Appearance;
    work: Work;
    connections: Connections;
    image: Image;
}
