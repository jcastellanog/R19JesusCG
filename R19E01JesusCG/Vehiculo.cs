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

        const float PRECIO_MIN = 1000;
        const float PRECIO_MAX = 100000;
        const float PRECIO_DEF = 0;

        const float DESCUENTO = 0.10f;

        // MIEMBROS / CAMPOS
        private string _marca;
        private string _modelo;
        private string _tipoVehiculo;
        private float _precioContado;

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
        
        public float PrecioContado
        {
            get
            {
                if (_precioContado == PRECIO_DEF)
                    throw new Exception("ERROR: Precio no establecido");

                return _precioContado;
            }
            set
            {
                // Validación del Precio
                ValidarPrecio(value);

                _precioContado = value;
            }
        }

        public float PrecioFinanciado
        {
            get
            {
                return CalcularPrecioFinanciado();
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


        private void ValidarPrecio(float precio)
        {
            if (precio < PRECIO_MIN)
                throw new Exception("ERROR: Precio inferior al mínimo permitido");

            if (precio > PRECIO_MAX)
                throw new Exception("ERROR: Precio superior al máximo permitido");
        }

        #endregion

        #region MÉTODOS PÚBLICOS
        public float CalcularPrecioFinanciado()
        {
            float precioF;

            precioF = PrecioContado - (PrecioContado * DESCUENTO);

            return precioF;
        }
        #endregion
    }
}
