using UnityEngine;

public class HeroAnimator : MonoBehaviour
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
        Debug.Log(_myAnimController.GetFloat("Movespeed"));
        _myAnimController.SetFloat("Movespeed", Mathf.Abs(_myRG.velocity.x));
    }
}
