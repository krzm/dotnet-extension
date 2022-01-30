using System;
using Xunit;

namespace DotNetExtension.Tests;

/// <summary>
/// todo: when net 6 add ArgumentNullException.ThrowIfNull
/// </summary>
public class NullChecksInCSharp10Tests
{
	int GetLength(string text)
	{
		return text.Length;
	}

	[Theory]
	[InlineData("Not null", 8)]
	[InlineData("", 0)]
	public void Test_Method_Without_Nullcheck_On_Strings(
		string text
		, int length)
	{
		Assert.Equal(length, GetLength(text));
	}

	[Theory]
	[InlineData(null)]
	public void Test_Method_Without_Nullcheck_On_Null(
		string text)
	{
		Assert.Throws<NullReferenceException>(() => GetLength(text));
	}

	int GetLength2(string text)
	{
		if (text is null)
		{
			throw new ArgumentNullException(nameof(text));
		}
		return text.Length;
	}

	[Theory]
	[InlineData(null)]
	public void Test_Method_With_Plain_Nullcheck_On_Null(
		string text)
	{
		Assert.Throws<ArgumentNullException>(() => GetLength2(text));
	}

	int GetLength3(string text)
	{
		ArgumentNullExceptionExtension.ThrowIfNull(text);
		return text.Length;
	}

	[Theory]
	[InlineData(null)]
	public void Test_Method_With_Extension_Nullcheck_On_Null(
		string text)
	{
		Assert.Throws<ArgumentNullException>(() => GetLength3(text));
	}
}