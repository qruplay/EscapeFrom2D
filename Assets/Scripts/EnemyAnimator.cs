using UnityEngine;

public class EnemyAnimator : MonoBehaviour
{
    private Animator _myAnimController;
    private Rigidbody2D _myRG;

    // Start is called before the first frame update
    void Start()
    {
        _myAnimController = GetComponent<Animator>();
        _myRG = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        _myAnimController.SetFloat("Movespeed", Mathf.Abs(_myRG.velocity.x));
    }
}
