using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

public class GameController : MonoBehaviour
{
    private Feature systems;
    private IInitializeSystem initSystem;
    void Start()
    {
        var contexts = Contexts.sharedInstance;

        systems = new RootSystems(contexts);
        systems.Initialize();
    }

    void Update()
    {
        systems.Execute();
    }
}
