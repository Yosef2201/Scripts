using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public int damage = 1;
    public float attackRange = 2f;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = new Ray(transform.position, transform.forward);
            if (Physics.Raycast(ray, out RaycastHit hit, attackRange))
            {
                if (hit.collider.CompareTag("Enemy"))
                {
                    hit.collider.GetComponent<EnemyHealth>()?.TakeDamage(damage);
                }
            }
        }
    }
}
