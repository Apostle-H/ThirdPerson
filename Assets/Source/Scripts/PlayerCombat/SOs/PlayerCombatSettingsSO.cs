using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerCombatSettings", menuName = "SOs/Player/Combat/PlayerCombatSettings")]
public class PlayerCombatSettingsSO : ScriptableObject
{
    [field: SerializeField] public GameObject BulletPrefab { get; private set; }
    [field: SerializeField] public float BulletLifeTime { get; private set; }
    [field: SerializeField] public float BulletTravelSpeed { get; private set; }
}
