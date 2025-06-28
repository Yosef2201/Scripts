using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    public GameObject bulletPrefab;     // גרור את Prefab של הקליע
    public Transform firePoint;         // נקודת הירי
    public float bulletSpeed = 10f;     // מהירות הקליע
    public float shootInterval = 2f;    // כל כמה שניות יורה

    public Transform player;            // גרור את השחקן
    private float timer = 0f;

    void Update()
    {
        if (player == null) return;

        timer += Time.deltaTime;

        // מסובב את האויב אל השחקן
        Vector3 lookPos = player.position - transform.position;
        lookPos.y = 0; // שלא יסתובב מעלה/מטה
        transform.rotation = Quaternion.LookRotation(lookPos);

        if (timer >= shootInterval)
        {
            Shoot();
            timer = 0f;
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.linearVelocity = firePoint.forward * bulletSpeed;
        }
    }
}
