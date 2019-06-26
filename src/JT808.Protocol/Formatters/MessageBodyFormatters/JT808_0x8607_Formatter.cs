﻿using JT808.Protocol.Extensions;
using JT808.Protocol.MessageBody;
using JT808.Protocol.Interfaces;
using System;
using System.Collections.Generic;
using JT808.Protocol.MessagePack;

namespace JT808.Protocol.Formatters.MessageBodyFormatters
{
    public class JT808_0x8607_Formatter : IJT808MessagePackFormatter<JT808_0x8607>
    {
        public JT808_0x8607 Deserialize(ref JT808MessagePackReader reader, IJT808Config config)
        {
            JT808_0x8607 jT808_0X8607 = new JT808_0x8607();
            jT808_0X8607.AreaCount = reader.ReadByte();
            jT808_0X8607.AreaIds = new List<uint>();
            for (var i = 0; i < jT808_0X8607.AreaCount; i++)
            {
                jT808_0X8607.AreaIds.Add(reader.ReadUInt32());
            }
            return jT808_0X8607;
        }

        public void Serialize(ref JT808MessagePackWriter writer, JT808_0x8607 value, IJT808Config config)
        {
            if (value.AreaIds != null)
            {
                writer.WriteByte((byte)value.AreaIds.Count);
                foreach (var item in value.AreaIds)
                {
                    writer.WriteUInt32(item);
                }
            }
        }
    }
}
