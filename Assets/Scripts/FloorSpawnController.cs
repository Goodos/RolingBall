using Lean.Pool;
using System.Collections.Generic;
using UnityEngine;

public class FloorSpawnController : MonoBehaviour
{
    [SerializeField] GameObject floorPrefab;
    [SerializeField] GameObject wallPrefab;
    [SerializeField] GameObject coinPrefab;
    [SerializeField] GameObject player;
    private List<GameObject> floors = new List<GameObject>();

    void Start()
    {
        SpawnNextFloor(-floorPrefab.GetComponent<MeshRenderer>().bounds.size.z / 2);
        SpawnNextFloor(floors[floors.Count - 1].transform.position.z);
    }

    void Update()
    {
        if (player.transform.position.z >= floors[floors.Count - 2].transform.position.z)
        {
            SpawnNextFloor(floors[floors.Count - 1].transform.position.z);
            DeSpawnPreviosFloor();
        }
    }

    void SpawnNextFloor(float newPos)
    {
        GameObject newFloor = LeanPool.Spawn(floorPrefab);
        newFloor.transform.position = new Vector3(0, 0, newPos + newFloor.GetComponent<MeshRenderer>().bounds.size.z);
        SpawnWalls(newFloor.transform);
        floors.Add(newFloor);
    }

    void DeSpawnPreviosFloor()
    {
        try
        {
            if (floors[floors.Count - 4] != null)
            {
                foreach (Transform child in floors[floors.Count - 4].transform)
                {                    
                    Destroy(child.gameObject);
                }
                LeanPool.Despawn(floors[floors.Count - 4]);
                floors.Remove(floors[floors.Count - 4]);
            }
        }
        catch
        {

        }
    }

    void SpawnWalls(Transform parent)
    {
        float newPos = parent.transform.position.z - parent.GetComponent<MeshRenderer>().bounds.size.z / 2;
        float gapBetweenWalls = 12f;
        float rValue = Random.Range(1, 7);
        newPos = TypeOfWall(newPos + gapBetweenWalls, rValue, parent);

        for (int i = 0; i <= 3; i++)
        {
            switch (rValue)
            {
                case 1:
                    rValue = 5;
                    break;
                case 2:
                    rValue = 6;
                    break;
                case 3:
                    rValue = 4;
                    break;
                case 4:
                    int[] blockArr1 = { 3, 5, 6 };
                    rValue = blockArr1[Random.Range(0, 3)];
                    break;
                case 5:
                    int[] blockArr2 = { 1, 4, 6 };
                    rValue = blockArr2[Random.Range(0, 3)];
                    break;
                case 6:
                    int[] blockArr3 = { 2, 4, 5 };
                    rValue = blockArr3[Random.Range(0, 3)];
                    break;
            }
            newPos = TypeOfWall(newPos + gapBetweenWalls, rValue, parent);
        }
    }

    float TypeOfWall(float zPos, float rValue, Transform parent)
    {
        GameObject firstWall = Instantiate(wallPrefab, parent);
        switch (rValue)
        {
            case 1:
                firstWall.transform.position = new Vector3(-3f, firstWall.transform.position.y, zPos);
                break;
            case 2:
                firstWall.transform.position = new Vector3(0f, firstWall.transform.position.y, zPos);
                break;
            case 3:
                firstWall.transform.position = new Vector3(3f, firstWall.transform.position.y, zPos);
                break;
            default:
                GameObject secondWall = Instantiate(wallPrefab, parent);
                switch (rValue)
                {
                    case 4:
                        firstWall.transform.position = new Vector3(-3f, firstWall.transform.position.y, zPos);
                        secondWall.transform.position = new Vector3(0f, secondWall.transform.position.y, zPos);
                        break;
                    case 5:
                        firstWall.transform.position = new Vector3(0f, firstWall.transform.position.y, zPos);
                        secondWall.transform.position = new Vector3(3f, secondWall.transform.position.y, zPos);
                        break;
                    case 6:
                        firstWall.transform.position = new Vector3(-3f, firstWall.transform.position.y, zPos);
                        secondWall.transform.position = new Vector3(3f, secondWall.transform.position.y, zPos);
                        break;
                }
                break;
        }
        if (Random.Range(0, 11) <= 3)
        {
            GameObject newCoin = Instantiate(coinPrefab, parent);
            float rCoin;
            switch (rValue)
            {
                case 1:
                    float[] coinArr1 = { 0, 3 };
                    rCoin = coinArr1[Random.Range(0, 2)];
                    newCoin.transform.position = new Vector3(rCoin, newCoin.transform.position.y, zPos);
                    break;
                case 2:
                    float[] coinArr2 = { -3, 3 };
                    rCoin = coinArr2[Random.Range(0, 2)];
                    newCoin.transform.position = new Vector3(rCoin, newCoin.transform.position.y, zPos);
                    break;
                case 3:
                    float[] coinArr3 = { 0, -3 };
                    rCoin = coinArr3[Random.Range(0, 2)];
                    newCoin.transform.position = new Vector3(rCoin, newCoin.transform.position.y, zPos);
                    break;
                case 4:
                    newCoin.transform.position = new Vector3(3, newCoin.transform.position.y, zPos);
                    break;
                case 5:
                    newCoin.transform.position = new Vector3(-3, newCoin.transform.position.y, zPos);
                    break;
                case 6:
                    newCoin.transform.position = new Vector3(0, newCoin.transform.position.y, zPos);
                    break;
            }
        }
        return firstWall.transform.position.z;
    }
}
