using UnityEngine;
using System.Collections;
 
public class NewBehaviorScript : MonoBehaviour
{
    public GameObject prefab;
 
    private void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            Instantiate(prefab, Vector3.right * i, Quaternion.identity);
        }
    }
}