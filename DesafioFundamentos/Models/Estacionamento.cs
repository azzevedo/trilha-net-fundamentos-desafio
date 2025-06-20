using System.Text.RegularExpressions;

namespace DesafioFundamentos.Models
{
	public class Estacionamento
	{
		private decimal precoInicial = 0;
		private decimal precoPorHora = 0;
		private List<string> veiculos = new List<string>();

		public Estacionamento(decimal precoInicial, decimal precoPorHora)
		{
			this.precoInicial = precoInicial;
			this.precoPorHora = precoPorHora;
		}

		public void AdicionarVeiculo()
		{
			// [x]: Pedir para o usuário digitar uma placa (ReadLine) e adicionar na lista "veiculos"
			// *IMPLEMENTE AQUI*
			Console.WriteLine("Digite a placa do veículo para estacionar:");
			string placa = Console.ReadLine().ToUpper();
			bool ehUmaPlacaValida = ValidarPlaca(placa);

			if (ehUmaPlacaValida)
			{
				veiculos.Add(placa);
				return;
			}

			// else
			Console.WriteLine($"{placa} não é uma placa válida!");
		}

		public void RemoverVeiculo()
		{
			Console.WriteLine("Digite a placa do veículo para remover:");

			//[x] Pedir para o usuário digitar a placa e armazenar na variável placa
			string placa = Console.ReadLine().ToUpper();

			// Verifica se o veículo existe
			if (veiculos.Any(x => x == placa))
			{
				Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");
				string horasEstacionado = Console.ReadLine();

				// [x]: Pedir para o usuário digitar a quantidade de horas que o veículo permaneceu estacionado,
				// int horas = 0;
				_ = int.TryParse(horasEstacionado, out int horas);

				// [x]: Realizar o seguinte cálculo: "precoInicial + precoPorHora * horas" para a variável valorTotal
				decimal valorTotal = precoInicial + precoPorHora * horas;

				// [x]: Remover a placa digitada da lista de veículos
				veiculos.Remove(placa);
				Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");
			}
			else
			{
				Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
			}
		}

		public void ListarVeiculos()
		{
			// Verifica se há veículos no estacionamento
			if (veiculos.Any())
			{
				Console.WriteLine("Os veículos estacionados são:");
				//[x]: Realizar um laço de repetição, exibindo os veículos estacionados
				foreach (string placa in veiculos)
				{
					Console.WriteLine(placa);
				}
			}
			else
			{
				Console.WriteLine("Não há veículos estacionados.");
			}
		}

		public bool ValidarPlaca(string placa)
		{
			Regex regex = new(@"^(?:[A-Z]{3}-?\d{4}|[A-Z]{3}\d[A-Z]\d{2})$");
			return regex.IsMatch(placa);
		}
    }
}
