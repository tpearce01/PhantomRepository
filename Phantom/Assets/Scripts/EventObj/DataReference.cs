using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * DataReference
    Used to store global variables and enums
     */
public class DataReference {
    // Tags for player-movable characters
    public static readonly string[] MovementTags = new string[]{
        "Player",
        "Companion"
    };
	
}

// Scenes which may be loaded to
public enum Scenes {
    driving_to_the_park,
    MainMenu,
    EndScene,
    Carousel,
    HighwayRoad
}
