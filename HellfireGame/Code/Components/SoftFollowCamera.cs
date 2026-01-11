using System;
using ImGuiNET;
using Microsoft.Xna.Framework;
using Nez;

namespace HellfireGame.Code.Components;

public static class SoftFollowCameraDefaults
{
    public const float MIN_DISTANCE = 2f;
    public const float MAX_DISTANCE = 400f;
    public const float FOLLOW_SPEED = 1f;
}

public class SoftFollowCamera : Component, IUpdatable
{
    private readonly float _minDistance = 0;
    private readonly float _maxDistance = 0;
    private readonly float _followSpeed = 0;

    private readonly Entity _target;

    public SoftFollowCamera(Entity target, float minDistance, float maxDistance, float followSpeed)
    {
        _target = target;
        _minDistance = minDistance;
        _maxDistance = maxDistance;
        _followSpeed = followSpeed;
    }

    void IUpdatable.Update()
    {
        var speed = _followSpeed;
        var distance = Vector2.Distance(Transform.Position, _target.Position);
        if (distance < _minDistance) return; // in bounds
        if (distance > _maxDistance) speed *= 1.5f; // increase speed to keep in bound
        var moveDirection = Vector2.Lerp(Transform.Position, _target.Position, speed * Time.DeltaTime);
        Transform.Position = moveDirection;

        ImGui.Begin($"{Entity.Name}");
        ImGui.Text($"Distance: {distance}");
        ImGui.End();
    }
}