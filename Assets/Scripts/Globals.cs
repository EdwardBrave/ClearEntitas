using Entitas.CodeGeneration.Attributes;
using System.Collections.Generic;
using UnityEngine;
using System;

[Game, Unique, CreateAssetMenu]
public class Globals : ScriptableObject
{
    public Color defaultColor;

    public List<Divider> dividers;

    public List<DefinedGameObject> objects;
}

[Serializable]
public class DefinedGameObject
{
    public string name;
    public GameObject prefub; 

    public bool IsNamedAs(string givenName) => name == givenName;
}

[Serializable]
public struct Divider
{
    public int number;
    public Color color;
}
