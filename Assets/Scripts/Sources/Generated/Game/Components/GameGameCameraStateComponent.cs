//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public Game.CameraState gameCameraState { get { return (Game.CameraState)GetComponent(GameComponentsLookup.GameCameraState); } }
    public bool hasGameCameraState { get { return HasComponent(GameComponentsLookup.GameCameraState); } }

    public void AddGameCameraState(Game.CameraAniName newState) {
        var index = GameComponentsLookup.GameCameraState;
        var component = (Game.CameraState)CreateComponent(index, typeof(Game.CameraState));
        component.state = newState;
        AddComponent(index, component);
    }

    public void ReplaceGameCameraState(Game.CameraAniName newState) {
        var index = GameComponentsLookup.GameCameraState;
        var component = (Game.CameraState)CreateComponent(index, typeof(Game.CameraState));
        component.state = newState;
        ReplaceComponent(index, component);
    }

    public void RemoveGameCameraState() {
        RemoveComponent(GameComponentsLookup.GameCameraState);
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherGameCameraState;

    public static Entitas.IMatcher<GameEntity> GameCameraState {
        get {
            if (_matcherGameCameraState == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.GameCameraState);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherGameCameraState = matcher;
            }

            return _matcherGameCameraState;
        }
    }
}