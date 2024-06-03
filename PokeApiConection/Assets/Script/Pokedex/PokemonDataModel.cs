using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "PokemonData", menuName = "ScriptableObjects/PokemonData")]
public class PokemonDataModel : ScriptableObject
{    
    public string pokemonUrl;
    public PokemonByGraphQL requestedPokemonData; 
}

[Serializable]
public class PokemonByGraphQLRoot
{
    public PokemonByGraphQL data;
}

[Serializable]
public class PokemonByGraphQL
{
    public List<PokemonDataGQL> pokemon_v2_pokemon;
}

#region GraphQL
[Serializable]
public class PokemonDataGQL
{
    public int id;
    public string name;
    public List<PokemonV2Pokemontype> pokemon_v2_pokemontypes;
    public List<PokemonV2Pokemonstat> pokemon_v2_pokemonStats;
}

[Serializable]
public class PokemonV2Pokemonstat
{
    public int base_stat;
    public PokemonV2Stat pokemon_v2_stat;
}

[Serializable]
public class PokemonV2Pokemontype
{
    public PokemonV2Type pokemon_v2_type;
}

[Serializable]
public class PokemonV2Stat
{
    public string name;
}

[Serializable]
public class PokemonV2Type
{
    public string name;
}

#endregion

#region Normal PokeApi

[Serializable]
public class PokemonByPage
{
    public List<PokemonAlbumData> results;
}

[Serializable]
public class PokemonAlbumData
{
    public string name;
    public string url;
}



[Serializable]
public class PokemonData
{
    public int id;
    public string name;
    public Sprites sprites;
    public List<Type> types;
    public List<Stat> stats;
}

[Serializable]
public class Sprites
{
    public string back_default;
    public string front_default;
    public string front_shiny;
}

[Serializable]
public class Type
{
    public int slot;
    public PokemonType type;
}

[Serializable]
public class PokemonType
{
    public string name;
}

[Serializable]
public class Stat
{
    public float base_stat;
    public StatName stat;
}

[Serializable]
public class StatName
{
    public string name;
}

#endregion