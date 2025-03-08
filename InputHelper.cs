using Microsoft.Xna.Framework.Input;
using System;


namespace CALIMOE;

public class InputHelper
{
    protected KeyboardState _previousKeyboardState;
    protected KeyboardState _currentKeyboardState;
    protected MouseState _previousMouseState;
    protected MouseState _currentMouseState;
    public InputHelper()
    {
    }

    public void Update()
    {
        _previousKeyboardState = _currentKeyboardState;
        _currentKeyboardState = Keyboard.GetState();
        _previousMouseState = _currentMouseState;
        _currentMouseState = Mouse.GetState();
    }

    public bool KeyDown(Keys key)
    {
        return Keyboard.GetState().IsKeyDown(key);
    }

    public bool KeyUp(Keys key)
    {
        return Keyboard.GetState().IsKeyUp(key);
    }
    public bool KeyPressed(Keys key)
    {
        return _currentKeyboardState.IsKeyDown(key) && _previousKeyboardState.IsKeyUp(key);
    }
}
