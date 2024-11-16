using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeySpawner : MonoBehaviour
{
    public GameObject keyPrefab; // Prefab kunci yang akan disebar
    public int numberOfKeys = 5; // Jumlah kunci yang ingin disebar
    public Vector2Int mazeSize = new Vector2Int(10, 10); // Ukuran labirin (bisa diatur sesuai labirinmu)

    private List<Vector3> keyPositions = new List<Vector3>(); // Menyimpan posisi kunci

    void Start()
    {
        SpawnKeys();
    }

    void SpawnKeys()
    {
        for (int i = 0; i < numberOfKeys; i++)
        {
            Vector3 randomPosition = GenerateRandomPosition();

            // Pastikan kunci tidak menumpuk di tempat yang sama
            while (keyPositions.Contains(randomPosition))
            {
                randomPosition = GenerateRandomPosition();
            }

            keyPositions.Add(randomPosition);

            // Instansiasi kunci di posisi acak dalam labirin
            Instantiate(keyPrefab, randomPosition, Quaternion.identity);
        }
    }

    Vector3 GenerateRandomPosition()
    {
        // Menghasilkan posisi acak dalam labirin berdasarkan ukuran
        float randomX = Random.Range(0, mazeSize.x);
        float randomZ = Random.Range(0, mazeSize.y);

        // Mengembalikan posisi dalam koordinat dunia
        return new Vector3(randomX, 0, randomZ); // Sesuaikan nilai Y sesuai kebutuhan ketinggian labirinmu
    }

    // Debug untuk melihat posisi key di editor
    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;

        foreach (var pos in keyPositions)
        {
            Gizmos.DrawSphere(pos, 0.5f); // Menggambar bola kecil di setiap posisi kunci
        }
    }
}
