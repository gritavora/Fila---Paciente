using System;

class Paciente {
    public string Nome { get; set; }
    public bool Prioritario { get; set; }

    public Paciente(string nome, bool prioritario) {
        Nome = nome;
        Prioritario = prioritario;
    }
}

class Program {
    static Paciente[] fila = new Paciente[10];
    static int quantidadePacientes = 0;

    static void Main(string[] args) {
        bool continuar = true;
        while (continuar) {
            Console.WriteLine("\n=== Controle de Fila de Pacientes ===\n");
            Console.WriteLine("1. Cadastrar Paciente");
            Console.WriteLine("2. Listar Pacientes na Fila");
            Console.WriteLine("3. Atender Paciente");
            Console.WriteLine("Pressione 'q' para sair");
            Console.Write("\n Escolha uma opção: ");

            ConsoleKeyInfo tecla = Console.ReadKey();

            if (tecla.Key == ConsoleKey.Q) {
                continuar = false;
                continue;
            }

            int opcao;
            if (!int.TryParse(tecla.KeyChar.ToString(), out opcao)) {
                Console.WriteLine("\nOpção inválida! Tente novamente.\n");
                
                continue;
            }

            switch (opcao) {
                case 1:
                    
                    CadastrarPaciente();
                ;
                
                break;
                    
                    
                case 2:
                    ListarPacientes();
                    break;
                case 3:
                    AtenderPaciente();
                    break;
                default:
                    Console.WriteLine("\n1Opção inválida! Tente novamente.\n");
                    break;
            }
             
        }
    }

    static void CadastrarPaciente() {


        do {
        Console.Clear();
        
        Console.WriteLine("=== Cadastrar Paciente ===");
        // Aqui você implementa a lógica para cadastrar o paciente
        Console.Write("\nDigite o nome do paciente: \n");
        string nome = Console.ReadLine();
        Console.Write("\n O paciente é prioritário? (S/N): ");
        bool prioritario = Console.ReadLine().ToUpper() == "S";
        Paciente paciente = new Paciente(nome, prioritario);
        //Console.WriteLine("Paciente cadastrado com sucesso!");
        if (quantidadePacientes < fila.Length) {
            fila[quantidadePacientes] = paciente;
            quantidadePacientes++;
            Console.WriteLine("\nPaciente cadastrado com sucesso!");
        } else {
            Console.WriteLine("\nA fila está cheia! Não é possível cadastrar mais pacientes.");
        }

        Console.Clear();
        Console.WriteLine("\n\nPressione qualquer tecla para continuar cadastrando ou (M) para voltar ao menu.");
        ConsoleKeyInfo tecla = Console.ReadKey();
        if (tecla.KeyChar == 'm') return;
    } while (true);
}

  

    static void ListarPacientes() {
        Console.Clear();
        Console.WriteLine("\n=== Pacientes na Fila ===");
        if (quantidadePacientes == 0) {
            Console.WriteLine("Não há pacientes na fila.");
            return;
        }


        for (int i = 0; i < quantidadePacientes; i++) {
            Paciente paciente = fila[i];
            Console.WriteLine($"Nome: {paciente.Nome}, Prioritário: {(paciente.Prioritario ? "Sim" : "Não")}");
        }
    }

    static void AtenderPaciente() {
        Console.Clear();
    if (quantidadePacientes == 0) {
        Console.WriteLine("\n\nNão há pacientes na fila para atender.");
        return;
    }

    Paciente pacienteAtendido = null;

    // Verifica se há algum paciente prioritário na fila
    for (int i = 0; i < quantidadePacientes; i++) {
        if (fila[i].Prioritario) {
            pacienteAtendido = fila[i];
            // Remover paciente atendido e ajustar os demais
            for (int j = i + 1; j < quantidadePacientes; j++) {
                fila[j - 1] = fila[j];
            }
            quantidadePacientes--;
            break;
        }
    }

    // Se não há paciente prioritário, atende o próximo paciente normalmente
    if (pacienteAtendido == null) {
        pacienteAtendido = fila[0];
        // Remover paciente atendido e ajustar os demais
        for (int i = 1; i < quantidadePacientes; i++) {
            fila[i - 1] = fila[i];
        }
        quantidadePacientes--;
    }

    Console.WriteLine($"\n\nPaciente {pacienteAtendido.Nome} atendido e removido da fila.");
}


 


}
