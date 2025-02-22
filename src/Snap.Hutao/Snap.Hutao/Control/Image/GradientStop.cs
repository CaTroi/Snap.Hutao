﻿// Copyright (c) DGP Studio. All rights reserved.
// Licensed under the MIT license.

namespace Snap.Hutao.Control.Image;

/// <summary>
/// 渐变锚点
/// </summary>
/// <param name="Offset">便宜</param>
/// <param name="Color">颜色</param>
[HighQuality]
internal struct GradientStop
{
    /// <summary>
    /// 便宜
    /// </summary>
    public float Offset;

    /// <summary>
    /// 颜色
    /// </summary>
    public Windows.UI.Color Color;

    /// <summary>
    /// 构造一个新的渐变锚点
    /// </summary>
    /// <param name="offset">偏移</param>
    /// <param name="color">颜色</param>
    public GradientStop(float offset, Windows.UI.Color color)
    {
        Offset = offset;
        Color = color;
    }
}