namespace DotNetExtension;

public static class ArgumentNullExceptionExtension
{
	public static void ThrowIfNull<TType>(this TType obj)
	{
		if (obj is null)
		{
			throw new ArgumentNullException(nameof(obj));
		}
	}
}