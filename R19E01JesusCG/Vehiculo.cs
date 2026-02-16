using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R19E01JesusCG
{
    public class Vehiculo
    {
        // CONSTANTES
        const int TAM_MAX_MARCA = 20;
        const int TAM_MIN_MARCA = 3;
        const string MARCA_MODEL_DEF = "Desconocido";
        const int TAM_MAX_MODELO = 25;
        const int TAM_MIN_MODELO = 4;
        const string TIPOS_VEHICULOS = "TURISMO FURGONETA CAMIÓN";

        // MIEMBROS / CAMPOS
        private string _marca;
        private string _modelo;
        private string _tipoVehiculo;

        // CONSTRUCTORES

        #region PROPIEDADES
        public string Marca
        {
            get
            {
                // Comprobación de Inicialización
                if (_marca == MARCA_MODEL_DEF)
                    throw new Exception("ERROR: La marca no se ha inicializado para el vehículo");

                return _marca;
            }
            set
            {
                // Validación del dato a establecer
                ValidarDato(value, TAM_MAX_MARCA, TAM_MIN_MARCA);

                // TODO: Falta implementar la validación de dígitos y signos de puntuación
                ValidarEspecialMarca(value);

                _marca = value;
            }
        }


        public string Modelo
        {
            get {
                // Comprobación de Inicialización
                if (_modelo == MARCA_MODEL_DEF)
                    throw new Exception("ERROR: Modelo del vehículo no establecido");

                return _modelo; 
            }
            
            set { 
                // Validación del dato a establecer
                ValidarDato(value, TAM_MAX_MODELO, TAM_MIN_MODELO);

                _modelo = value; 
            }
        }

        public string TipoVehiculo
        {
            get
            {
                return _tipoVehiculo;
            }

            set
            {
                // Validación del Tipo de Vehículo
                value = value.ToUpper();
                if (!TIPOS_VEHICULOS.Contains(value))
                    throw new Exception("ERROR: Tipo de Vehículo no válido");

                _tipoVehiculo = value;
            }
        }
        #endregion

        #region MÉTODOS PRIVADOS
        private void ValidarDato(string dato, int tamMax, int tamMin)
        {
            // 1.- Nulo o Vacío
            if (string.IsNullOrEmpty(dato))
                throw new Exception("ERROR: No se ha introducido el dato");

            // 2.- Tamaño
            if (dato.Length < tamMin || dato.Length > tamMax)
                throw new Exception("ERROR: Tamaño de la cadena incorrecto");

            // 3.- Caracteres Especiales
            for (int i = 0; i < dato.Length; i++)
            {
                if (char.IsSymbol(dato[i]))
                    throw new Exception("ERROR: El dato contiene símbolos");
            }

        }

        private void ValidarEspecialMarca(string marca)
        {
            for (int i = 0; i < marca.Length; i++)
            {
                if (Char.IsDigit(marca[i]))
                    throw new Exception("ERROR: Dígitos no permitidos");

                if (Char.IsPunctuation(marca[i]))
                    throw new Exception("ERROR: Signos de Puntuación no permitidos");

            }
        }


        #endregion

        #region MÉTODOS PÚBLICOS

        #endregion
    }
}
