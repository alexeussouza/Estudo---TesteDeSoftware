using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Features.Core;
using FluentValidation;


namespace Features.Clientes
{
    public class Cliente : Entity
    {

        public string Nome { get; private set; }
        public string Sobrenome { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public DateTime DataCadastro { get; private set; }
        public string Email { get; private set; }
        public bool Ativo { get; private set; }

        protected Cliente()
        {

        }

        public Cliente(Guid id, string nome, string sobrenome, DateTime dataNascimento, string email, bool ativo, DateTime dataCadastro)
        {
            Id = id;
            Nome = nome;
            Sobrenome = sobrenome;
            DataNascimento = dataNascimento;
            Email = email;
            Ativo = ativo;
            DataCadastro = dataCadastro;    

        }

        public string NomeCompleto()
        {
            return $"{Nome} {Sobrenome}";
        }

        public bool EhEspecial()
        {
            return DataCadastro < DateTime.Now.AddYears(-3) && Ativo; 
            // verifica se cadastro foi feito a 3 anos atras e continua Ativo
        }

        public void Inativar()
        {
            Ativo = false;
        }

        public override bool EhValido()
        {
            ValidationResult = new ClienteValidacao().Validate(instance: this);
            return ValidationResult.IsValid;
        }

    }

    public class ClienteValidacao : AbstractValidator<Cliente> // Cliente será a entidade validada
    {
        public ClienteValidacao()
        {
            RuleFor(expression: c => c.Nome)
                .NotEmpty().WithMessage("Por favor, certifique-se de ter inserido o nome")
                .Length(min: 2, max: 150).WithMessage("O nome deve ter entre 2 e 150 caracteres");

            RuleFor(expression: c => c.Sobrenome)
                .NotEmpty().WithMessage("Por favor, certifique-se de ter inserido o sobrenome")
                .Length(min: 2, max: 150).WithMessage("O sobrenome deve ter entre 2 e 150 caracteres");

            RuleFor(expression: c => c.DataNascimento)
                .NotEmpty()
                .Must(HaveMinimumAge) // deve ser maior de 18 anos
                .WithMessage("O cliente deve ter 18 anos ou mais");

            RuleFor(expression: c => c.Email)
                .NotEmpty()
                .EmailAddress(); // verifica se o endereço de email é valido

            RuleFor(expression: c => c.Id)
                .NotEqual(toCompare: Guid.Empty);// verifica se o Id não está vazio
        }

        public static bool HaveMinimumAge(DateTime birthDate)
        {
            return birthDate <= DateTime.Now.AddYears(-18); // verifica se nascimento foi a 18 anos ou mais
        }
    }
}
