using System.Collections.Generic;
using Entitas;

public class FollowSystem : ReactiveSystem<GameEntity>
{
    private GameContext _context;
    public FollowSystem(Contexts contexts) : base(contexts.game)
    {
        _context = contexts.game;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.MousePosition);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.isMousePressed;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        var globals = _context.globals.value;
        foreach (var e in entities)
        {
            e.ReplacePosition(e.mousePosition.value);
        }
    }
}
