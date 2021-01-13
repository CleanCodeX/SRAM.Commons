﻿using System.IO;
using SramCommons.Helpers;

namespace SramCommons.Extensions
{
	public static class StructExtensions
	{
		/// <summary>
		/// Convert the bytes to a structure in host-endian format (little-endian on PCs).
		/// To use with big-endian data, reverse all of the data bytes and create a struct that is in the reverse order of the data.
		/// </summary>
		/// <typeparam name="type">The structure's type</typeparam>
		/// <param name="buffer">The buffer.</param>
		/// <returns></returns>
		public static T ToStruct<T>(this byte[] source) where T : struct => StructSerializer.Deserialize<T>(source);

		/// <summary>
		/// Converts the struct to a byte array in the endianness of this machine.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="source">The structure.</param>
		/// <returns></returns>
		public static byte[] ToBytes<T>(this T source) 
			where T : struct => StructSerializer.Serialize(source);

		/// <summary>
		/// Converts the struct to a memory stream in the endianness of this machine.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="source">The structure.</param>
		/// <returns></returns>
		public static MemoryStream ToStream<T>(this T source)
			where T : struct
		{
			var ms = new MemoryStream();
			StructSerializer.Serialize(ms, source);
			return ms;
		}
	}
}
