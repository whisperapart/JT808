﻿using JT808.Protocol.Extensions;
using JT808.Protocol.MessageBody;
using JT808.Protocol.Interfaces;
using System;
using JT808.Protocol.MessagePack;

namespace JT808.Protocol.Formatters.MessageBodyFormatters
{
    public class JT808_0x8103_0x0040_Formatter : IJT808MessagePackFormatter<JT808_0x8103_0x0040>
    {
        public JT808_0x8103_0x0040 Deserialize(ref JT808MessagePackReader reader, IJT808Config config)
        {
            JT808_0x8103_0x0040 jT808_0x8103_0x0040 = new JT808_0x8103_0x0040();
            jT808_0x8103_0x0040.ParamId = reader.ReadUInt32();
            jT808_0x8103_0x0040.ParamLength = reader.ReadByte();
            jT808_0x8103_0x0040.ParamValue = reader.ReadString( jT808_0x8103_0x0040.ParamLength);
            return jT808_0x8103_0x0040;
        }

        public void Serialize(ref JT808MessagePackWriter writer, JT808_0x8103_0x0040 value, IJT808Config config)
        {
            writer.WriteUInt32(value.ParamId);
            writer.Skip(1, out int skipPosition);
            writer.WriteString(value.ParamValue);
            int length = writer.GetCurrentPosition() - skipPosition - 1;
            writer.WriteByteReturn((byte)length, skipPosition);
        }
    }
}