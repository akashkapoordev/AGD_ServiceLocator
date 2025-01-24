using UnityEngine;
using ServiceLocator.Utilities;
using ServiceLocator.Events;
using ServiceLocator.Map;
using ServiceLocator.Wave;
using ServiceLocator.Sound;
using ServiceLocator.Player;
using ServiceLocator.UI;

namespace ServiceLocator.Main
{
    public class GameService : MonoBehaviour
    {
        // Services:
        private EventService eventService;
        private MapService mapService;
        private WaveService waveService;
        private SoundService soundService;
        private PlayerService playerService;

        [SerializeField] private UIService uiService;
        public UIService UIService => uiService;


        // Scriptable Objects:
        [SerializeField] private MapScriptableObject mapScriptableObject;
        [SerializeField] private WaveScriptableObject waveScriptableObject;
        [SerializeField] private SoundScriptableObject soundScriptableObject;
        [SerializeField] private PlayerScriptableObject playerScriptableObject;

        // Scene Referneces:
        [SerializeField] private AudioSource SFXSource;
        [SerializeField] private AudioSource BGSource;

        private void Start()
        {
            createServices();
            injectDependency();
        }

        void createServices()
        {
            eventService = new EventService();
            mapService = new MapService(mapScriptableObject);
            waveService = new WaveService(waveScriptableObject);
            soundService = new SoundService(soundScriptableObject, SFXSource, BGSource);
            playerService = new PlayerService(playerScriptableObject);
        }

        void injectDependency()
        {
            playerService.init(UIService, mapService, soundService);
            waveService.init(UIService,mapService, soundService,eventService,playerService);
            UIService.init(waveService, eventService,playerService);
            mapService.init(eventService);
        }

        private void Update()
        {
            playerService.Update();
        }
    }
}