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

    // Fiziksel bir temas (Tetiklenme) olduðunda çalýþýr.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // YENÝ MANTIK: Eþya bomba mý diye kontrol et
            if (data.isBomb)
            {
                // Evet, bombaymýþ! Bomba olayýný tetikle.
                GameEvents.OnBombCaught?.Invoke();
            }
            else
            {
                // Hayýr, puan veren bir eþyaymýþ. Puan olayýný tetikle.
                GameEvents.OnScoreItemCaught?.Invoke(data.scoreValue);
            }

            // Her iki durumda da objeyi yok et.
            Destroy(gameObject);
        }
    }
}