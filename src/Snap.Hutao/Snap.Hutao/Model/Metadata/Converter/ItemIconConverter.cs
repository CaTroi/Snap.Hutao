﻿// Copyright (c) DGP Studio. All rights reserved.
// Licensed under the MIT license.

using Snap.Hutao.Control;

namespace Snap.Hutao.Model.Metadata.Converter;

/// <summary>
/// 物品图片转换器
/// </summary>
[HighQuality]
internal sealed class ItemIconConverter : ValueConverter<string, Uri>
{
    /// <summary>
    /// 名称转Uri
    /// </summary>
    /// <param name="name">名称</param>
    /// <returns>链接</returns>
    public static Uri IconNameToUri(string name)
    {
        if (name.StartsWith("UI_RelicIcon_"))
        {
            return RelicIconConverter.IconNameToUri(name);
        }
        else
        {
            return Web.HutaoEndpoints.StaticFile("ItemIcon", $"{name}.png").ToUri();
        }
    }

    /// <inheritdoc/>
    public override Uri Convert(string from)
    {
        return IconNameToUri(from);
    }
}