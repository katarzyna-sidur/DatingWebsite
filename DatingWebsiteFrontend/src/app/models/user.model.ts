import { Settings } from 'http2';

export interface User {
    id: number;
    name: string;
    surname: string;
    login: string;
    password: string;
    email: string;
    city: string;
    photo: string;
}