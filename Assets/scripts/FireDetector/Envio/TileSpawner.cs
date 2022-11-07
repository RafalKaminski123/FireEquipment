using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> temperatures = new List<GameObject>();
    private Vector3 curentPosition = new Vector3(2, 0, 0);
    
   public void Spawner()
    {
        Instantiate(temperatures[Random.Range(0, temperatures.Count)], curentPosition, Quaternion.identity);
        curentPosition.x++;
        
    }
   
}
