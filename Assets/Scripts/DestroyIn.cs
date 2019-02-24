using UnityEngine;

public class DestroyIn : MonoBehaviour
{
    [SerializeField] private float _time;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, _time);
    }
}
