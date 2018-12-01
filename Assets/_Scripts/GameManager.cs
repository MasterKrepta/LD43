using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameManager {

    public static bool IsPaused = false;

    public static bool GunIsEnabled = true;
    public static bool SwordIsEnabled = true;
    public static bool JumpIsEnabled = true;
    public static bool BoostIsEnabled = true;
    //? probobly dont need battery enabled code since thats the end game

    public static void TogglePause() {
        IsPaused = !IsPaused;
        if (IsPaused) {
            Time.timeScale = 0;
        }
        else {
            Time.timeScale = 1;
        }
    }
}
