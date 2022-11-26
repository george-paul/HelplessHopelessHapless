using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBeam : MonoBehaviour
{
    public float maxDistance = 30;
    public float maxReflections = 3;

    private Transform barrelEnd;
    private LineRenderer line;

    private void OnEnable() {
        barrelEnd = transform.Find("Emitter End").transform;
        line = GetComponent<LineRenderer>();
    }

    private void UpdateLineRender(Transform barrelEnd, LineRenderer line) {
        List<Vector2> laserPoints = new List<Vector2> {new Vector2(barrelEnd.position.x, barrelEnd.position.y)};
        Vector2 origin = barrelEnd.position;
        Vector2 dir = barrelEnd.up;
        for(int collisionNo = 0; collisionNo < maxReflections; collisionNo++)
        {
            Ray2D ray = new Ray2D(origin, dir);
            RaycastHit2D hit = Physics2D.Raycast(origin, dir, maxDistance);
            if(hit.collider != null) {
                if(hit.collider.CompareTag("Mirror")) {
                    // reflect
                    laserPoints.Add(hit.point);
                    origin = hit.point;
                    dir = Vector2.Reflect(dir, hit.normal);
                }
                else if (hit.collider.CompareTag("SplitterInput")) {
                    // end reflection and enable splitter
                    laserPoints.Add(hit.point);
                    hit.collider.gameObject.GetComponent<SplitterOutput>().outputActiveThisFrame = true;         
                }
                else if (hit.collider.CompareTag("LaserTarget")) {
                    laserPoints.Add(hit.point);
                    hit.collider.gameObject.GetComponent<LaserTarget>().isActiveThisFrame = true;         
                }
                else {
                    // end laser
                    laserPoints.Add(hit.point);
                    break;
                }
            }
            else{
                // max length laser
                laserPoints.Add(ray.GetPoint(maxDistance));
                break;
            }
        }
        
        line.positionCount = laserPoints.Count;
        for(int idx = 0; idx < laserPoints.Count; idx++)
        {
            line.SetPosition(idx, new Vector3(laserPoints[idx].x, laserPoints[idx].y));
        }
    }

    private void Update() {
        UpdateLineRender(barrelEnd, line);
    }
}
