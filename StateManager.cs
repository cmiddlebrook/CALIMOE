using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace CALIMOE;

public class StateManager
{
    protected Dictionary<string, GameState> _states;
    protected GameState _currentState;

    public string Current => _currentState?.Name ?? "";

    public StateManager()
    {
        _states = new Dictionary<string, GameState>();
    }

    public void AddState(GameState state)
    {
        _states.Add(state.Name, state);
    }

    public void SwitchState(string name)
    {
        if (_states.ContainsKey(name))
        {
            if (_currentState != null) _currentState.Exit();

            _currentState = _states[name];
            _currentState.Enter();
        }
    }

    public GameState CurrentState()
    {
        return _currentState;
    }

    public void Update(GameTime gt)
    {
        _currentState.Update(gt);
    }

    public void Draw(SpriteBatch sb)
    {
        _currentState.Draw(sb);
    }

}
