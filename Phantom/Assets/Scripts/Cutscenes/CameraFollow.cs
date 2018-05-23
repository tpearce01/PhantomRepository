using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
    public List<GameObject> FollowTargets = new List<GameObject>();

    void FixedUpdate() {
        Follow();
    }

    public void Follow() {
        Vector2 location = new Vector2();
        foreach (GameObject target in FollowTargets) {
            location += new Vector2(target.transform.position.x, target.transform.position.y);
        }

        location /= FollowTargets.Count;
        gameObject.transform.position = Vector2.Lerp(gameObject.transform.position, location, 0.1f);
    }

    public void AddTarget(string target) {
        AddTarget(GameObject.Find(target));
    }

    public void AddTarget(GameObject target) {
        FollowTargets.Add(target);
    }

    public void RemoveTarget(string name) {
        foreach (GameObject target in FollowTargets) {
            if (target.name == name) {
                FollowTargets.Remove(target);
            }
        }
    }
}
