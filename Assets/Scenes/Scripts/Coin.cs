using UnityEngine;

public class Coin : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D pLayer)
    {
        if (pLayer.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            Player player = pLayer.gameObject.GetComponent<Player>();
            player.AddCoin(1);
        }
    }
}
