using UnityEngine;
using UnityEngine.Playables;

public class TimelineManager : MonoBehaviour
{
    public static TimelineManager Instance
    {
        get 
        {
            if (instance == null)
            {
                instance = FindObjectOfType<TimelineManager>();
            }
            return instance;
        }
    }

    private static TimelineManager instance = null;

    public PlayableDirector Timeline
    {
        get { return timeline; }
    }

    private PlayableDirector timeline = null;

    private void Awake()
    {
        timeline = GetComponent<PlayableDirector>();
    }

    public void PlayTimeline()
    {
        timeline.Play();
    }
}
