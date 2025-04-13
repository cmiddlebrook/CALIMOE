using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Diagnostics;

namespace CALIMOE;

public class SceneManager
{
    //private Calimoe _game;
    private Dictionary<string, GameScene> _scenes = new Dictionary<string, GameScene>();
    private GameScene _currentScene;
    protected Matrix _spriteScale = Matrix.Identity;


    public SceneManager()
    {
    }

    public void AddScene(string name, GameScene scene)
    {
        _scenes.Add(name.ToLower(), scene);
    }

    public void Draw(SpriteBatch sb)
    {
        if (_currentScene == null) return;
        _currentScene.Draw(sb);

    }

    public GameScene GetScene(string name)
    {
        return _scenes.TryGetValue(name, out var state) ? state : null;
    }

    public void HandleInput(InputHelper ih)
    {
        if (_currentScene == null) return;
        _currentScene.HandleInput(ih);
    }

    public void SetSpriteScale(Matrix spriteScale)
    {
        _spriteScale = spriteScale;
    }
    public void SwitchScene(string name)
    {
        name = name.ToLower();
        if (_scenes.ContainsKey(name))
        {
            if (_currentScene != null) _currentScene.Exit();

            _currentScene = _scenes[name];
            _currentScene.Enter();
        }

        Debug.Assert(_scenes.ContainsKey(name), $"Scene name '{name}'should be in the list");
    }


    public void Update(GameTime gt)
    {
        if (_currentScene == null) return;
        _currentScene.Update(gt);
    }

    public void Reset()
    {
        if ( _currentScene == null) return;
        _currentScene.Reset();
    }

}
