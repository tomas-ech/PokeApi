using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "PokemonData", menuName = "ScriptableObjects/PokemonData")]
public class PokemonDataModel : ScriptableObject
{    
    public string pokemonUrl;
    public List<PokemonData> requestedPokemonData;
}

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