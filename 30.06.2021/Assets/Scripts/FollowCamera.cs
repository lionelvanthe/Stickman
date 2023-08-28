using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Camera))]
public class FollowCamera : MonoBehaviour
{
    private MoveAni ani;
    public List<Transform> targets;
    public Transform pl1, pl2;
    public Vector3 offset;           // phan bu
    private float smoothTime = 1f;
    public float minZoom;
    public float maxZoom;
    public float zoomLimiter;

    public bool hyo = true;
    private Vector3 velocity  = Vector3.zero;
    private Camera cam;
   // private Vector3 Vstart;

//toch move camre
    private Vector3 touchStart;
    public float groundZ;
    public bool notFollow= true;
    private void Start()
    {
        cam = GetComponent<Camera>();
        ani = GetComponent<MoveAni>();

        smoothTime = 1f;
    }

    private void Update()
    {
        if (hyo)
        {
            if (Input.GetMouseButtonDown(0))
            {
                touchStart = GetWorldPosition(groundZ);
                //  cam.transform.position = Vector3.Lerp(cam.transform.position, /*vitri*/ smoothTime);
            }

            if (Input.GetMouseButton(0))
            {
                Vector3 direction = touchStart - GetWorldPosition(groundZ);
                Camera.main.transform.position += direction;
                notFollow = false;
            }
            else if(Input.GetMouseButtonUp(0))
            {
                notFollow = true;
            }
        }
               
    }
    private Vector3 GetWorldPosition(float z)
    {
        Ray mousePos = cam.ScreenPointToRay(Input.mousePosition);
        Plane ground = new Plane(Vector3.forward, new Vector3(0, 0, z));
        float distance;
        ground.Raycast(mousePos, out distance);
        return mousePos.GetPoint(distance);
    }

public Vector2  minPos, maxPos;
    private void LateUpdate()
    {
        if (targets.Count == 0)
        {
            return;
        }
        Move();

       // Zoom();
       
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, minPos.x, maxPos.x),
                                       Mathf.Clamp(transform.position.y, minPos.y, maxPos.y),
                                       Mathf.Clamp(transform.position.z, transform.position.z, transform.position.z));

      
    }

    void Zoom()
    {
       // float newZoom = Mathf.Lerp(maxZoom, minZoom, GetGreatestDistance() / zoomLimiter);
         // cam.fieldOfView =Mathf.Lerp(cam.fieldOfView, newZoom, Time.deltaTime);
       cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, minZoom, Time.deltaTime );

       // CameraViewpoinHandler.Instance.UnitsSize = Mathf.Lerp(cam.orthographicSize, minZoom, Time.deltaTime);
    }

    float GetGreatestDistance()
    {
        var bounds = new Bounds(targets[0].position, Vector3.zero);
        for (int i = 0; i < targets.Count; i++)
        {
            bounds.Encapsulate(targets[i].position);
        }
        return bounds.size.x;
    }

    public bool First_touch = true;
    void Move()
    {
        if (!notFollow)
        {
            return;
        }
        // Vector3 centerPoint = GetCenterPoint();
        if (Check)
        {
            Vector3 newPosition = pl1.position + offset;
          //  newPosition.x = transform.position.x;
            if (First_touch)
            {              
                transform.position = Vector3.SmoothDamp(transform.position, newPosition, ref velocity, smoothTime);
            }
            else
            {
                transform.position = Vector3.SmoothDamp(transform.position, newPosition, ref velocity, smoothTime - 0.5f);
            }
        }
        else
        {
            Vector3 newPosition2 = pl2.position + offset;
           // newPosition2.x = transform.position.x;
            if (First_touch)
            {             
                transform.position = Vector3.SmoothDamp(transform.position, newPosition2, ref velocity, smoothTime);
                
            }
            else
            {
                transform.position = Vector3.SmoothDamp(transform.position, newPosition2, ref velocity, smoothTime - 0.5f);
            }
        }

    }
    public bool Check;
    Vector3 GetCenterPoint()
    {
        if (targets.Count == 1)
        {
            return targets[0].position;
        }
        var bounds = new Bounds(targets[0].position, Vector3.zero);
        for (int i = 0; i < targets.Count; i++)
        {
            bounds.Encapsulate(targets[i].position);
        }
        return bounds.center;
    }
}
