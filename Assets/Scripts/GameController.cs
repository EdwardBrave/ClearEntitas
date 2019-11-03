using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

public class GameController : MonoBehaviour
{
    public Globals globals;

    private Feature systems;
    private IInitializeSystem initSystem;
    void Start()
    {
        var contexts = Contexts.sharedInstance;
        contexts.game.SetGlobals(globals);

        systems = new RootSystems(contexts);
        systems.Initialize();
    }

    void Update()
    {
        systems.Execute();
    }
}
