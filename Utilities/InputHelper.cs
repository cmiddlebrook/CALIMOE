using Microsoft.Xna.Framework.Input;
using System;
using System.Numerics;


namespace CALIMOE;

public class InputHelper
{
    protected KeyboardState _previousKeyboardState;
    protected KeyboardState _currentKeyboardState;
    protected MouseState _previousMouseState;
    protected MouseState _currentMouseState;

    public Vector2 MousePosition => new Vector2(_currentMouseState.X, _currentMouseState.Y);

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

    public bool KeyPressed(Keys key)
    {
        return _currentKeyboardState.IsKeyDown(key) && _previousKeyboardState.IsKeyUp(key);
    }

    public bool KeyReleased(Keys key)
    {
        return Keyboard.GetState().IsKeyUp(key) && _previousKeyboardState.IsKeyDown(key);
    }

    public bool KeyUp(Keys key)
    {
        return Keyboard.GetState().IsKeyUp(key);
    }

    public bool LeftButtonClicked()
    {
        return _currentMouseState.LeftButton == ButtonState.Pressed && _previousMouseState.LeftButton == ButtonState.Released;
    }

    public bool LeftButtonDown()
    {
        return _currentMouseState.LeftButton == ButtonState.Pressed;
    }

    public bool RightButtonClicked()
    {
        return _currentMouseState.RightButton == ButtonState.Pressed && _previousMouseState.RightButton == ButtonState.Released;
    }

    public bool RightButtonDown()
    {
        return _currentMouseState.RightButton == ButtonState.Pressed;
    }


    public bool StartKeyPress(Keys key)
    {
        return Keyboard.GetState().IsKeyDown(key) && _previousKeyboardState.IsKeyUp(key);
    }
}
