using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float Health { get; private set; } = 1f;
    private bool isFalling = false;
    private float fallTime = 0f;

    private void Update()
    {
        if (!IsGrounded())
        {
            isFalling = true;
            fallTime += Time.deltaTime;
        }
        else
        {
            if (isFalling && fallTime > 0.2f)
            {
                TakeDamage(0.1f);
            }

            isFalling = false;
            fallTime = 0f;
        }
    }

    private void TakeDamage(float amount)
    {
        Health -= amount;
        Health = Mathf.Clamp01(Health);
    }

    private bool IsGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, 1.1f);
    }
}
