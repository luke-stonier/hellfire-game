using System;
using System.Collections.Generic;
using HellfireGame.Code.Characters;
using HellfireGame.Code.Constants;
using HellfireGame.Code.Misc;
using HellfireGame.Code.Services;
using Microsoft.Xna.Framework;
using Nez;
using Nez.Sprites;

namespace HellfireGame.Entities;

public class Player : Entity
{
    private SpriteAnimator _animator;
    private IsometricMovementController _isometricMovementController;
    private Dictionary<string, IsometricAnimationSet> _isometricAnimations = new Dictionary<string, IsometricAnimationSet>();
    
    public Player(Vector2 position, Vector2 scale, float rotation)
    {
        Name = "Player";
        Transform.Position = position;
        Transform.Scale = scale;
        Transform.Rotation = rotation;
        
        CreateComponents();
        AttachComponents();
    }

    protected Player() : this(Vector2.Zero, Vector2.One, 0f) {}

    protected void AddAnimation(string animationName,
        string path,
        float movementSpeed = 0,
        int framesPerSecond = 12,
        int cellWidth = 64,
        int cellHeight = 64,
        int frameCount = 12)
    {
        _isometricAnimations.Add(animationName, 
            IsometricService.LoadAnimationsToAnimationSet(movementSpeed, framesPerSecond, path, cellWidth, cellHeight, frameCount));
        
        Console.WriteLine($"[PLAYER] Added Animation {animationName} {path}");
    }

    private void CreateComponents()
    {
        _animator = new SpriteAnimator();
        _isometricMovementController = new IsometricMovementController(_animator);
    }

    private void AttachComponents()
    {
        AddComponent(_animator);
        AddComponent(_isometricMovementController);
    }

    protected void Start()
    {
        var idleAnimation = _isometricAnimations[AnimationNames.IDLE].GetAnimation(IsometricDirection.North);
        _animator.AddAnimation(AnimationNames.IDLE, idleAnimation);
        _animator.Play(AnimationNames.IDLE);
    }
}