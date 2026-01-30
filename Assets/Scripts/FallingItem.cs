using UnityEngine;

public class FallingItem : MonoBehaviour
{
    [Header("Data Reference")]
    public ItemData data;

    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (data != null)
        {
            spriteRenderer.color = data.itemColor;

            if (data.itemSprite != null)
            {
                spriteRenderer.sprite = data.itemSprite;
            }
        }
    }

    void Update()
    {
        if (data != null)
        {
            transform.Translate(Vector3.down * data.fallSpeed * Time.deltaTime);
        }

        if (transform.position.y < -10f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (data.isBomb)
            {
                GameEvents.OnBombCaught?.Invoke();
            }
            else
            {
                GameEvents.OnScoreItemCaught?.Invoke(data.scoreValue);
            }

            Destroy(gameObject);
        }
    }
}