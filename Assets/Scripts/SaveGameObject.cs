using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveGameObject : MonoBehaviour
{
    public string objectID;

    private void Awake()
    {
        objectID = name + transform.position.ToString() + transform.eulerAngles.ToString();
    }

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i <Object.FindObjectsOfType<SaveGameObject>().Length; i++)
        {
            if(Object.FindObjectsOfType<SaveGameObject>()[i] !=this)
            {
                if (Object.FindObjectsOfType<SaveGameObject>()[i].objectID == objectID)
                {
                    Destroy(gameObject);
                }
            }
            

        }

        DontDestroyOnLoad(gameObject);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
