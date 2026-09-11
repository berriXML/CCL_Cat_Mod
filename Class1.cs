public class CatGuardMod : IModApi
{
    public void InitMod(Mod _modInstance)
    {
        Log.Out("[CatGuard] Mod initialized!");

        ModEvents.GameStartDone.RegisterHandler(OnGameStartDone);
        ModEvents.PlayerSpawnedInWorld.RegisterHandler(OnPlayerSpawned);
    }

    private static void OnGameStartDone(
        ref ModEvents.SGameStartDoneData _data)
    {
        Log.Out("[CatGuard] GAME START DONE!");
    }

    private static void OnPlayerSpawned(
        ref ModEvents.SPlayerSpawnedInWorldData _data)
    {
        Log.Out("[CatGuard] PLAYER SPAWN EVENT FIRED!");
    }
}