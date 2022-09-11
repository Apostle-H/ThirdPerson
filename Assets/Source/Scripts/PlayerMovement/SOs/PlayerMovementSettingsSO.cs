using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerMoveSettings", menuName = "SOs/Player/Movement/PlayerMoveSettings")]
public class PlayerMovementSettingsSO : ScriptableObject
{
    [field: SerializeField] public float CharMoveSpeed { get; private set; }
    [field: SerializeField] public float CharMoveSmoothTime { get; private set; }
    [field: SerializeField] public float CharRotationSpeed { get; private set; }

    [field: SerializeField] public float CharJumpForce { get; private set; }
        
    [field: SerializeField] public float GroundCheckRadius { get; private set; }
    [field: SerializeField] public LayerMask GroundCheckLayerMask { get; private set; }
}

