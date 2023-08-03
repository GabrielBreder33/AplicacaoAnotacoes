using System;
using System.Collections.Generic;

namespace AplicacaoAnotacoes
{
    class Note
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastModifiedAt { get; set; }
    }

    class Program
    {
        static List<Note> notes = new List<Note>();
        static int noteIdCounter = 1;

        static void Main(string[] args)
        {
            Console.WriteLine("Bem-vindo ao Aplicativo de Anotações!");

            while (true)
            {
                Console.WriteLine("\nSelecione uma opção:");
                Console.WriteLine("1. Listar notas");
                Console.WriteLine("2. Criar nova nota");
                Console.WriteLine("3. Editar nota");
                Console.WriteLine("4. Excluir nota");
                Console.WriteLine("5. Sair");

                int opcao = Convert.ToInt32(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        ListarNotas();
                        break;
                    case 2:
                        CriarNota();
                        break;
                    case 3:
                        EditarNota();
                        break;
                    case 4:
                        ExcluirNota();
                        break;
                    case 5:
                        Console.WriteLine("Obrigado por usar o Aplicativo de Anotações. Até logo!");
                        return;
                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }
            }
        }

        static void ListarNotas()
        {
            Console.WriteLine("\nNotas:");

            if (notes.Count == 0)
            {
                Console.WriteLine("Nenhuma nota encontrada.");
            }
            else
            {
                foreach (var note in notes)
                {
                    Console.WriteLine($"ID: {note.Id}, Título: {note.Title}, Criada em: {note.CreatedAt}, Última modificação: {note.LastModifiedAt}");
                }
            }
        }

        static void CriarNota()
        {
            Console.WriteLine("\nCriar Nova Nota:");

            Console.WriteLine("Digite o título da nota:");
            string title = Console.ReadLine();

            Console.WriteLine("Digite o conteúdo da nota:");
            string content = Console.ReadLine();

            Note newNote = new Note
            {
                Id = noteIdCounter++,
                Title = title,
                Content = content,
                CreatedAt = DateTime.Now,
                LastModifiedAt = DateTime.Now
            };

            notes.Add(newNote);

            Console.WriteLine("Nota criada com sucesso!");
        }

        static void EditarNota()
        {
            Console.WriteLine("\nEditar Nota:");

            Console.WriteLine("Digite o ID da nota que deseja editar:");
            int id = Convert.ToInt32(Console.ReadLine());

            Note noteToEdit = notes.Find(note => note.Id == id);

            if (noteToEdit == null)
            {
                Console.WriteLine("Nota não encontrada.");
            }
            else
            {
                Console.WriteLine($"Título atual: {noteToEdit.Title}");
                Console.WriteLine("Digite o novo título da nota (ou pressione Enter para manter o atual):");
                string newTitle = Console.ReadLine();

                Console.WriteLine($"Conteúdo atual: {noteToEdit.Content}");
                Console.WriteLine("Digite o novo conteúdo da nota (ou pressione Enter para manter o atual):");
                string newContent = Console.ReadLine();

                if (!string.IsNullOrEmpty(newTitle))
                {
                    noteToEdit.Title = newTitle;
                }

                if (!string.IsNullOrEmpty(newContent))
                {
                    noteToEdit.Content = newContent;
                }

                noteToEdit.LastModifiedAt = DateTime.Now;

                Console.WriteLine("Nota editada com sucesso!");
            }
        }

        static void ExcluirNota()
        {
            Console.WriteLine("\nExcluir Nota:");

            Console.WriteLine("Digite o ID da nota que deseja excluir:");
            int id = Convert.ToInt32(Console.ReadLine());

            Note noteToDelete = notes.Find(note => note.Id == id);

            if (noteToDelete == null)
            {
                Console.WriteLine("Nota não encontrada.");
            }
            else
            {
                notes.Remove(noteToDelete);
                Console.WriteLine("Nota excluída com sucesso!");
            }
        }
    }
}