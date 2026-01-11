using HellfireGame.Code.Constants;
using Microsoft.Xna.Framework;
using Nez;

namespace HellfireGame.Code.Intents;

public class MoveIntent : Component
{
    public Vector2 Direction;
    public AnimationName AnimationToPlay;
}