import { Characters, Hero } from './hero';

export class HeroMappers
{
    public static responseToHero(value: any): Hero
    {
        const hero: Hero = new Hero();

        // tslint:disable-next-line: no-string-literal
        if (value['response'] === 'success')
        {
            console.log('Success');
            hero.name = value.name;
            hero.img = value.image.url;
            console.log(hero);
        }

        return hero;
    }

    private static valToHero(value: any): Hero
    {
        const hero: Hero = new Hero();
        hero.name = value.name;
        hero.img = value.image.url;
        return hero;
    }

    public static responseToHeroes(value: any): Hero[]
    {
        const heroes: Hero[] = [];

        console.log('mappers');
        console.log(value);
        // tslint:disable-next-line: no-string-literal
        if (value['response'] === 'success')
        {
            // tslint:disable-next-line: prefer-for-of
            for (let i = 0; i < value.results.length; i++)
            {
                heroes.push(this.valToHero(value.results[i]));
            }
        }

        console.log(heroes);

        return heroes;
    }

    public static responseToCharacter(value: any): Characters
    {
        let char: Characters = new Characters();

        // tslint:disable-next-line: no-string-literal
        if (value['response'] === 'success')
        {
            console.log('Success');
            // char.name = value.name;
            // char.image.url = value.image.url;
            // console.log(char);
            char = this.valToCharacters(value);
        }

        return char;
    }

    private static valToCharacters(value: any): Characters
    {
        const char: Characters = new Characters();
        char.id = value.id;
        char.name = value.name;
        // Powerstats
        char.powerstats.intelligence = value.powerstats.intelligence;
        char.powerstats.strength = value.powerstats.strength;
        char.powerstats.speed = value.powerstats.speed;
        char.powerstats.durability = value.powerstats.durability;
        char.powerstats.power = value.powerstats.power;
        char.powerstats.combat = value.powerstats.combat;
        // image
        char.image.url = value.image.url;
        // biography
        char.biography.aliases = value.biography.aliases;
        char.biography.alignment = value.biography.alignment;
        char.biography.alterEgos = value.biography.alterEgos;
        char.biography.firstAppearance = value.biography.firstAppearance;
        char.biography.fullName = value.biography.fullName;
        char.biography.placeOfBirth = value.biography.placeOfBirth;
        char.biography.publisher = value.biography.publisher;
        // appearance
        char.appearance.eyeColor = value.appearance.eyeColor;
        char.appearance.gender = value.appearance.gender;
        char.appearance.hairColor = value.appearance.hairColor;
        char.appearance.height = value.appearance.height;
        char.appearance.race = value.appearance.race;
        char.appearance.weight = value.appearance.weight;
        // work
        char.work.base = value.work.base;
        char.work.occupation = value.work.occupation;
        // connections
        char.connections.groupAffiliation = value.connections.groupAffiliation;
        char.connections.relatives = value.connections.relatives;
        // this.work = new Work();
        // this.connections = new Connections();

        return char;
    }

    public static responseToCharacters(value: any): Characters[]
    {
        const characters: Characters[] = [];

        console.log('mappers');
        console.log(value);
        // tslint:disable-next-line: no-string-literal
        if (value['response'] === 'success')
        {
            // tslint:disable-next-line: prefer-for-of
            for (let i = 0; i < value.results.length; i++)
            {
                characters.push(this.valToCharacters(value.results[i]));
            }
        }

        console.log(characters);

        return characters;
    }
}
