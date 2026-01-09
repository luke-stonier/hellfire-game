using System;
using System.Collections.Generic;
using System.Linq;
using HellfireGame.Code.Components;
using HellfireGame.Code.Constants;
using HellfireGame.Code.Misc;
using HellfireGame.Code.Services;
using Microsoft.Xna.Framework;
using Nez;
using Nez.Sprites;

namespace HellfireGame.Entities;

public class Player : Entity
{
    private InputController _inputController;
    private SpriteAnimator _animator;
    private IsometricMovementController _isometricMovementController;
    private readonly  LayeredIsometricAnimationSet _isometricAnimationSet = new LayeredIsometricAnimationSet();
    
    private bool hasInitialized = false;
    
    public Player(Vector2 position, Vector2 scale, float rotation)
    {
        Name = "Player";
        Transform.Position = position;
        Transform.Scale = scale;
        Transform.Rotation = rotation;

        Configure();
    }

    protected void Awake()
    {
        _isometricMovementController = _isometricMovementController.AddAnimationSet(_isometricAnimationSet);
        
        AttachComponents();
        hasInitialized = true;
    }

    void Configure()
    {
        DetachComponents();
        CreateComponents();
    }

    protected Player() : this(Vector2.Zero, Vector2.One, 0f) {}

    protected void AddAnimation(
        AnimationName animationName,
        string path,
        int frameCount = 12,
        float movementSpeed = 0,
        int framesPerSecond = 12,
        int cellWidth = 64,
        int cellHeight = 64)
    {
        
        var animations = IsometricService.LoadAnimationsToAnimationSet(
            animationName,
            movementSpeed,
            framesPerSecond,
            path,
            cellWidth,
            cellHeight,
            frameCount);
        
        _isometricAnimationSet.AddIsometricAnimationSet(animations);
        
        Console.WriteLine($"[PLAYER] {Name} Added Animation {animationName} {path} with {animations.AnimationCount()} / 8 directions");
        animations.AllAnimations().ForEach((animationDirection) =>
        {
            _animator.AddAnimation(animationDirection.AnimationName, animationDirection.Animation);
            Console.WriteLine($"\tadding {animationDirection.AnimationName} with  {animationDirection.Animation.Sprites.Count()} frames");
        });
        
        Console.WriteLine($"\t\tAnimator has {_animator.Animations.Count()} total animations");
    }

    private void CreateComponents()
    {
        _inputController = new InputController();
        _animator = new SpriteAnimator();
        _isometricMovementController = new IsometricMovementController(_animator);
    }

    private void DetachComponents()
    {
        if (!hasInitialized) return;
        RemoveComponent(_inputController);
        RemoveComponent(_isometricMovementController);
        RemoveComponent(_animator);
    }

    private void AttachComponents()
    {
        AddComponent(_inputController);
        AddComponent(_animator);
        AddComponent(_isometricMovementController);
    }

    protected void Start()
    {
        _animator.Play(AnimationName.IDLE.ToAnimationName() + "_" + IsometricDirection.South.ToDirectionName());
    }
}