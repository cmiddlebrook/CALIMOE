using Microsoft.Xna.Framework;
using System;

namespace CALIMOE;
public class Clock
{
    protected TimeSpan _realCycleDuration;
    protected TimeSpan _virtualCycleDuration;
    protected TimeSpan _virtualDuration;
    protected TimeSpan _startTime;
    protected TimeSpan _endTime;
    protected TimeSpan _elapsedRealTime;
    protected TimeSpan _gameTime;

    public TimeSpan GameTime => _gameTime;

    public bool Finished => _elapsedRealTime > _realCycleDuration;

    public Clock(TimeSpan realCycleDuration, TimeSpan startTime, TimeSpan endTime)
    {
        _realCycleDuration = realCycleDuration;
        _startTime = startTime;
        _endTime = endTime;

        _virtualCycleDuration = (_endTime > _startTime)
            ? _endTime - _startTime
            : TimeSpan.FromHours(24) - (_startTime - _endTime);

    }


    public void Update(GameTime gt)
    {
        _elapsedRealTime += gt.ElapsedGameTime;
        double progress = _elapsedRealTime.TotalSeconds / _realCycleDuration.TotalSeconds;
        _gameTime = _startTime + TimeSpan.FromHours(progress * _virtualCycleDuration.TotalHours);
    }


}
