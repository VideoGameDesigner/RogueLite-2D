using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShoot : MonoBehaviour
{

    //[SerializeField] private GameObject Bullet1;
    //[SerializeField] private Transform BulletSpawnPoint1;
    [SerializeField] int WeaponCycle = 0;
    [SerializeField] int WeaponReset = 3;
    [SerializeField] GameObject[] Ammo;
    [SerializeField] Transform[] BulletSpawns;
    private float firerate = 0.5f;
    private float nextfire = 0;
    private float firerate1 = 2;
    private float nextfire1 = 0;

    private GameObject Bulletint;


    // Start is called before the first frame update
    void Start()
    {
        WeaponCycle = 0;
    }

    // Update is called once per frame
    void Update()
    {
        WeaponSwitch();
        WeaponFire();
        
    }

    /*void OnFire (InputValue value)
    {
        if (value.isPressed & WeaponCycle ==0) 
        {
            Bulletint = Instantiate(Ammo[0], BulletSpawns[0].transform.position, BulletSpawns[0].transform.rotation);
        }
        if (value.isPressed & WeaponCycle == 1 & Time.time > nextfire)
        {
            nextfire = Time.time + firerate;
            Bulletint = Instantiate(Ammo[1], BulletSpawns[1].transform.position, BulletSpawns[1].transform.rotation);
            Bulletint = Instantiate(Ammo[1], BulletSpawns[2].transform.position, BulletSpawns[2].transform.rotation);
        }

    }*/
  


    void WeaponFire()
    {
        if(Mouse.current.leftButton.wasPressedThisFrame & WeaponCycle == 0 & GameManager.isPaused == false)
        {
            Bulletint = Instantiate(Ammo[0], BulletSpawns[0].transform.position, BulletSpawns[0].transform.rotation);          
        }

        if(Mouse.current.leftButton.wasPressedThisFrame & WeaponCycle == 1 & Time.time > nextfire & GameManager.isPaused == false)

        {
            nextfire = Time.time + firerate;
            Bulletint = Instantiate(Ammo[1], BulletSpawns[1].transform.position, BulletSpawns[1].transform.rotation);
            Bulletint = Instantiate(Ammo[1], BulletSpawns[2].transform.position, BulletSpawns[2].transform.rotation);
        }

        if (Mouse.current.leftButton.wasPressedThisFrame & WeaponCycle == 2 & Time.time > nextfire1 & GameManager.isPaused == false)
        {
            nextfire1 = Time.time + firerate1;
            Bulletint = Instantiate(Ammo[2], BulletSpawns[3].transform.position, BulletSpawns[3].transform.rotation);
        }

    }

    void WeaponSwitch()
    {
        if(Mouse.current.rightButton.wasPressedThisFrame & GameManager.isPaused == false)
        {
            WeaponCycle++;

        }

        if (WeaponCycle == WeaponReset)
        {
            WeaponCycle = 0;

        }
    }



}
