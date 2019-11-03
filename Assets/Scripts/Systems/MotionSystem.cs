using System.Collections.Generic;
using UnityEngine;
using Entitas;

public class MotionSystem : ReactiveSystem<GameEntity>
{
    private GameContext _context;
    public MotionSystem(Contexts contexts) : base(contexts.game)
    {
        _context = contexts.game;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Position);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasView;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        var globals = _context.globals.value;
        foreach (var e in entities)
        {
            Vector2 pos = e.position.value;
            e.view.gameObject.transform.position = new Vector3(pos.x, pos.y, 0);
        }
    }
}
