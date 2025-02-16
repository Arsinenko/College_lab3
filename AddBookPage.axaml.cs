using System;
using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Books.Models;

namespace Books;

public partial class AddBookPage : UserControl
{
    public AddBookPage()
    {
        InitializeComponent();
    }

    private void AddBookBtn_OnClick(object? sender, RoutedEventArgs e)
    {
        try
        {
            using (Context context = new Context())
            {
                var book = new Book
                {
                    Title = Title.Text,
                    Author = Author.Text,
                    Annotation = Annotation.Text
                };
            
                context.Books.Add(book);
                Console.WriteLine($"Book before save: {book.Title}");
            
                var savedCount = context.SaveChanges();
                Console.WriteLine($"Saved {savedCount} records");
            
                // Проверка сохранения
                var savedBook = context.Books.FirstOrDefault(b => b.Title == Title.Text);
                Console.WriteLine($"{savedBook.Title} {savedBook.Author} {savedBook.Annotation}");
            
                Title.Text = "";
                Author.Text = "";
                Annotation.Text = "";
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            Console.WriteLine($"Stack trace: {ex.StackTrace}");
        }

        var mainWindow = (MainWindow)this.VisualRoot!;
        mainWindow.LoadBooks();
    }
}