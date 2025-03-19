using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Diagnostics;

namespace CALIMOE;

public class StateManager
{
    private Calimoe _game;
    private Dictionary<string, GameState> _states;
    //private Stack<GameState> _stateStack;
    private GameState _currentState;

    public string Current => _currentState?.Name ?? "";
    public StateManager(Calimoe game)
    {
        _game = game;
        _states = new Dictionary<string, GameState>();
        //_stateStack = new Stack<GameState>();
    }

    public void AddState(GameState state)
    {
        Debug.Assert(state != null, "State must be initialised");
        Debug.Assert(state.Name != "", "State name must be defined");

        _states.Add(state.Name.ToLower(), state);
        state.LoadContent();
    }

    public void SwitchState(string name)
    {
        name = name.ToLower();
        if (_states.ContainsKey(name))
        {
            if (_currentState != null) _currentState.Exit();

            _currentState = _states[name];
            _game.ClearColour = _currentState.ClearColour;

            _currentState.Enter();
        }

        Debug.Assert(_states.ContainsKey(name), $"State name '{name}'should be in the list");
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
