using BodyMassIndex.Models;

string? nombre;
double peso;
double estatura;
double imc;

Persona persona;

Console.WriteLine("Aplicación que calcula el indice de masa corporal de una persona.");


Console.Write("Proporcione el nombre de la persona: ");
nombre = Console.ReadLine();
peso = ReadDouble("Proporcione el peso en kilogramos de la persona:");
estatura = ReadDouble("Proporcione la estatura en metros de la persona:");

persona = new Persona(nombre, peso, estatura);

imc = CalculadoraIMC.IndiceDeMasaCorporal(persona.Peso, persona.Estatura);
Console.WriteLine($"Ïndice de masa corporal de {nombre}: {imc:F4}");
Console.WriteLine($"La situación nutricional de {persona.Nombre} es {SituacionNutricionalComoTexto(imc)}");

double ReadDouble(string s)
{
    Console.Write(s);
    string? linea = Console.ReadLine();
    return Convert.ToDouble(linea);
}

string SituacionNutricionalComoTexto(double imc)
{
    CalculadoraIMC.EstadoNutricional estadoNutricional =
        CalculadoraIMC.SituacionNutricional(imc);

    switch (estadoNutricional)
    {
        case CalculadoraIMC.EstadoNutricional.PesoBajo:
            return "Peso bajo";
        case CalculadoraIMC.EstadoNutricional.PesoNormal:
            return "Peso normal";
        case CalculadoraIMC.EstadoNutricional.Sobrepeso:
            return "Sobrepeso";
        case CalculadoraIMC.EstadoNutricional.Obesidad:
            return "Obesidad";
        case CalculadoraIMC.EstadoNutricional.ObesidadExtrema:
            return "Obesidad extrema";
        default:
            return string.Empty;
    }
}
