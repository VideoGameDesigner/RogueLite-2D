using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField] float BackgroundSpeed;

    float SingleTextureWidth;

    


    // Start is called before the first frame update
    void Start()
    {
        SetUpTexture();

    }

    // Update is called once per frame
    void Update()
    {
        Scroll();
        CheckReset();
    }

    void SetUpTexture()
    {
        Sprite sprite = GetComponent<SpriteRenderer>().sprite;
        SingleTextureWidth = sprite.texture.width / sprite.pixelsPerUnit;
    }


    void Scroll()
    {
        float delta = -BackgroundSpeed * Time.deltaTime;
        transform.position += new Vector3(delta, 0f,0f);
    }

    void CheckReset ()
    {
        if((Mathf.Abs(transform.position.x) - SingleTextureWidth) > 0)
        {
            transform.position = new Vector3(0.0f, transform.position.y, transform.position.z);
        }
                

        
    }

}
