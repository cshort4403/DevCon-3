using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField]
    int EnemyHealth = 10;

    GameManager GameManager;

	private void Awake()
	{
        GameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
	}

	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage() 
    {
        EnemyHealth--;
        if(EnemyHealth <= 0)
        {
            GameManager.RemoveShip(gameObject);
        }

    }
}
