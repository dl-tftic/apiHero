import { Team } from './team';

export interface IUser
{
    name: string;
    firstname: string;
    pseudo: string;
    pwd: string;
    connecte: boolean;
    teams: Team[];
}
