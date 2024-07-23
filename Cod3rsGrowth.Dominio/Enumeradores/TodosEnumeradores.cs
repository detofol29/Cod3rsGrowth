using Cod3rsGrowth.Dominio.Enumeradores;
using Cod3rsGrowth.Dominio.Extensoes;

namespace Cod3rsGrowth.Domuinio.Enumeradores;

public class TodosEnumeradores
{
    public List<BaseParaEnumerador<T>> ObterTodos<T>() where T : new()
    {
        var valores = new List<BaseParaEnumerador<T>>();
        foreach (var item in Enum.GetValues(typeof(T)))
        {
            var enumerador = new BaseParaEnumerador<T>
            {
                Id = (T)item, 
                Descricao = ((Enum)item).ObterDescricao()
            };

            valores.Add(enumerador);
        }
        return valores;
    }
}