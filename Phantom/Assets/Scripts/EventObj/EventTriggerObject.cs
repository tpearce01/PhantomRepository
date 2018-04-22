using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using System.Linq;

public class EventTriggerObject : MonoBehaviour {
    public EventManager eventManager;       // Use this to trigger events

    public float range;                     // Clickable area & distance to activate

    private CircleCollider2D rangeCollider; // Collider to represent range
    public string eventTitle;               // Text to display on mouseover
    private Text eventTitleText;            // Text object to display

    private Color hoverColor = new Color(.5f, 0f, 0f);  // Object is this color on mouseover
    private Color defaultColor = Color.white;           // Default object color
    private Fade fade;                                  // Use this to fade text in / out

    // Set default values, start idle coroutine
    void Start() {
        rangeCollider = gameObject.GetComponent<CircleCollider2D>();
        rangeCollider.radius = range;

        eventTitleText = transform.parent.Find("TextCanvas").gameObject.GetComponentInChildren<Text>();
        eventTitleText.color = new Color(eventTitleText.color.r, eventTitleText.color.g, eventTitleText.color.b, 0);
        if (eventTitle != string.Empty)
            eventTitleText.text = eventTitle;
        fade = Fade.CreateFade(gameObject);

        StartCoroutine(Idle());
    }

    // Hover / Mouseover
    void OnMouseEnter() {
        gameObject.GetComponent<SpriteRenderer>().color = hoverColor;
        fade.FadeInText(eventTitleText);
    }

    // End Hover / Mouseover
    void OnMouseExit() {
        gameObject.GetComponent<SpriteRenderer>().color = defaultColor;
        fade.FadeOutText(eventTitleText);
    }

    // Default behavior
    IEnumerator Idle() {
        Vector2 scale = gameObject.transform.localScale;
        Vector2 baseScale = scale;
        Vector2 fluxuation = new Vector2(scale.x * 1.2f, scale.y * 1.2f);   // Fluxuates by 20%
        int framesPerSecond = (int)(1 / Time.fixedDeltaTime);
        int degreeRotationPerFrame = 1;

        while (true) {
            // Increase scale
            while (scale.magnitude < fluxuation.magnitude) {
                scale += Vector2.one * (0.2f / framesPerSecond);
                gameObject.transform.localScale = scale;
                gameObject.transform.Rotate(0, 0, degreeRotationPerFrame);
                yield return new WaitForFixedUpdate();
            }

            // Decrease scale
            while (scale.magnitude > baseScale.magnitude) {
                scale -= Vector2.one * (0.2f / framesPerSecond);
                gameObject.transform.localScale = scale;
                gameObject.transform.Rotate(0, 0, degreeRotationPerFrame);
                yield return new WaitForFixedUpdate();
            }
            yield return new WaitForFixedUpdate();
        }
    }

    // Trigger event if player enters range && this is the target event
    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Player") && Player.targetEvent == gameObject.gameObject.name) {
            Player.targetEvent = null;
            eventManager.TriggerEvent();
        }
    }

    // Set this event as the Player's target event
    void OnMouseDown() {
        Player.targetEvent = gameObject.gameObject.name;
    }
}
