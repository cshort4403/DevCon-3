using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField]
    GameObject EnemyToSpawn;
    [SerializeField]
    BoxCollider MaxSpawnArea , MinSpawnArea;

    [SerializeField]
    int MaxEnemies = 3;
    
    

    //List of the enemies in the game
    private List<GameObject> Enemies;

    // Start is called before the first frame update
    void Start()
    {
        Enemies = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Enemies.Count < MaxEnemies) 
        {
            SpawnEnemyShip();
        }

    }

    public void RemoveShip(GameObject enemy)
    {
        Enemies.Remove(enemy); 
        Destroy(enemy);
    }
    /// <summary>
    /// Spawn enemy ship at a random position and rotation within bounds
    /// </summary>
    void SpawnEnemyShip()
    {

        Quaternion newRot = new Quaternion();
        newRot.eulerAngles = new Vector3(0, Random.Range(0,359), 0);

        GameObject enemy = Instantiate(EnemyToSpawn);
        enemy.transform.SetPositionAndRotation(GetPointInsideBounds(MinSpawnArea,MaxSpawnArea), newRot);
        Enemies.Add(enemy);
	}

    Vector3 GetPointInsideBounds(BoxCollider MinCollider, BoxCollider MaxCollider)
    {
		Vector3 minExtents = MinCollider.size / 2f;
		Vector3 maxExtents = MaxCollider.size / 2f;
        Vector3 point = Vector3.zero;

        //(-1000, -550) (550, 1000)

        int Quadrent = Random.Range(0, 3);

        if(Quadrent == 0)
        {
            point = new Vector3(Random.Range(minExtents.x, maxExtents.x), 0, Random.Range(minExtents.z, maxExtents.z));
        }
		else if (Quadrent == 1)
		{
			point = new Vector3(-Random.Range(minExtents.x, maxExtents.x), 0, Random.Range(minExtents.z, maxExtents.z));
		}
		else if (Quadrent == 2)
		{
			point = new Vector3(Random.Range(minExtents.x, maxExtents.x), 0, -Random.Range(minExtents.z, maxExtents.z));
		}
		else if (Quadrent == 3)
		{
			point = new Vector3(-Random.Range(minExtents.x, maxExtents.x), 0, -Random.Range(minExtents.z, maxExtents.z));
		}
        else
        {
            Debug.LogError($"Error spawning enemy ship at {point}");
        }

		return point;
	}
}
