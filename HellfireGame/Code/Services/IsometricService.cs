using System.Collections.Generic;
using HellfireGame.Code.Misc;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Nez.Sprites;
using Nez.Systems;
using Nez.Textures;

namespace HellfireGame.Code.Services;

public static class IsometricService
{
  
  private static IsometricDirection[] _animationSetOrder =
  [
    IsometricDirection.North,
    IsometricDirection.NorthEast,
    IsometricDirection.East,
    IsometricDirection.SouthEast,
    IsometricDirection.South,
    IsometricDirection.SouthWest,
    IsometricDirection.West,
    IsometricDirection.NorthWest
  ];
  
  private static NezContentManager _content;
  public static void Initialize(NezContentManager content)
  {
    _content = content;
  }
  
  public static IsometricAnimationSet LoadAnimationsToAnimationSet(float movementSpeed, int framesPerSecond, string path, int cellWidth, int cellHeight, int frameCount)
  {
    var isometricAnimationSet = new IsometricAnimationSet(movementSpeed, framesPerSecond);
    var spritesheet = _content.Load<Texture2D>(path);

    var index = 0;
    foreach (var isometricDirection in _animationSetOrder)
    {
      var sprites = Sprite.SpritesFromAtlas(spritesheet, cellWidth, cellHeight, frameCount * index, frameCount);
      isometricAnimationSet.SetAnimation(isometricDirection, sprites.ToArray());
      index++;
    }
    
    return isometricAnimationSet;
  }   
}