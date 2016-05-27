namespace MyPhotoshop
{
	public interface IFilter
	{
	    ParameterInfo[] GetParameters();
		Photo Process(Photo original, double[] values);
	}
}