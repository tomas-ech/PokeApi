import { TypePokemonEnum } from "../enums";

export interface PokemonData {
    id: number;
    name: string;
    sprites: Sprites;
    types: Type[];
    stats: Stat[];
}

interface Sprites {
    back_default: string;
    front_default: string;
    front_shiny: string;
}

interface Type {
    slot: number;
    type: PokemonType;
}

interface PokemonType {
    name: TypePokemonEnum;
}

interface Stat {
    base_stat: number;
    stat: StatName;
}

interface StatName {
    name: string;
}
