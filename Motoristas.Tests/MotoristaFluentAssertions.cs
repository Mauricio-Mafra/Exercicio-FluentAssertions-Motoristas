using FluentAssertions;
using FluentAssertions.Types;

namespace Motoristas.Tests
{
    public class MotoristaFluentAssertions
    {
        [Fact(DisplayName = "Lista de pessoas vazia")]
        [Trait("Motoristas insuficientes","")]
        public void EncontrarMotoristas_ListaDePessoasVazia_DisparaException()
        {
            //Arrange
            string msg_esperada = "A viagem não será realizada devido a falta de motoristas";
            List<Pessoa> pessoas = new List<Pessoa>();
            Motorista motorista = new Motorista();


            //Act
            Action act = () => motorista.EncontrarMotoristas(pessoas);

            //Assert
            act.Should()
                .Throw<Exception>()
                .WithMessage(msg_esperada);
        }

        [Fact(DisplayName = "Apenas um motorista")]
        [Trait("Motoristas insuficientes", "")]
        public void EncontrarMotoristas_ApenasUmMotorista_DisparaException()
        {
            string msg_esperada = "A viagem não será realizada devido a falta de motoristas";
            //Arrange
            List<Pessoa> pessoas = new List<Pessoa> { new Pessoa("teste", 30, true) };
            var motorista = new Motorista();

            //Act
            Action act = () => motorista.EncontrarMotoristas(pessoas);

            //Assert
            act.Should()
                .Throw<Exception>()
                .WithMessage(msg_esperada);

        }

        [Fact(DisplayName = "Menores de idade")]
        [Trait("Menores de idade", "")]
        public void EncontrarMotoristas_PessoasMenoresDeIdade_DisparaException()
        {
            //Arrange
            string msg_esperada = "A viagem não será realizada devido a falta de motoristas";
            List<Pessoa> pessoas = new List<Pessoa>()
            {
                new Pessoa("Maurício", 16, false),
                new Pessoa("Juliane", 15, false),
                new Pessoa("Pedro", 17, false)
            };
            var motorista = new Motorista();

            //Act
            Action act = () => motorista.EncontrarMotoristas(pessoas);

            //Assert
            act.Should().Throw<Exception>().WithMessage(msg_esperada);
        }

        [Fact(DisplayName = "Menor de idade Habilitado")]
        [Trait("Menores de idade", "")]
        public void EncontrarMotoristas_MenoresDeIdadeComHabilitação_DisparaException()
        {
            string msg_esperada = "A viagem não será realizada devido a falta de motoristas";
            //Arrange
            var motorista = new Motorista();
            List<Pessoa> pessoas = new List<Pessoa>()
            {
                new Pessoa("Maurício", 16, true),
                new Pessoa("Juliane", 15, true),
                new Pessoa("Pedro", 17, true)
            };
            //Act
            Action act = () => motorista.EncontrarMotoristas(pessoas);

            //Assert
            act.Should()
               .Throw<Exception>()
               .WithMessage(msg_esperada);
            
        }

        [Fact(DisplayName = "Motoristas encontrados")]
        [Trait("Motoristas Válidos", "")]
        public void EncontrarMotoristas_MotoristasEncontrados_StringComNomesDosMotoristas()
        {
            var motorista = new Motorista();
            List<Pessoa> pessoas = new List<Pessoa>()
            {
                new Pessoa("Maurício", 27, true),
                new Pessoa("Juliane", 24, true),
                new Pessoa("Pedro", 20, true)
            };

            var result = motorista.EncontrarMotoristas(pessoas);

            result.Should().Be("Uhuu! Os motorista são Maurício e Juliane");

        }
    }
}