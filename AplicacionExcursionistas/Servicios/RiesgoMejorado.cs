#region  Using
using AplicacionExcursionistas.Modelo;
#endregion

namespace AplicacionExcursionistas.Servicios
{
    public class RiesgoMejorado
    {
        #region EncontrarCombinacionOptima
        public List<Elemento> EncontrarCombinacionOptima(EscRiesgo request)
        {
            List<Elemento> mejorCombinacion = null;
            int mejorPeso = int.MaxValue;

            int n = request.Elementos.Count;
            for (int i = 0; i < (1 << n); i++)
            {
                var actual = new List<Elemento>();
                int peso = 0, calorias = 0;

                for (int j = 0; j < n; j++)
                {
                    if ((i & (1 << j)) != 0)
                    {
                        var e = request.Elementos[j];
                        actual.Add(e);
                        peso += e.Peso;
                        calorias += e.Calorias;
                    }
                }

                if (calorias >= request.CaloriasMinimas && peso <= request.PesoMaximo && peso < mejorPeso)
                {
                    mejorPeso = peso;
                    mejorCombinacion = new List<Elemento>(actual);
                }
            }

            return mejorCombinacion ?? new List<Elemento>();
        }
        #endregion
    }
}
