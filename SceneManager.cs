﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Diagnostics;

namespace CALIMOE;

public class SceneManager
{
    private Calimoe _game;
    private Dictionary<string, GameScene> _scenes;
    private GameScene _currentScene;

    public string Current => _currentScene?.Name ?? "";
    public SceneManager(Calimoe game)
    {
        _game = game;
        _scenes = new Dictionary<string, GameScene>();
    }

    public void AddScene(GameScene scene)
    {
        Debug.Assert(scene != null, "Scene must be initialised");
        Debug.Assert(scene.Name != "", "Scene name must be defined");

        _scenes.Add(scene.Name.ToLower(), scene);
        scene.LoadContent();
    }

    public void SwitchScene(string name)
    {
        name = name.ToLower();
        if (_scenes.ContainsKey(name))
        {
            if (_currentScene != null) _currentScene.Exit();

            _currentScene = _scenes[name];
            _game.ClearColour = _currentScene.ClearColour;

            _currentScene.Enter();
        }

        Debug.Assert(_scenes.ContainsKey(name), $"Scene name '{name}'should be in the list");
    }


    public void Update(GameTime gt)
    {
        if (_currentScene == null) return;
        _currentScene.Update(gt);
    }

    public void Draw(SpriteBatch sb)
    {
        if (_currentScene == null) return;
        _currentScene.Draw(sb);
    }

}
