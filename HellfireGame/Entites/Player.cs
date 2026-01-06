using HellfireGame.Code.Characters;
using HellfireGame.Code.Services;
using Microsoft.Xna.Framework;
using Nez;
using Nez.Sprites;

namespace HellfireGame.Entities;

public class Player : Entity
{
    /*
        // var entity = CreateEntity("character-prototype");
        // entity.Transform.Position = new Vector2(640, 360);
        // entity.Transform.Scale = new Vector2(2f);
        //
        // var allFrames = new List<Sprite>();
        // var animations = new List<string> {
        //     "Assets/Character/character-prototype/idle",
        //     "Assets/Character/character-prototype/run",
        //     "Assets/Character/character-prototype/walk",
        // };
        //
        // animations.ForEach((string animation) =>
        // {
        //     var idleTexture = Content.Load<Texture2D>(animation);
        //     allFrames.AddRange(Sprite.SpritesFromAtlas(idleTexture, 64, 64, 0, 12 * 8));
        // });
        //
        // var animation = new SpriteAnimation(allFrames.ToArray(), 12);
        // var animator = entity.AddComponent(new SpriteAnimator());
        // animator.AddAnimation("idle", animation);
        // animator.Play("idle");
     */
    
    private SpriteAnimator _animator;
    private IsometricMovementController _isometricMovementController;
    
    public Player(Vector2 position, Vector2 scale, float rotation)
    {
        Name = "Player";
        Transform.Position = position;
        Transform.Scale = scale;
        Transform.Rotation = rotation;
        
        CreateComponents();
        LoadAnimations();
        AttachComponents();

        Start();
    }

    public void LoadAnimations()
    {
        var idleAnimationSet = IsometricService.LoadAnimationsToAnimationSet(0, 12, "Assets/Character/character-prototype/idle", 64, 64, 8);
    }

    private void CreateComponents()
    {
        _animator = new SpriteAnimator();
        _isometricMovementController = new IsometricMovementController(_animator);
    }

    private void AttachComponents()
    {
        Components.Add(_animator);
        Components.Add(_isometricMovementController);
    }

    private void Start()
    {
        
    }
}