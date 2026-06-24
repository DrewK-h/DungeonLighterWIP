using UnityEngine;
using UnityEngine.InputSystem;

public class Shooting : MonoBehaviour
{
    public GameObject firePrefab;
    public float fireSpeed = 20f;

    public float shootCooldown = 1f;
    private float nextShot;
    public void Shoot(InputAction.CallbackContext context)
    {
        if (!context.performed)
            return;

        if (Time.time < nextShot)
            return;
        nextShot = Time.time + shootCooldown;

        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        mousePos.z = 0f;

        Vector2 shotDir = (mousePos - transform.position).normalized;

        float angle = Mathf.Atan2(shotDir.y, shotDir.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.Euler(0, 0, angle);

        GameObject fire = Instantiate(firePrefab,(Vector2)transform.position+shotDir*3f,rotation);

        fire.GetComponent<Rigidbody2D>().linearVelocity = shotDir * fireSpeed;
    }
}