using ServiceLocator.Player;
using ServiceLocator.Utilities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameService : GenericMonoSingleton<GameService>
{
    public  PlayerService playerService { get; private set; }

    [SerializeField] public PlayerScriptableObject playerScriptableObject;
    // Start is called before the first frame update
    void Start()
    {
        playerService = new PlayerService(playerScriptableObject);
    }

    // Update is called once per frame
    void Update()
    {
        playerService.Update();
    }
}
