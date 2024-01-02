using UnityEngine;
using UnityEngine.Events;

public class GameEvents : MonoBehaviour
{
    private bool anyDeaths;
    public UnityEvent<bool> characterDeathEvent;

    public void RunSim(bool anyDeathUpdate) {
        anyDeaths = anyDeathUpdate;

        characterDeathEvent.Invoke(anyDeathUpdate);

    }

}
