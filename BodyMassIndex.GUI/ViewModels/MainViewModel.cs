using BodyMassIndex.Models;
using System.ComponentModel;
using System.Windows.Input;

namespace BodyMassIndex.GUI.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private string _nombre;

        public string Nombre
        {
            get => _nombre;
            set
            {
                if (_nombre != value)
                {
                    _nombre = value;
                    OnPropertyChanged(nameof(Nombre));
                }
            }
        }

        private double _peso;

        public double Peso
        {
            get => _peso;
            set
            {
                if (_peso != value)
                {
                    _peso = value;
                    OnPropertyChanged(nameof(Peso));
                }
            }
        }
        private double _estatura;

        public double Estatura
        {
            get => _estatura;
            set
            {
                if (value != _estatura)
                {
                    _estatura = value;
                    OnPropertyChanged(nameof(Estatura));
                }
            }
        }

        private double _indiceDeMasaCorporal;

        public double IndiceDeMasaCorporal
        {
            get => _indiceDeMasaCorporal;
            set
            {
                if (value != _indiceDeMasaCorporal)
                {
                    _indiceDeMasaCorporal = value;
                    OnPropertyChanged(nameof(IndiceDeMasaCorporal));
                }
            }
        }
        private string _situacionNutricional;

        public string SituacionNutricional
        {
            get => _situacionNutricional;
            set
            {
                if (value != _situacionNutricional)
                {
                    _situacionNutricional = value;
                    OnPropertyChanged(nameof(SituacionNutricional));
                }
            }

        }


        public event PropertyChangedEventHandler PropertyChanged;

        public Persona Persona { get; set; }

        public ICommand CalcularImcCommand { get; private set; }
        public ICommand LimpiarCommand { get; private set; }

        public MainViewModel()
        {
            Persona = null;
            CalcularImcCommand = new Command(CalcularImc);
            LimpiarCommand = new Command(Limpiar);
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private void CalcularImc()
        {
            Persona = new Persona(Nombre, Peso, Estatura);
            IndiceDeMasaCorporal =
                CalculadoraIMC.IndiceDeMasaCorporal(
                    Persona.Peso, Persona.Estatura);

            SituacionNutricional =
                SituacionNutricionalComoTexto(IndiceDeMasaCorporal);

        }

        private void Limpiar()
        {
            Nombre = string.Empty;
            Peso = 0.0;
            Estatura = 0.0;
            IndiceDeMasaCorporal = 0.0;
            SituacionNutricional = string.Empty;
        }

        private string SituacionNutricionalComoTexto(double imc)
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
    }

}