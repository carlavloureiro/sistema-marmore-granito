namespace SistemaMarmoreGranito.Models;

public class Chapa
{
    public int Id { get; set; }
    public int BlocoCodigo { get; set; } 
    public string TipoMaterial { get; set; }
    public double Comprimento { get; set; }
    public double Largura { get; set; }
    public decimal Valor { get; set; }
}
