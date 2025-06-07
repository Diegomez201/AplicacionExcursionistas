namespace AplicacionExcursionistas.Modelo
{
    public class EscRiesgo
    {
        public int CaloriasMinimas { get; set; }
        public int PesoMaximo { get; set; }
        public List<Elemento> Elementos { get; set; } = new();
    }
}
