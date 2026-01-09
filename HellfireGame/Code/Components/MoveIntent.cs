using HellfireGame.Code.Constants;
using HellfireGame.Code.Misc;
using Microsoft.Xna.Framework;
using Nez;

namespace HellfireGame.Code.Components;

public class MoveIntent : Component
{
    public Vector2 Direction;
    public AnimationName AnimationToPlay;
}