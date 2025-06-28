using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [Header("Player Health")]
    public int maxHealth = 100;
    private int currentHealth;

    [Header("UI")]
    public Slider healthSlider;
    public Text gameOverText;

    [Header("Game Over")]
    public GameOverManager gameOverManager;

    // ==========================
    // Enemy Attack System
    private EnemyHealth enemyInRange; // לשמירת אויב קרוב
    // ==========================

    void Start()
    {
        currentHealth = maxHealth;

        if (healthSlider != null)
            healthSlider.value = 1f;

        if (gameOverText != null)
            gameOverText.enabled = false;
    }

    void Update()
    {
        // אם האויב בטווח ולוחצים F – השחקן תוקף
        if (Input.GetKeyDown(KeyCode.F) && enemyInRange != null)
        {
            enemyInRange.TakeDamage(50); // פוגע באויב
        }
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        currentHealth = Mathf.Max(0, currentHealth);

        if (healthSlider != null)
            healthSlider.value = (float)currentHealth / maxHealth;

        if (currentHealth <= 0)
        {
            if (gameOverText != null)
                gameOverText.enabled = true;

            if (gameOverManager != null)
                gameOverManager.ShowRestartButton();

            Debug.Log("Game Over!");
            gameObject.SetActive(false);
        }
    }

    // פגיעת האויב בשחקן
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            TakeDamage(25);
        }
    }

    // ===============================
    // זיהוי אויב שנכנס לטווח
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            enemyInRange = other.GetComponent<EnemyHealth>();
        }
    }

    // אויב יוצא מהטווח
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            enemyInRange = null;
        }
    }
    // ===============================
}
