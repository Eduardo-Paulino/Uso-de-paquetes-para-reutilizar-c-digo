namespace BodyMassIndex.Models
{
    public class Persona
    {
        public string? Nombre { get; set; }
        public double Peso { get; set; }
        public double Estatura { get; set; }

        public Persona(string? nombre, double peso, double estatura)
        {
            Nombre = nombre;
            Peso = peso;
            Estatura = estatura;
        }

    }
}