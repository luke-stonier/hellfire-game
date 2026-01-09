using HellfireGame.Code.Constants;
using Microsoft.Xna.Framework;

namespace HellfireGame.Code.Interfaces;

public interface ICharacter
{
    void Move(Vector2 direction, AnimationName animationName);
    void GetLastDirection(AnimationName animationName);
}