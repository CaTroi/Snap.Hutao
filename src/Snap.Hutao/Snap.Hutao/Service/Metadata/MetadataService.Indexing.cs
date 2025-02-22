﻿// Copyright (c) DGP Studio. All rights reserved.
// Licensed under the MIT license.

using Snap.Hutao.Model.Intrinsic;
using Snap.Hutao.Model.Metadata;
using Snap.Hutao.Model.Metadata.Avatar;
using Snap.Hutao.Model.Metadata.Item;
using Snap.Hutao.Model.Metadata.Reliquary;
using Snap.Hutao.Model.Metadata.Weapon;
using Snap.Hutao.Model.Primitive;

namespace Snap.Hutao.Service.Metadata;

/// <summary>
/// 索引部分
/// </summary>
internal sealed partial class MetadataService
{
    /// <inheritdoc/>
    public ValueTask<Dictionary<EquipAffixId, ReliquarySet>> GetEquipAffixIdToReliquarySetMapAsync(CancellationToken token = default)
    {
        return FromCacheAsDictionaryAsync<EquipAffixId, ReliquarySet>("ReliquarySet", r => r.EquipAffixId, token);
    }

    /// <inheritdoc/>
    public ValueTask<Dictionary<AvatarId, Avatar>> GetIdToAvatarMapAsync(CancellationToken token = default)
    {
        return FromCacheAsDictionaryAsync<AvatarId, Avatar>("Avatar", a => a.Id, token);
    }

    /// <inheritdoc/>
    public async ValueTask<Dictionary<MaterialId, Display>> GetIdToDisplayAndMaterialMapAsync(CancellationToken token = default)
    {
        Dictionary<MaterialId, Display> displays = await FromCacheAsDictionaryAsync<MaterialId, Display>("Display", a => a.Id, token).ConfigureAwait(false);
        Dictionary<MaterialId, Material> materials = await FromCacheAsDictionaryAsync<MaterialId, Material>("Material", a => a.Id, token).ConfigureAwait(false);

        // TODO: Cache this
        Dictionary<MaterialId, Display> results = new(displays);

        foreach ((MaterialId id, Display material) in materials)
        {
            results[id] = material;
        }

        return results;
    }

    /// <inheritdoc/>
    public ValueTask<Dictionary<MaterialId, Material>> GetIdToMaterialMapAsync(CancellationToken token = default)
    {
        return FromCacheAsDictionaryAsync<MaterialId, Material>("Material", a => a.Id, token);
    }

    /// <inheritdoc/>
    public ValueTask<Dictionary<ReliquaryAffixId, ReliquaryAffix>> GetIdReliquaryAffixMapAsync(CancellationToken token = default)
    {
        return FromCacheAsDictionaryAsync<ReliquaryAffixId, ReliquaryAffix>("ReliquaryAffix", a => a.Id, token);
    }

    /// <inheritdoc/>
    public ValueTask<Dictionary<ReliquaryMainAffixId, FightProperty>> GetIdToReliquaryMainPropertyMapAsync(CancellationToken token = default)
    {
        return FromCacheAsDictionaryAsync<ReliquaryMainAffixId, FightProperty, ReliquaryMainAffix>("ReliquaryMainAffix", r => r.Id, r => r.Type, token);
    }

    /// <inheritdoc/>
    public ValueTask<Dictionary<WeaponId, Weapon>> GetIdToWeaponMapAsync(CancellationToken token = default)
    {
        return FromCacheAsDictionaryAsync<WeaponId, Weapon>("Weapon", w => w.Id, token);
    }

    /// <inheritdoc/>
    public ValueTask<Dictionary<int, Dictionary<GrowCurveType, float>>> GetLevelToAvatarCurveMapAsync(CancellationToken token = default)
    {
        return FromCacheAsDictionaryAsync<int, Dictionary<GrowCurveType, float>, GrowCurve>("AvatarCurve", a => a.Level, a => a.Curves, token);
    }

    /// <inheritdoc/>
    public ValueTask<Dictionary<int, Dictionary<GrowCurveType, float>>> GetLevelToMonsterCurveMapAsync(CancellationToken token = default)
    {
        return FromCacheAsDictionaryAsync<int, Dictionary<GrowCurveType, float>, GrowCurve>("MonsterCurve", m => m.Level, m => m.Curves, token);
    }

    /// <inheritdoc/>
    public ValueTask<Dictionary<int, Dictionary<GrowCurveType, float>>> GetLevelToWeaponCurveMapAsync(CancellationToken token = default)
    {
        return FromCacheAsDictionaryAsync<int, Dictionary<GrowCurveType, float>, GrowCurve>("WeaponCurve", w => w.Level, w => w.Curves, token);
    }

    /// <inheritdoc/>
    public ValueTask<Dictionary<string, Avatar>> GetNameToAvatarMapAsync(CancellationToken token = default)
    {
        return FromCacheAsDictionaryAsync<string, Avatar>("Avatar", a => a.Name, token);
    }

    /// <inheritdoc/>
    public ValueTask<Dictionary<string, Weapon>> GetNameToWeaponMapAsync(CancellationToken token = default)
    {
        return FromCacheAsDictionaryAsync<string, Weapon>("Weapon", w => w.Name, token);
    }
}