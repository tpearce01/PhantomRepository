using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
    public static List<GameObject> FollowTargets = new List<GameObject>();
    public Vector3 offset;

    void Start() {
        FollowTargets.AddRange(GameObject.FindGameObjectsWithTag("Follow"));
    }

    void FixedUpdate() {
        Follow();
    }

    public void Follow() {
        Vector3 location = new Vector3();
        foreach (GameObject target in FollowTargets) {
            location += new Vector3(target.transform.position.x, target.transform.position.y, 0);
        }

        location /= FollowTargets.Count;
        location = new Vector3(Mathf.Clamp(location.x, -6.8f, 6.8f), Mathf.Clamp(location.y, -1.75f, 1.75f), -10f);
        gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, location + offset, 0.1f);
    }

    public static void AddTarget(string target) {
        AddTarget(GameObject.Find(target));
    }

    public static void AddTarget(GameObject target) {
        FollowTargets.Add(target);
    }

    public static void RemoveTarget(string name) {
        foreach (GameObject target in FollowTargets) {
            if (target.name == name) {
                FollowTargets.Remove(target);
            }
        }
    }
}
