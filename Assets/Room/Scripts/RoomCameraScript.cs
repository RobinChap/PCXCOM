using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomCameraScript : MonoBehaviour
{
    public int  anglecam = 1;
    public float maxx, maxy,maxz;
    public float minx, miny,minz;
    float xmouse, xmousesave;
    float xcamchange, ycamchange, zcamchange;
    public int speed = 5;

   
    // Use this for initialization
    void Start()
    {
        this.GetComponent<Transform>().localPosition = new Vector3(0,15, -4);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.S))
        {
            zcamchange -= 1;
        }
        if (Input.GetKey(KeyCode.Z))
        {
            zcamchange += 1;
        }
        if ( Input.GetKey(KeyCode.Q))
        {
            xcamchange -= 1;
        }
        if ( Input.GetKey(KeyCode.D))   
        {
            xcamchange += 1;
        }
        if ( Input.GetKey(KeyCode.LeftAlt))
        {
            ycamchange -= 1;
        }
        if ( Input.GetKey(KeyCode.Space))
        {
            ycamchange += 1;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            anglecam++;
            if (anglecam > 4)
            {
                anglecam = 1;
            }
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            anglecam--;  
            if(anglecam < 1){
                anglecam = 4;
            }
        }

        fixCamPosition();

    }



    

    void FixedUpdate()
    {
        if (Input.GetMouseButton(1))
        {
            xmouse = Input.GetAxis("Mouse Y");
            //ymouse = Input.GetAxis("Mouse X");
        }
        else
        {
            xmouse = 0;
            
        }

        this.GetComponent<Transform>().eulerAngles -= new Vector3(xmouse, 0, 0);
        xmousesave = this.GetComponent<Transform>().eulerAngles.x;

    }

    void fixCamPosition()
    {
        float buffer = xcamchange;
        switch (anglecam)
        {
            case 1:
                this.GetComponent<Transform>().localEulerAngles = Vector3.Lerp(this.GetComponent<Transform>().localEulerAngles, new Vector3(xmousesave, 270, 0), Time.deltaTime*speed);
                xcamchange = zcamchange;
                xcamchange *= -1;
                zcamchange = buffer;

                break;
            case 2:
                this.GetComponent<Transform>().localEulerAngles = Vector3.Lerp(this.GetComponent<Transform>().localEulerAngles, new Vector3(xmousesave, 180, 0), Time.deltaTime*speed);
                xcamchange *= -1;
                zcamchange *= -1;
                break;
            case 3:
                this.GetComponent<Transform>().localEulerAngles = Vector3.Lerp(this.GetComponent<Transform>().localEulerAngles, new Vector3(xmousesave, 90, 0), Time.deltaTime*speed);
                xcamchange = zcamchange;
                zcamchange = buffer;
                zcamchange *= -1;
                break;
            case 4:
                this.GetComponent<Transform>().localEulerAngles = Vector3.Lerp(this.GetComponent<Transform>().localEulerAngles, new Vector3(xmousesave, 0, 0), Time.deltaTime*speed);
                break;
        }

        if (this.GetComponent<Transform>().localPosition.x + xcamchange <= maxx && this.GetComponent<Transform>().localPosition.x + xcamchange >= minx)
        {
            this.GetComponent<Transform>().localPosition = Vector3.Lerp(this.GetComponent<Transform>().localPosition, this.GetComponent<Transform>().localPosition + new Vector3(xcamchange, 0, 0), Time.deltaTime*speed);
            //this.GetComponent<Transform>().localPosition += new Vector3(xcamchange, 0, 0);
        }
        if (this.GetComponent<Transform>().localPosition.y + ycamchange <= maxy && this.GetComponent<Transform>().localPosition.y + ycamchange >= miny)
        {
            this.GetComponent<Transform>().localPosition = Vector3.Lerp(this.GetComponent<Transform>().localPosition, this.GetComponent<Transform>().localPosition + new Vector3(0, ycamchange, 0), Time.deltaTime*speed);
           // this.GetComponent<Transform>().localPosition += new Vector3(0, ycamchange, 0);
        }
        if (this.GetComponent<Transform>().localPosition.z + zcamchange <= maxz && this.GetComponent<Transform>().localPosition.z + zcamchange >= minz)
        {
            this.GetComponent<Transform>().localPosition = Vector3.Lerp(this.GetComponent<Transform>().localPosition, this.GetComponent<Transform>().localPosition + new Vector3(0, 0, zcamchange), Time.deltaTime*speed);
            // this.GetComponent<Transform>().localPosition += new Vector3(0, 0, xcamchange);
        }



        xcamchange = 0;
        ycamchange = 0;
        zcamchange = 0;
    }

}
