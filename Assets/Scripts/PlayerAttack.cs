using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private Fireball bullet;
    [SerializeField] private Transform bulletStartPosition;
     
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bool fire = Input.GetButtonDown("Fire1");

        if (fire)
        {
            Fireball fireball = Instantiate(bullet);
            fireball.startPosition = bulletStartPosition.position;
        }
    }
}
