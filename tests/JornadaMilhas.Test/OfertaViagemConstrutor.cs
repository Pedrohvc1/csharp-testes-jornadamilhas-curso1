using JornadaMilhasV1.Modelos;

namespace JornadaMilhas.Test;

public class OfertaViagemConstrutor
{
    #region Classe OfertaViagem
    [Fact]
    public void RetornaOfertaValidaQuandoDadosValidos()
    {
        //// Cenário

        //itens do teste para construir a OfertaViagem
        Rota rota = new Rota("OrigemTeste", "DestinoTeste");
        Periodo periodo = new Periodo(new DateTime(2024, 2, 1), new DateTime(2024, 2, 5));
        double preco = 100.0;
        var validacao = true;

        //// Ação

        OfertaViagem oferta = new OfertaViagem(rota, periodo, preco);


        //// Validação

        //Assert.Equal classe do Xunit que compara dois valores para isso passamos o valor esperado (validacao) e o valor que queremos comparar (oferta.EhValido)
        Assert.Equal(validacao, oferta.EhValido);

    }

    [Fact]
    public void RetornaMensagemDeErroDeRotaOuPeriodoInvalidosQuandoRotaNula()
    {
        //itens do teste para construir a OfertaViagem
        Rota rota = null;
        Periodo periodo = new Periodo(new DateTime(2024, 2, 1), new DateTime(2024, 2, 5));
        double preco = 100.0;

        OfertaViagem oferta = new OfertaViagem(rota, periodo, preco);

        //Assert.Contains verifica se a string passada está contida na string passada
        Assert.Contains("A oferta de viagem não possui rota ou período válidos.", oferta.Erros.Sumario);
        Assert.False(oferta.EhValido); //Assert.False verifica se o valor é falso
    }

    [Fact]
    public void RetornaMensagemDeErroDePrecoInvalidoQuandoPrecoMenorQueZero()
    {
        //arrange
        Rota rota = new Rota("Origem1", "Destino1");
        Periodo periodo = new Periodo(new DateTime(2024, 8, 20), new DateTime(2024, 8, 30));
        double preco = -250;

        //act
        OfertaViagem oferta = new OfertaViagem(rota, periodo, preco);

        //assert
        Assert.Contains("O preço da oferta de viagem deve ser maior que zero.", oferta.Erros.Sumario);
    }

    #endregion

    #region Classe Musica

    [Fact]
    public void TesteNomeInicializadoCorretamente()
    {
        // Arrange
        string nome = "Música Teste";

        // Act
        Musica musica = new Musica(nome);

        // Assert
        Assert.Equal(nome, musica.Nome);
    }

    [Fact]
    public void TesteIdInicializadoCorretamente()
    {
        // Arrange
        string nome = "Música Teste";
        int id = 13;

        // Act
        Musica musica = new Musica(nome) { Id = id };

        // Assert
        Assert.Equal(id, musica.Id);
    }

    [Fact]
    public void TesteToString()
    {
        // Arrange
        int id = 1;
        string nome = "Música Teste";
        Musica musica = new Musica(nome);
        musica.Id = id;
        string toStringEsperado = @$"Id: {id} Nome: {nome}";

        // Act
        string resultado = musica.ToString();

        // Assert
        Assert.Equal(toStringEsperado, resultado);
    }

    #endregion


}