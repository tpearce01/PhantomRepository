using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RitualRoomPodium : Item {
		void Awake() {
			itemName = "Ritual Room Podium";
			Texture2D tex = Resources.Load<Texture2D>("RustedKey");
			image = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), new Vector2(0, 0));
		}

		public override IEnumerator TriggerEvent() {
				// Event Code Goes Here
				yield break;
		}
}
