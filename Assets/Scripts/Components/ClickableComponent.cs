using Entitas;
using UnityEngine;

[Game]
public class ClickableComponent : IComponent
{
}

[Game]
public class MousePressedComponent : IComponent
{
}

[Game]
public class MousePositionComponent : IComponent
{
    public Vector2 value;
}
