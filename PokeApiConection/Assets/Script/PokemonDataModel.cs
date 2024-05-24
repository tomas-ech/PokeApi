using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PokemonData", menuName = "ScriptableObjects/PokemonData")]
public class PokemonDataModel : ScriptableObject
{
    public int podekexNumber;
    public string pokemonName;
    public List<Type> types;
}


[Serializable]
public class PokemonData
{
    public int id;
    public string name;
    public Sprites sprites;
    public List<Type> types;
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