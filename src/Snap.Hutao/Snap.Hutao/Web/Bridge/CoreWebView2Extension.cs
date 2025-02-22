﻿// Copyright (c) DGP Studio. All rights reserved.
// Licensed under the MIT license.

using Microsoft.Web.WebView2.Core;
using Snap.Hutao.Web.Hoyolab;

namespace Snap.Hutao.Web.Bridge;

/// <summary>
/// Bridge 拓展
/// </summary>
[HighQuality]
internal static class CoreWebView2Extension
{
    /// <summary>
    /// 设置 移动端UA
    /// </summary>
    /// <param name="webView">webview2</param>
    /// <returns>链式调用的WebView2</returns>
    public static CoreWebView2 SetMobileUserAgent(this CoreWebView2 webView)
    {
        webView.Settings.UserAgent = Core.CoreEnvironment.HoyolabMobileUA;
        return webView;
    }

    /// <summary>
    /// 设置 移动端OsUA
    /// </summary>
    /// <param name="webView">webview2</param>
    /// <returns>链式调用的WebView2</returns>
    public static CoreWebView2 SetMobileOverseaUserAgent(this CoreWebView2 webView)
    {
        webView.Settings.UserAgent = Core.CoreEnvironment.HoyolabOsMobileUA;
        return webView;
    }

    /// <summary>
    /// 设置WebView2的Cookie
    /// </summary>
    /// <param name="webView">webview2</param>
    /// <param name="cookieToken">CookieToken</param>
    /// <param name="lToken">LToken</param>
    /// <param name="sToken">SToken</param>
    /// <returns>链式调用的WebView2</returns>
    public static CoreWebView2 SetCookie(this CoreWebView2 webView, Cookie? cookieToken = null, Cookie? lToken = null, Cookie? sToken = null)
    {
        CoreWebView2CookieManager cookieManager = webView.CookieManager;

        if (cookieToken != null)
        {
            cookieManager.AddMihoyoCookie("account_id", cookieToken).AddMihoyoCookie("cookie_token", cookieToken);
        }

        if (lToken != null)
        {
            cookieManager.AddMihoyoCookie("ltuid", lToken).AddMihoyoCookie("ltoken", lToken);
        }

        if (sToken != null)
        {
            cookieManager.AddMihoyoCookie("stuid", sToken).AddMihoyoCookie("stoken", sToken);
        }

        return webView;
    }

    private static CoreWebView2CookieManager AddMihoyoCookie(this CoreWebView2CookieManager manager, string name, Cookie cookie)
    {
        manager.AddOrUpdateCookie(manager.CreateCookie(name, cookie[name], ".mihoyo.com", "/"));
        return manager;
    }
}