using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float xMargin = 2f;      // Distance in the x axis the player can move before the camera follows.
    public float yMargin = 2f;      // Distance in the y axis the player can move before the camera follows.
    public float xSmooth = 6f;      // How smoothly the camera catches up with it's target movement in the x axis.
    public float ySmooth = 6f;      // How smoothly the camera catches up with it's target movement in the y axis.
    public Vector2 maxXAndY;        // The maximum x and y coordinates the camera can have.
    public Vector2 minXAndY;        // The minimum x and y coordinates the camera can have.


    private Transform player;       // Reference to the player's transform.


    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }


    bool CheckXMargin()
    {
        return Mathf.Abs(transform.position.x - player.position.x) > xMargin;
    }


    bool CheckYMargin()
    {
        return Mathf.Abs(transform.position.y - player.position.y) > yMargin;
    }


    void FixedUpdate()
    {
        TrackPlayer();
    }


    void TrackPlayer()
    {
        float targetX = transform.position.x;
        float targetY = transform.position.y;

        if (CheckXMargin())
            targetX = Mathf.Lerp(transform.position.x, player.position.x, xSmooth * Time.deltaTime);
            
        if (CheckYMargin())
        {
            targetY = Mathf.Lerp(transform.position.y, player.position.y, ySmooth * Time.deltaTime);
        }

        targetX = Mathf.Clamp(targetX, minXAndY.x, maxXAndY.x);
        targetY = Mathf.Clamp(targetY, minXAndY.y, maxXAndY.y);

        transform.position = new Vector3(targetX, targetY, transform.position.z);
    }
}
