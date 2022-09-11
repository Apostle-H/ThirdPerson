using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCombat : MonoBehaviour
{
    [SerializeField] private PlayerCombatSettingsSO playerCombatSettingsSO;

    [SerializeField] private Transform shootPoint;

    public void PerformShoot(InputAction.CallbackContext ctx)
    {
        Shoot();
    }

    private void Shoot()
    {
        GameObject bulletInstance = Instantiate(playerCombatSettingsSO.BulletPrefab, shootPoint.position, shootPoint.rotation);
        
        bulletInstance.GetComponent<Rigidbody>().velocity = shootPoint.up * playerCombatSettingsSO.BulletTravelSpeed;

        StartCoroutine(BulletKiller(bulletInstance, playerCombatSettingsSO.BulletLifeTime));
    }

    private IEnumerator BulletKiller(GameObject bulletInstance, float lifeTime)
    {
        yield return new WaitForSeconds(lifeTime);

        if (bulletInstance)
        {
            Destroy(bulletInstance);
        }
    }
}
