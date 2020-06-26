using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool isInputAvailable = true;
    public static bool isShovelTaken = false;
    public static bool isFoodTaken = false;
    public static bool isCPUCartTaken = true;
    public static bool isFoodThrowed = false;
    public static bool isKeyTaken = false;
    public static bool isDoorOpen = false;
    public static bool isMacintoshTurnedOn = false;
    public static bool isGoingOutFromBuilding = false;
    public static bool isPasswordTaken = false;
    public static bool isMacintoshTyping = false;
    public static bool isBearLeaveTheScene = false;
    public static bool isDigged = false;

    public static void restartGame()
    {
        isInputAvailable = true;
        isShovelTaken = false;
        isFoodTaken = false;
        isCPUCartTaken = false;
        isFoodThrowed = false;
        isKeyTaken = false;
        isDoorOpen = false;
        isMacintoshTurnedOn = false;
        isGoingOutFromBuilding = false;
        isPasswordTaken = false;
        isMacintoshTyping = false;
        isBearLeaveTheScene = false;
        isDigged = false;
    }
}
