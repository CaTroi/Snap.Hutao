﻿// Copyright (c) DGP Studio. All rights reserved.
// Licensed under the MIT license.

using Microsoft.UI.Xaml.Controls;

namespace Snap.Hutao.Factory.Abstraction;

/// <summary>
/// 内容对话框工厂
/// </summary>
[HighQuality]
internal interface IContentDialogFactory
{
    /// <summary>
    /// 异步确认
    /// </summary>
    /// <param name="title">标题</param>
    /// <param name="content">内容</param>
    /// <returns>结果</returns>
    ValueTask<ContentDialogResult> ConfirmAsync(string title, string content);

    /// <summary>
    /// 异步确认或取消
    /// </summary>
    /// <param name="title">标题</param>
    /// <param name="content">内容</param>
    /// <param name="defaultButton">默认按钮</param>
    /// <returns>结果</returns>
    ValueTask<ContentDialogResult> ConfirmCancelAsync(string title, string content, ContentDialogButton defaultButton = ContentDialogButton.Close);

    /// <summary>
    /// 异步创建一个新的内容对话框，用于提示未知的进度
    /// </summary>
    /// <param name="title">标题</param>
    /// <returns>内容对话框</returns>
    ValueTask<ContentDialog> CreateForIndeterminateProgressAsync(string title);
}