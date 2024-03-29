﻿using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Windows.Forms;

namespace ACT.HueSync.Hue
{
    public class HueBridgeInfo
    {
        [JsonPropertyName("id")]
        public string ID { get; set; }

        [JsonPropertyName("internalipaddress")]
        public string IpAddress { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }
    }

    public class RestError
    {
        [JsonPropertyName("type")]
        public int Type { get; set; }

        [JsonPropertyName("address")]
        public string Address { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }
    }

    public class HueErrorResponse
    {
        [JsonPropertyName("error")]
        public RestError Error { get; set; }
    }

    public class RegisterSuccess
    {
        [JsonPropertyName("username")]
        public string Username { get; set; }
    }

    public class PutSuccessResponse
    {
        public Dictionary<string, object> Data { get; set; }
    }

    public class PutResponse
    {
        [JsonPropertyName("error")]
        public RestError Error { get; set; }

        [JsonPropertyName("success")]
        public PutSuccessResponse Success { get; set; }
    }

    public class GetStateResponse
    {
        [JsonPropertyName("error")]
        public RestError Error { get; set; }

        [JsonPropertyName("success")]
        public HueLight Success { get; set; }
    }

    public class RegisterResponse
    {
        [JsonPropertyName("error")]
        public RestError Error { get; set; }

        [JsonPropertyName("success")]
        public RegisterSuccess Success { get; set; }
    }

    public class RegisterResult
    {
        public string Type { get; set; }
        public string Message { get; set; }
    }


    public class HueLight
    {
        [JsonPropertyName("state")]
        public HueLightState State { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("modelid")]
        public string Modelid { get; set; }

        [JsonPropertyName("productname")]
        public string Productname { get; set; }

        [JsonPropertyName("uniqueid")]
        public string Uniqueid { get; set; }

    }

    public class HueLightState
    {
        [JsonPropertyName("on")]
        public bool On { get; set; }

        [JsonPropertyName("bri")]
        public int Bri { get; set; }

        [JsonPropertyName("hue")]
        public int Hue { get; set; }

        [JsonPropertyName("sat")]
        public int Sat { get; set; }

        [JsonPropertyName("effect")]
        public string Effect { get; set; }

        [JsonPropertyName("xy")]
        public List<double> Xy { get; set; }

        [JsonPropertyName("ct")]
        public int Ct { get; set; }

        [JsonPropertyName("alert")]
        public string Alert { get; set; }

        [JsonPropertyName("colormode")]
        public string Colormode { get; set; }

        [JsonPropertyName("mode")]
        public string Mode { get; set; }

        [JsonPropertyName("reachable")]
        public bool Reachable { get; set; }
    }

    public class LightConfig
    {
        /// <summary>
        /// 選択中
        /// </summary>
        /// 
        public bool Enabled { get; set; }

        /// <summary>
        /// 電源
        /// </summary>
        public bool Power { get; set; }

        /// <summary>
        /// デバイスのID（リクエスト時に使う）
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// ユーザーが付けてる名前
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// デバイスのMac Address
        /// </summary>
        public string Uniqueid { get; set; }

        /// <summary>
        /// 製品名
        /// </summary>
        public string ProductName { get; set; }
    }

    public class ColorSetting
    {
        public string Category { get; set; }
        public string TimeZone { get; set; }
        public string Color { get; set; }
    }

    public class PutLightState
    {
        public bool On { get; set; }
        public float Bri { get; set; }
        public float Hue { get; set; }
        public float Sat { get; set; }
    }
}
