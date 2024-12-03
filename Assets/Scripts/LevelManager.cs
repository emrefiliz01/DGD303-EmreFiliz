using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> levelList;
    [SerializeField] private int targetLevel = 0;


    // start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < levelList.Count; i++)
        {
            if(i == targetLevel)
            {
                levelList[i].SetActive(true);
            }

            else
            {
                levelList[i].SetActive(false);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
