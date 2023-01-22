using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    private float x = 30f;
    private float y = 30f;
    public bool ctrlB;
    public GameObject Camera;
    public GameObject Player;
    public GameObject Cameracontrol;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftControl))
        {
            ctrlB = true;
            Camera.transform.parent = Cameracontrol.transform;
        }
        else if(Input.GetKeyUp(KeyCode.LeftControl))
        {
            ctrlB = false;
            Camera.transform.parent = Player.transform;
            Camera.transform.position = Player.transform.position;
        }

      if(Input.GetKey(KeyCode.LeftArrow) && ctrlB)
        {
            Cameracontrol.transform.position += new Vector3(-x * Time.deltaTime, 0, 0);
        }
      if(Input.GetKey(KeyCode.RightArrow) && ctrlB)
        {
            Cameracontrol.transform.position += new Vector3(x * Time.deltaTime, 0, 0);
        }
      if (Input.GetKey(KeyCode.UpArrow) && ctrlB)
        {
            Cameracontrol.transform.position += new Vector3(0, y * Time.deltaTime, 0);
        }
      if (Input.GetKey(KeyCode.DownArrow) && ctrlB)
        {
            Cameracontrol.transform.position += new Vector3(0, -y * Time.deltaTime, 0);
        }



    }
}
