using HellfireGame.Code.Misc;
using Microsoft.Xna.Framework;
using Nez;

namespace HellfireGame.Code.Interfaces;

public interface ICharacter
{
    void Move(Vector2 direction, MoveType moveType);
    void GetLastDirection(MoveType moveType);
}