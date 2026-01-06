using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Nez.Sprites;
using Nez.Systems;
using Nez.Textures;

namespace HellfireGame.Code.Services;

public static class IsometricService
{
  private static NezContentManager _content;
  public static void Initialize(NezContentManager content)
  {
    _content = content;
  }
  
  // loads an entire isometric sprite sheet into an isometric animation set
  public static void LoadAnimationsToAnimationSet(string path, int cellSize)
  {
    var spritesheet = _content.Load<Texture2D>(path);
    var sprites = Sprite.SpritesFromAtlas(spritesheet, cellSize, cellSize, 0, 12 * 8);
    
  }   
}