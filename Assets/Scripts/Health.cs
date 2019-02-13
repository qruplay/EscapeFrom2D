using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float _maxHP;
    private float _currentHP;

    // Start is called before the first frame update
    void Start()
    {
        _currentHP = _maxHP;
    }

    private void Update()
    {
        if (_currentHP<=0)
        {
            Destroy(gameObject);
        }
    }

    public void takeDamage (float damage)
    {
        _currentHP -= damage;
    }
}
