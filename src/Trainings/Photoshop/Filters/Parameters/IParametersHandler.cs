namespace MyPhotoshop
{
    public interface IParametersHandler<out TParameters> where TParameters : IParameters, new()
    {
        ParameterInfo[] Description();
        TParameters CreateParameters(double[] values);
    }
}