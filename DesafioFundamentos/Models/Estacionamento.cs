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


            string placa = "";
            while (placa.Length < 8)
            {

                placa = GetPlaca("Digite a placa do veículo para estacionar:");
            }
            veiculos.Add(placa);
        }

        string GetPlaca(string msg)
        {
            Console.WriteLine(msg);
            return Console.ReadLine();
        }

        public void RemoverVeiculo()
        {
            string placa = GetPlaca("Digite a placa do veículo para remover:"); ;

            // Verifica se o veículo existe
            isVeiculo(placa);
        }

        void isVeiculo(string placa)
        {

            if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
            {

                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");
                int horas = Convert.ToInt32(Console.ReadLine());
                decimal valorTotal = (precoInicial + precoPorHora) * horas;

                RemoveVeiculo(veiculos, placa);
                Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");
                return;
            }

            Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
        }

        // TODO: Remover a placa digitada da lista de veículos
        List<string> RemoveVeiculo(List<string> lst, string placa)
        {
            lst.Remove(placa);
            return lst;
        }
        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                foreach (var item in veiculos)
                {
                    Console.WriteLine($"Veículos Placa: {item}");
                }

                return;
            }

            Console.WriteLine("Não há veículos estacionados.");

        }
    }
}
