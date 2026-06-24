using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Transform player;
    public float moveSpeed = 3f;

    public float wander = .3f;
    public float changeTime = .4f;

    private Vector2 randomDir;
    private float timer;

    void Start()
    {
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");

        if (playerObj != null)
            player = playerObj.transform;

        randomDir = Random.insideUnitCircle.normalized;
    }
    void Update()
    {
        timer += Time.deltaTime;
        if (timer>=changeTime)
        {
            randomDir = Random.insideUnitCircle.normalized;
            timer = 0f;
        }
        Vector2 playerDir = ((Vector2)player.position - (Vector2)transform.position).normalized;
        Vector2 moveDir = (playerDir + randomDir * wander).normalized;
        transform.position += (Vector3)(moveDir * moveSpeed * Time.deltaTime);

        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        if (moveDir.x > 0)
            sr.flipX = false;
        else if (moveDir.x < 0)
            sr.flipX = true;
    }
}
