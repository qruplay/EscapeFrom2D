using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float maxHP;
    private float currentHP;

    // Start is called before the first frame update
    void Start()
    {
        currentHP = maxHP;
    }

    private void Update()
    {
        if (currentHP<=0)
        {
            Destroy(gameObject);
        }
    }

    public void takeDamage (float damage)
    {
        currentHP -= damage;
    }
}
