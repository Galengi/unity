using UnityEngine;

public class Clock
{
    float LastTime,   //Last time the clock was started again
            Timing;   //Amount of time to be waiting for until the clock starts the alarm

    const float NOT_INITIALIZED = -1.0f;    //Value that indicates that the timer has no valid content

    public void SetAlarm(float alarm)
    {
        Timing = alarm;
    }

    public void StartAlarm()
    {
        LastTime = Time.time;
    }

    public void Start()
    {
        LastTime = NOT_INITIALIZED;
        Timing = 0.0f;
    }

    /**
    bool RunningTimeOut()
    Decides if the time running has exceeded the minimum amount of 
    */
    public bool TimeOut()
    {
        //Check the semaphore to decide if the timing has to be reset or not
        if (NOT_INITIALIZED == LastTime)
        {
            LastTime = Time.time;
            return false;
        }

        return Time.time - LastTime > Timing;
    }

}
