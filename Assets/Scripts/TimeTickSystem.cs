using UnityEngine;
using System;

public class TimeTickSystem : MonoBehaviour
{
    public GeneratorHandler GeneratorHandler;
    public class OnTickEventArgs :  EventArgs
    {
        public int tick;
    }

    public static event EventHandler<OnTickEventArgs> OnTick;
    
    private const float TICK_TIMER_MAX = 0.01f;

    public int tick;
    public float tickTimer;

    public float tickRate;

    private void Awake()
    {
        tick = 0;
    }



    private void Update()
    {
        tickTimer += Time.deltaTime;
        tickRate = (Time.deltaTime / TICK_TIMER_MAX);

        if (tickTimer >= TICK_TIMER_MAX)
        {
            tickTimer -= TICK_TIMER_MAX;
            tick++;

            if (OnTick != null) OnTick(this, new OnTickEventArgs {tick = tick});
        }
    }
}
