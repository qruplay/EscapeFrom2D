using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private Fireball _bullet;
    [SerializeField] private Transform _bulletStartPosition;
    [SerializeField] private Mine _mine;
    [SerializeField] private Transform _minePlace;
     
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bool fireBullet = Input.GetButtonDown("Fire1");
        bool placeMine = Input.GetButtonDown("Fire2");

        if (fireBullet)
        {
            Fireball fireball = Instantiate(_bullet);
            fireball.startPosition = _bulletStartPosition.position;
        }

        if (placeMine)
        {
            Instantiate(_mine, _minePlace.position, _minePlace.rotation);
        }
    }
}
