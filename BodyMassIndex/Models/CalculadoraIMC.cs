namespace BodyMassIndex.Models
{
    public static class CalculadoraIMC
    {
        public static double IndiceDeMasaCorporal(double peso, double estatura)
            => peso / Math.Pow(estatura, 2);

        public enum EstadoNutricional
        {
            PesoBajo,
            PesoNormal,
            Sobrepeso,
            Obesidad,
            ObesidadExtrema,
        }

        public static EstadoNutricional SituacionNutricional(double imc)
        {
            if (imc < 18.5)
            {
                return EstadoNutricional.PesoBajo;
            }
            else if (imc < 25.0)
            {
                return EstadoNutricional.PesoNormal;
            }
            else if (imc < 30.0)
            {
                return EstadoNutricional.Sobrepeso;
            }
            else if (imc < 40.0)
            {
                return EstadoNutricional.Obesidad;
            }
            else
            {
                return EstadoNutricional.ObesidadExtrema;
            }
        }
    }
}