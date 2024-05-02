using JornadaMilhasV1.Modelos;

namespace JornadaMilhas.Test;

public class OfertaViagemConstrutor
{
    #region Classe OfertaViagem
    [Theory] // permite trabalar com vários cenários diferentes dentro de um mesmo teste
    [InlineData("", null, "2024-01-01", "2024-01-02", 0, false)] //podem trazer ofertas inválidas
    [InlineData("OrigemTeste", "DestinoTeste", "2024-02-01", "2024-02-05", 100, true)] //tras a oferta válida
    public void RetornaEhValidoDeAcordoComDadosDeEntrada(string origem, string destino, string dataIda, string dataVolta, double preco, bool validacao)
    {
        //// Cenário

        //itens do teste para construir a OfertaViagem
        Rota rota = new Rota(origem, destino);
        Periodo periodo = new Periodo(DateTime.Parse(dataIda), DateTime.Parse(dataVolta));

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

    [Theory]
    [InlineData("Origem1", "Destino1", "2024-08-20", "2024-08-30", -250)]
    public void RetornaMensagemDeErroDePrecoInvalidoQuandoPrecoMenorQueZero(string origem1, string destino1, string dataIda, string dataVolta, double preco)
    {
        //arrange
        Rota rota = new Rota(origem1, destino1);
        Periodo periodo = new Periodo(DateTime.Parse(dataIda), DateTime.Parse(dataVolta));       

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