﻿using System.Text.Json;
using JT808.Protocol.Attributes;
using JT808.Protocol.Extensions;
using JT808.Protocol.Formatters;
using JT808.Protocol.Interfaces;
using JT808.Protocol.MessagePack;

namespace JT808.Protocol.MessageBody
{
    /// <summary>
    /// 从服务器备份地址IP。该值为空，终端应使用主服务器相同配置
    /// 2019版本
    /// </summary>
    public class JT808_0x8103_0x0026 : JT808_0x8103_BodyBase, IJT808MessagePackFormatter<JT808_0x8103_0x0026>, IJT808_2019_Version, IJT808Analyze
    {
        public override uint ParamId { get; set; } = 0x0026;
        /// <summary>
        /// 数据 长度
        /// </summary>
        public override byte ParamLength { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ParamValue { get; set; }

        public void Analyze(ref JT808MessagePackReader reader, Utf8JsonWriter writer, IJT808Config config)
        {
            JT808_0x8103_0x0026 value = new JT808_0x8103_0x0026();
            value.ParamId = reader.ReadUInt32();
            value.ParamLength = reader.ReadByte();
            var paramValue = reader.ReadVirtualArray(value.ParamLength);
            value.ParamValue = reader.ReadString(value.ParamLength);
            writer.WriteNumber($"[{ value.ParamId.ReadNumber()}]参数ID", value.ParamId);
            writer.WriteNumber($"[{value.ParamLength.ReadNumber()}]参数长度", value.ParamLength);
            writer.WriteString($"[{paramValue.ToArray().ToHexString()}]参数值[从服务器备份地址IP]", value.ParamValue);
        }

        public JT808_0x8103_0x0026 Deserialize(ref JT808MessagePackReader reader, IJT808Config config)
        {
            JT808_0x8103_0x0026 value = new JT808_0x8103_0x0026();
            value.ParamId = reader.ReadUInt32();
            value.ParamLength = reader.ReadByte();
            value.ParamValue = reader.ReadString(value.ParamLength);
            return value;
        }

        public void Serialize(ref JT808MessagePackWriter writer, JT808_0x8103_0x0026 value, IJT808Config config)
        {
            writer.WriteUInt32(value.ParamId);
            writer.Skip(1, out int skipPosition);
            writer.WriteString(value.ParamValue);
            int length = writer.GetCurrentPosition() - skipPosition - 1;
            writer.WriteByteReturn((byte)length, skipPosition);
        }
    }
}
