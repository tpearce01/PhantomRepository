using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleKeyItem : Item {

    public override IEnumerator TriggerEvent() {
        //Open door
        yield break;
    }
}
