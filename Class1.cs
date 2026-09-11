using UnityEngine;
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
        Log.Out("[CatGuard] Player spawn detected - attempting mountain lion spawn.");

        var world = GameManager.Instance.World;
        var player = world.GetPrimaryPlayer();

        if (player == null)
        {
            Log.Out("[CatGuard] ERROR: Could not find local player.");
            return;
        }

        int entityClassId = -1;

        foreach (var item in EntityClass.list.Dict)
        {
            if (item.Value.entityClassName == "animalMountainLion")
            {
                entityClassId = item.Key;
                break;
            }
        }

        if (entityClassId == -1)
        {
            Log.Out("[CatGuard] ERROR: animalMountainLion not found.");
            return;
        }

        Log.Out(
            $"[CatGuard] Found animalMountainLion. Entity class ID: {entityClassId}"
        );

        Vector3 spawnPosition =
            player.position + new Vector3(4f, 0f, 4f);

        Entity lion = EntityFactory.CreateEntity(
            entityClassId,
            spawnPosition
        );

        if (lion == null)
        {
            Log.Out("[CatGuard] ERROR: EntityFactory failed to create mountain lion.");
            return;
        }

        lion.SetSpawnerSource(EnumSpawnerSource.Dynamic);

        world.SpawnEntityInWorld(lion);

        Log.Out("[CatGuard] SUCCESS: Mountain lion spawned!");
    }
}