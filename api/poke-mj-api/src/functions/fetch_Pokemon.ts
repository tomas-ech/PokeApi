
import axios from 'axios';
import { ListPokemon } from './Interface/pokeApiInterface';
import { PokemonData } from './Interface/pokemon';
import { AppDataSource } from '../data-source';
import { User } from '../entity/User';
import { Pokemon } from '../entity/Pokemon';
import { TypePokemonEnum } from './enums';

const urlPokemon: string = "https://pokeapi.co/api/v2/pokemon/?limit=1302";


export async function fecthPokemon(): Promise<ListPokemon> {
    

    const resultListPokemons = await axios.get<ListPokemon>(urlPokemon);

    for (const pokemon of resultListPokemons.data.results){

        const resultInfoPokemons = await axios.get<PokemonData>(pokemon.url);

        const data = resultInfoPokemons.data;

        const newPokemon = new Pokemon();
        newPokemon.nombre = data.name
        newPokemon.pokedexID = data.id
        newPokemon.type1 = data.types[0]?.type.name,
        newPokemon.type2 = data.types[1]?.type.name,
        newPokemon.health = data.stats[0].base_stat
        newPokemon.attack = data.stats[1].base_stat
        newPokemon.special_attack = data.stats[2].base_stat
        newPokemon.defense = data.stats[3].base_stat
        newPokemon.special_defense = data.stats[4].base_stat
        newPokemon.speed = data.stats[5].base_stat

        await AppDataSource.manager.save(Pokemon, newPokemon)
    }


    return resultListPokemons.data;
    // const pokemones = await axios.request({
    //     method: 'GET',
    //     url: urlPokemon
    // }).then(function ({ data }: { data: ListPokemon }) {
    //     console.log(data);
    // })
    // .catch(function (error: any) {
    //     console.error(error);
    // });

    // console.log("pokemones_ ", pokemones)

}
