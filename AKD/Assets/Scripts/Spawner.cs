using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform[] shelf1Points;
    public Transform[] shelf2Points;
    public Transform[] shelf3Points;

    public GameObject[] objectPrefabs;

    private void Start()
    {
        SpawnObjectsOnShelf(shelf1Points);
        SpawnObjectsOnShelf(shelf2Points);
        SpawnObjectsOnShelf(shelf3Points);
    }

    private void SpawnObjectsOnShelf(Transform[] shelfPoints)
    {
        ShuffleArray(objectPrefabs);

        for (int i = 0; i < 3; i++)
        {
            Instantiate(objectPrefabs[i], shelfPoints[i].position, shelfPoints[i].rotation);
        }
    }

    private void ShuffleArray(GameObject[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            int rnd = Random.Range(0, array.Length);
            GameObject temp = array[rnd];
            array[rnd] = array[i];
            array[i] = temp;
        }
    }
}
