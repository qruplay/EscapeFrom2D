using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private Fireball _bullet;
    [SerializeField] private Transform _bulletStartPosition;
    [SerializeField] private Mine _mine;
    [SerializeField] private Transform _minePlace;  // Update is called once per frame
    private bool _fireRight = true;

    void Update() 
    { 
        bool fireBullet = Input.GetButtonDown("Fire1");
        bool placeMine = Input.GetButtonDown("Fire2");

        _fireRight = gameObject.GetComponent<MovementController>().facingRight;

        if (fireBullet) 
        { 
            Fireball fireball = Instantiate(_bullet); 
            fireball.startPosition = _bulletStartPosition.position;
            fireball.fireRight = _fireRight;
        } 

        if (placeMine) 
        { 
            Instantiate(_mine, _minePlace.position, _minePlace.rotation);
        } 
    }
}
