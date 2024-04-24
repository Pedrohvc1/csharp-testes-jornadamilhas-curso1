using JornadaMilhasV1.Modelos;

namespace JornadaMilhas.Test;

public class OfertaViagemTest
{
    [Fact]
    public void TestandoOfertaValida()
    {
        //itens do teste para construir a OfertaViagem
        Rota rota = new Rota("OrigemTeste", "DestinoTeste");
        Periodo periodo = new Periodo(new DateTime(2024, 2, 1), new DateTime(2024, 2, 5));
        double preco = 100.0;
        var validacao = true;

        OfertaViagem oferta = new OfertaViagem(rota, periodo, preco);

        //Assert.Equal classe do Xunit que compara dois valores para isso passamos o valor esperado (validacao) e o valor que queremos comparar (oferta.EhValido)
        Assert.Equal(validacao, oferta.EhValido);
    }
}